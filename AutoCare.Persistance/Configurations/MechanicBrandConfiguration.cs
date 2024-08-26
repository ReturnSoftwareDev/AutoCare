using AutoCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCare.Persistance.Configurations
{
    public class MechanicBrandConfiguration : IEntityTypeConfiguration<MechanicBrands>
    {
        public void Configure(EntityTypeBuilder<MechanicBrands> builder)
        {
            builder.ToTable("MechanicBrands");

            builder.HasKey(mb => new { mb.MechanicId, mb.BrandId });

            // Relationships
            builder.HasOne(mb => mb.Mechanic)
                .WithMany(m => m.MechanicBrands)
                .HasForeignKey(mb => mb.MechanicId);

            builder.HasOne(mb => mb.Brand)
                .WithMany(b => b.MechanicBrands)
                .HasForeignKey(mb => mb.BrandId);
        }
    }
}
