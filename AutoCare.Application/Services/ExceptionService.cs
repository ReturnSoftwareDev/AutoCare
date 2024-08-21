using AutoCare.Application.FVExceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Services
{
    public static class ExceptionService
    {
        public static void AddExceptionService(this IServiceCollection services)
        {
            services.AddTransient<CustomExceptionMiddleware>();
        }
    }
}
