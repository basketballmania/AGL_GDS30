using SecondSampleApi.Extensions.Configurations;
using SecondSampleApi.Options;
using Microsoft.AspNetCore.Mvc;

namespace SecondSampleApi.Extensions
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