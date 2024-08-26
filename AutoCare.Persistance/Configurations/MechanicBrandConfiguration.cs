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

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasKey(mb => new { mb.MechanicId, mb.BrandId });

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
            builder.HasOne(mb => mb.Mechanic)
                .WithMany(m => m.MechanicBrands)
                .HasForeignKey(mb => mb.MechanicId);

            builder.HasOne(mb => mb.Brand)
                .WithMany(b => b.MechanicBrands)
                .HasForeignKey(mb => mb.BrandId);
        }
    }
}
