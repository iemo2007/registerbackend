using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Registration.Application.Features.GovernateCountFeatures.Commands.IncreaseGovernateCount;
using Registration.Application.RabbitMQService;
using Registration.Application.RabbitMQService.Producers.GovernateCountNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IGovernateCountNotificationService, GovernateCountNotificationService>();
                    
            return services;
        }
    }
}
