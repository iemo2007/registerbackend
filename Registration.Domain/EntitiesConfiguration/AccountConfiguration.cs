using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain.EntitiesConfiguration
{
    public class AccountConfiguration: IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(p => p.Id).HasName("PK_Account_Id");
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(a => a.MiddleName).HasMaxLength(40);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(20);
            builder.Property(a => a.BirthDate).IsRequired();
            builder.Property(a => a.MobileNumber).IsRequired();
            builder.Property(a => a.MobileNumber).IsRequired();
        }
    }
}
