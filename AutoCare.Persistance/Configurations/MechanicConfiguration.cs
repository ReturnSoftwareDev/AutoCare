using AutoCare.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Persistance.Configurations;
public class MechanicConfiguration : IEntityTypeConfiguration<Mechanic>
{
    public void Configure(EntityTypeBuilder<Mechanic> builder)
    {
        builder.ToTable("Mechanics");

        builder.HasKey(x => x.Id);  
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(x => x.Email)
            .HasMaxLength(100);

        builder.Property(x => x.City)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Discrict)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Neighborhood)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.CreatedDate)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        builder.Property(x => x.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasQueryFilter(x => !x.IsDeleted);

        // Relationships
        builder.HasMany(m => m.MechanicServices)
            .WithOne()
            .HasForeignKey(ms => ms.MechanicId);

        builder.HasMany(m => m.MechanicBrands)
            .WithOne()
            .HasForeignKey(mb => mb.MechanicId);
    }
}