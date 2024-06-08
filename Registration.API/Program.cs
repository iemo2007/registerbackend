using MassTransit;
using Microsoft.Extensions.Configuration;
using Registration.API.Middleware;
using Registration.Application;
using Registration.Infrastructure;
using Registration.Persistence;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

await builder.Services.AddPersistenceServices(builder.Configuration);

var rabbitMQHost = builder.Configuration.GetSection("RabbitMQ:Host").Value;
var rabbitMQUsername = builder.Configuration.GetSection("RabbitMQ:Username").Value;
var rabbitMQPassword = builder.Configuration.GetSection("RabbitMQ:Password").Value;

builder.Services.AddMassTransit(conf =>
{
    conf.SetKebabCaseEndpointNameFormatter();
    conf.SetInMemorySagaRepositoryProvider();

    var asb = typeof(Program).Assembly;

    conf.AddConsumers(asb);
    conf.AddSagaStateMachines(asb);
    conf.AddSagas(asb);
    conf.AddActivities(asb);

    conf.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(rabbitMQHost, "/", h =>
        {
            h.Username(rabbitMQUsername);
            h.Password(rabbitMQPassword);
        });
        cfg.ConfigureEndpoints(ctx);
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Host.UseSerilog((context, loggerConfig) =>
loggerConfig.WriteTo.Console()
    .ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/api/errors/{0}");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
