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

            builder.HasKey(ms => new { ms.MechanicId, ms.ServiceId }); // Composite Key

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
