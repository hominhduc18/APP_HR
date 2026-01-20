using ItoApp.Application.Interfaces;
using ItoApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ItoApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddScoped<ItoApp.Application.Auth.Register.RegisterService>();
            
            return services;
        }
    }
}
