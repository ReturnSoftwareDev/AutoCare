using AutoCare.Application.Interfaces.GenericRepositories;
using AutoCare.Application.UnitOfWorks;
using AutoCare.Persistance.Repositories.GenericRepositories;
using AutoCare.Persistance.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Persistance.Configurations
{
    public static class Configuration
    {
        public static void AddPersistenceConfiguration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
