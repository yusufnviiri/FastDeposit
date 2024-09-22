using Contracts;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Identity;
using Repository;

namespace SaccoOps.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyHeader());
            });
        }
        public static void ConfigureIISOptions(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { });
        }
        public static void ConfigureLoggerService(this IServiceCollection services) =>
 services.AddSingleton<ILoggerManager, LoggerManager>();
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 4;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }

    }
}