﻿using AutoCare.Application.Mapping;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Services
{
    public static class AutoMapperService
    {
        public static void AddAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddAutoMapper(typeof(GeneralMapping).Assembly);
        }
    }
}
