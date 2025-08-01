using SampleApi.Middlewares;
using SampleApi.Shared.Logging;

namespace SampleApi.Extensions
{
    public static class AddProjectDependencyInjectionExtension
    {
        public static void AddProjectDependencyInjection(this IServiceCollection service)
        {
            // <!-- SCOPED SERVICES ----->
            service.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes.InNamespaces("SampleApi.Services"))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            // <!-- SCOPED SERVICES FROM INTERFACES ----->
            service.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes.InNamespaces("SampleApi.Interfaces"))
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