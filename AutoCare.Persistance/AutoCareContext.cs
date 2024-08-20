using AutoCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Persistance;
public class AutoCareContext : DbContext
{
    public AutoCareContext(DbContextOptions<AutoCareContext> context) : base(context)
    {

    }
    public DbSet<Mechanic> Mechanics { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Address> Addresses { get; set; }
}
