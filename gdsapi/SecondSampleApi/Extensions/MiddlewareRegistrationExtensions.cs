using SecondSampleApi.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;

namespace SecondSampleApi.Extensions
{
    public static class MiddlewareRegistrationExtensions
    {
        public static WebApplication AddProjectMiddlewares(this WebApplication app)
        {
            // serilog middleware add
            app.UseSerilogRequestLogging(options =>
            {
                options.MessageTemplate = "HTTP {RequestMethod} {RequestScheme}://{RequestHost}{RequestPath} → {StatusCode} ({Elapsed:0.0000} ms)";

                options.GetLevel = (httpContext, elapsed, ex) =>
                {
                    if (ex != null || httpContext.Response.StatusCode >= 500)
                        return LogEventLevel.Error;

                    if (httpContext.Response.StatusCode >= 400)
                        return LogEventLevel.Warning;

                    if (elapsed > 1000) // 1초 이상
                        return LogEventLevel.Warning;

                    if (app.Environment.IsDevelopment())
                    {
                        return LogEventLevel.Information;
                    }
                    else
                    {
                        // 일반 요청은 저장하지 않도록.
                        return LogEventLevel.Verbose;
                    }
                };

                options.EnrichDiagnosticContext = (diag, ctx) =>
                {
                    diag.Set("RequestHost", ctx.Request.Host.Value);
                    diag.Set("RequestScheme", ctx.Request.Scheme);
                };
            });

            // Register middlewares
            app.UseMiddleware<TraceIdMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<ClientAuthMiddleware>();
            app.UseMiddleware<SuccessRequestLoggingMiddleware>();

            return app;
        }
    }
} 