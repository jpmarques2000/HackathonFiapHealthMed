using Hackathon.HealthMed.Domain.Interfaces.Repositories;
using Hackathon.HealthMed.Infraestructure.Repositories;
using Hackathon.HealthMed.Services.Interfaces.Services;
using Hackathon.HealthMed.Services.Services;
using Hackathon.HealthMed.Services.Shared;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Crosscutting
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddScoped<IBaseNotification, BaseNotification>()
                .AddScoped<IDoctorRepository, DoctorRepository>()
                .AddScoped<IPatientRepository, PatientRepository>()
                .AddScoped<IScheduleRepository, ScheduleRepository>()
                .AddScoped<IUserRepository, UserRepository>();
                
            services
                .AddScoped<IUserService, UserService>()
                .AddScoped<IDoctorService, DoctorService>()
                .AddScoped<IScheduleService, ScheduleService>()
                .AddScoped<IPatientService, PatientService>();
            return services;
        }
    }
}
