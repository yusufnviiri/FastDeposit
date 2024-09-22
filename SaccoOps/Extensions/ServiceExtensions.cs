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
    }
}