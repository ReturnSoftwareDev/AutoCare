using AutoCare.Application.Behavior;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Services
{
    public static class AddMediatorService
    {
        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(AddMediatorService).Assembly);
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
                });
        }
    }
}
