using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain.EntitiesConfiguration
{
    public class GovernateCountConfiguration : IEntityTypeConfiguration<GovernateCount>
    {
        public void Configure(EntityTypeBuilder<GovernateCount> builder)
        {
            builder.ToTable("GovernateCount");
            builder.HasKey(p => p.Id).HasName("PK_GovernateCount_Id");
            builder.HasOne(gc => gc.Governate)
                .WithOne()
                .HasForeignKey<GovernateCount>(gc => gc.GovernateId)
                .HasConstraintName("FK_GovernateCount_GovernateId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
