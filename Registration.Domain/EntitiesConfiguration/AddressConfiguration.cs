using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain.EntitiesConfiguration
{
    public class AddressConfiguration: IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(p => p.Id).HasName("PK_Address_Id");
            builder.Property(a => a.CityId).IsRequired();
            builder.Property(a => a.Street).IsRequired().HasMaxLength(200);
            builder.Property(a => a.BuildingNumber).IsRequired();
            builder.Property(a => a.FlatNumber).IsRequired();
            builder
                .HasOne(ad => ad.Account)
                .WithMany(a => a.Addresses)
                .HasForeignKey(ad => ad.AccountId)
                .HasConstraintName("FK_Address_AccountId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
