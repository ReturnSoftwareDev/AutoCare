using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Services
{
    public static class AddFluentValidationService
    {
        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(opt =>
            {
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });
        }
    }
}
