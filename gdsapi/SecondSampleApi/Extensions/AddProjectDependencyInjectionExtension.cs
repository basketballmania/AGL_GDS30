using SecondSampleApi.Middlewares;
using SecondSampleApi.Shared.Logging;

namespace SecondSampleApi.Extensions
{
    public static class AddProjectDependencyInjectionExtension
    {
        public static void AddProjectDependencyInjection(this IServiceCollection service)
        {
            // <!-- SCOPED SERVICES ----->
            service.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes.InNamespaces("SecondSampleApi.Services"))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            // <!-- TRANSIENT SERVICES -->
            service.AddTransient<TraceIdMiddleware>();
            service.AddTransient<ExceptionMiddleware>();
            service.AddTransient<ClientAuthMiddleware>();
            service.AddTransient<SuccessRequestLoggingMiddleware>();

            // <!-- SINGLETON SERVICES -->
            service.AddSingleton<ILoggingService, LoggingService>();
        }
    }
} 