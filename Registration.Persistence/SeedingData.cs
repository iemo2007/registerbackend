using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Persistence
{
    public static class SeedingData
    {
        public static async Task SeedData(this IServiceCollection services)
        {
            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            using IServiceScope scope = serviceProvider.CreateScope();
            RegistrationContext context = scope.ServiceProvider.GetRequiredService<RegistrationContext>();

            

            try
            {
                await context.Database.MigrateAsync();
                if (!context.Governates.Any())
                {
                    await SeedGovernatesAsync(context);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured during Seeding Data");
            }
        }
        public static async Task SeedGovernatesAsync(RegistrationContext context)
        {
            List<Governate> governates = new List<Governate>
            {
                new Governate
                {
                    Name = "Cairo",
                    Cities = new List<City>
                    {
                        new City { Name = "Helwan"},
                        new City { Name = "Maadi"},
                         new City { Name = "Basateen"}
                    }
                },
                new Governate
                {
                    Name = "Giza",
                    Cities = new List<City>
                    {
                        new City { Name = "6th October"},
                        new City { Name = "Mohandsen"},
                        new City { Name = "Lebanon Square"},
                        new City { Name = "Moneb"}
                    }
                },
                new Governate
                {
                    Name = "Alexandria",
                    Cities = new List<City>
                    {
                        new City { Name = "Semoha"},
                        new City { Name = "Sporting"},
                        new City { Name = "Agamy"},
                        new City { Name = "Abo Keer"},
                        new City { Name = "Nozha"}
                    }
                }
            };
            await context.Governates.AddRangeAsync(governates);
        }
    }
}
