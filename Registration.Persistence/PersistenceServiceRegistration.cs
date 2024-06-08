using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Registration.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static async Task<IServiceCollection> AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<RegistrationContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("RegistrationDB")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            await services.SeedData();
            return services;
        }
    }
}
