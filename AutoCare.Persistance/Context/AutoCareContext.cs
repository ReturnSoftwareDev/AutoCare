using AutoCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Persistance.Context;
public class AutoCareContext : DbContext
{
    public AutoCareContext(DbContextOptions<AutoCareContext> context) : base(context)
    {

    }
    public DbSet<Mechanic> Mechanics { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<About> Abouts { get; set; }
    public DbSet<AboutArticle> AboutArticles{ get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<CompanyAddress> CompanyAddresses { get; set; }
    public DbSet<ContactMessage> ContactMessages { get; set; }
    public DbSet<Newsletter> Newsletters { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Inform> Informs{ get; set; }
    public DbSet<Feature> Features{ get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}

