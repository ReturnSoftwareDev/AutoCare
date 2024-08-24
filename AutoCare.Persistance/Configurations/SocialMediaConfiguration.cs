using AutoCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Persistance.Configurations
{
    public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.ToTable("SocialMedias");

            builder.HasKey(x => x.Id); // unique id
            builder.Property(x => x.Id).UseIdentityColumn(); // otomatik artan

            builder.Property(x => x.Url)
                .IsRequired();
                
            builder.Property(x => x.Icon)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.UpdatedDate)
                .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasQueryFilter(x => !x.IsDeleted);


        }
    }
}
