using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Registration.Domain;
using Registration.Domain.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Registration.Persistence
{
    public class RegistrationContext: DbContext
    {
        public RegistrationContext(DbContextOptions<RegistrationContext> options): base(options)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Governate> Governates { get; set; }
        public DbSet<GovernateCount> GovernateCount { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (EntityEntry<BaseEntity> entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added)) 
            {
                entry.Entity.CreatedOn = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(RegistrationContext).Assembly);
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new GovernateConfiguration());
            modelBuilder.ApplyConfiguration(new GovernateCountConfiguration());
            base.OnModelCreating(modelBuilder);

        }
    }
}
