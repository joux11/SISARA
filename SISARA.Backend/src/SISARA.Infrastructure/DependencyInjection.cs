using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SISARA.Application.Interfaces;
using SISARA.Infrastructure.Persistence;
using SISARA.Infrastructure.Persistence.Repositories;
using SISARA.Infrastructure.Services;


namespace SISARA.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlConnection");
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUserDeviceRepository, UserDeviceRepository>();


            return services;
        }
    }
}
