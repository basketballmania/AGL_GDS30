using SampleApi.Extensions.Configurations;
using SampleApi.Options;
using Microsoft.AspNetCore.Mvc;

namespace SampleApi.Extensions
{
    public static class OptionRegistrationExtensions
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