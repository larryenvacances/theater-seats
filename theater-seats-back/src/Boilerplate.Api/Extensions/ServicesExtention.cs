﻿using System;
using AutoMapper;
using Boilerplate.Application.Interfaces.Theater;
using Boilerplate.Application.Services.Theater;
using Boilerplate.Domain.Repositories.Theater;
using Boilerplate.Infrastructure.Repositories.Theater;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void AddTheaterServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<ITimeSlotsRepository, TimeSlotsRepository>();
            services.AddScoped<ITimeSlotsAppService, TimeSlotsAppService>();
            
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IMoviesAppService, MoviesAppService>();
        }
    }
}