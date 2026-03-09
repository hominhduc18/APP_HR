using ItoApp.Domain.Interfaces;
using ItoApp.Infrastructure.Data;
using ItoApp.Infrastructure.Repositories;
using ItoApp.Application.Abstractions;
using ItoApp.Infrastructure.Auth;
using ItoApp.Infrastructure.Sms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ItoApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var provider = configuration.GetValue<string>("DbProvider") ?? "SqlServer";
            var connectionString = configuration.GetConnectionString(provider);
            
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                if (provider == "SqlServer")
                {
                    options.UseSqlServer(connectionString);
                }
                else
                {
                    options.UseNpgsql(connectionString);
                }
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IOtpRepository, OtpRepository>();
            
            services.AddScoped<ISmsSender, DevSmsSender>();
            services.AddScoped<ITokenService, DevTokenService>();

            return services;
        }
    }
}
