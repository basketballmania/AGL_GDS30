using Code.Extensions.Configurations;
using Code.Options;
using Microsoft.AspNetCore.Mvc;

namespace Code.Extensions
{
    public static class OptionResgistrationExtensions
    {
        public static IServiceCollection AddProjectOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureOptions<ConfigureKestrelOptions>();
            services.ConfigureOptions<ConfigureSwaggerGenOptions>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.Configure<WarmUpSettings>(configuration.GetSection("WarmUpSettings"));

            return services;
        }
    }
}
