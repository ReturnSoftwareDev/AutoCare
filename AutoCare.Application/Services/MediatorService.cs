using AutoCare.Application.Behavior;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Services
{
    public static class MediatorService
    {
        public static void AddMediatorService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(MediatorService).Assembly);
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
        }
    }
}
