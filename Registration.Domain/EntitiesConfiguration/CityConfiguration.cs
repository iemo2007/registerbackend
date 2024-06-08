using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain.EntitiesConfiguration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");
            builder.HasKey(p => p.Id).HasName("PK_City_Id");
            builder
                .HasOne(c => c.Governate)
                .WithMany(g => g.Cities)
                .HasForeignKey(c => c.GovernateId)
                .HasConstraintName("FK_City_GovernateId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
