﻿using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Interfaces.GenericRepositories;
using AutoCare.Application.Interfaces.TokenServices;
using AutoCare.Application.Tools;
using AutoCare.Application.UnitOfWorks;
using AutoCare.Persistance.Repositories.EntityServices;
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
    public static class Extension
    {
        public static void AddExtensionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ISocialMediaService, SocialMediaService>();
            services.AddScoped<IMechanicService, MechanicService>();
            services.AddScoped<IServiceService, ServiceService>();

            services.AddScoped<IMechanicServicesService, MechanicServicesService>();    

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
