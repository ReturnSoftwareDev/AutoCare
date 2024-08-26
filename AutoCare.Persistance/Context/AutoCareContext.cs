using AutoCare.Domain.Entities;
using AutoCare.Domain.Enums;
using AutoCare.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AutoCare.Persistance.Context;
public class AutoCareContext : DbContext
{
    public AutoCareContext(DbContextOptions<AutoCareContext> context) : base(context)
    {

    }
    public DbSet<Audit> AuditLogs{ get; set; }
    public DbSet<Mechanic> Mechanics { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<MechanicServices> MechanicServices { get; set; }
    public DbSet<MechanicBrands> MechanicBrands { get; set; }

    //public DbSet<Address> Addresses { get; set; }
    //public DbSet<About> Abouts { get; set; }
    //public DbSet<AboutArticle> AboutArticles{ get; set; }
    //public DbSet<Banner> Banners { get; set; }
    //public DbSet<CompanyAddress> CompanyAddresses { get; set; }
    //public DbSet<ContactMessage> ContactMessages { get; set; }
    //public DbSet<Newsletter> Newsletters { get; set; }

    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SocialMediaConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new MechanicConfiguration());
        modelBuilder.ApplyConfiguration(new ServiceConfiguration());
        modelBuilder.ApplyConfiguration(new BrandConfiguration());
        modelBuilder.ApplyConfiguration(new MechanicServiceConfiguration());
        modelBuilder.ApplyConfiguration(new MechanicBrandConfiguration());
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        BeforeSaveChanges();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void BeforeSaveChanges()
    {
        ChangeTracker.DetectChanges();
        var auditEntries = new List<AuditEntry>();
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                continue;
            var auditEntry = new AuditEntry(entry);
            auditEntry.TableName = entry.Entity.GetType().Name;
            auditEntry.UserId = "1";
            auditEntries.Add(auditEntry);
            foreach (var property in entry.Properties)
            {
                string propertyName = property.Metadata.Name;
                if (property.Metadata.IsPrimaryKey())
                {
                    auditEntry.KeyValues[propertyName] = property.CurrentValue;
                    continue;
                }
                switch (entry.State)
                {
                    case EntityState.Added:
                        auditEntry.AuditType = AuditType.Create;
                        auditEntry.NewValues[propertyName] = property.CurrentValue;
                        auditEntry.UserId = entry.Property("CreatedBy").CurrentValue != null ? entry.Property("CreatedBy").CurrentValue.ToString() : "Null";
                        break;
                    case EntityState.Deleted:
                        auditEntry.AuditType = AuditType.Delete;
                        auditEntry.OldValues[propertyName] = property.OriginalValue;
                        auditEntry.UserId = entry.Property("LastModifiedBy").CurrentValue != null ? entry.Property("LastModifiedBy").CurrentValue.ToString() : "Null";
                        break;
                    case EntityState.Modified:
                        if (property.IsModified)
                        {
                            auditEntry.ChangedColumns.Add(propertyName);
                            auditEntry.AuditType = AuditType.Update;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            auditEntry.UserId = entry.Property("LastModifiedBy").CurrentValue != null ? entry.Property("LastModifiedBy").CurrentValue.ToString() : "Null";
                        }
                        break;
                }
            }
        }
        foreach (var auditEntry in auditEntries)
        {
            AuditLogs.Add(auditEntry.ToAudit());
        }
    }

}

