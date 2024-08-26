using AutoCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCare.Persistance.Configurations
{
    public class MechanicServiceConfiguration : IEntityTypeConfiguration<MechanicServices>
    {
        public void Configure(EntityTypeBuilder<MechanicServices> builder)
        {
            builder.ToTable("MechanicServices");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasKey(ms => new { ms.MechanicId, ms.ServiceId }); // Composite Key

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.UpdatedDate)
                .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(ms => ms.IsActive).IsRequired().HasDefaultValue(false);

            // Relationships
            builder.HasOne(ms => ms.Mechanic)
                .WithMany(m => m.MechanicServices)
                .HasForeignKey(ms => ms.MechanicId);

            builder.HasOne(ms => ms.Service)
                .WithMany(s => s.MechanicServices)
                .HasForeignKey(ms => ms.ServiceId);
        }
    }
}
