using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SampleApi.Middlewares
{
    public class SuccessRequestLoggingMiddleware : IMiddleware
    {
        private readonly ILogger<SuccessRequestLoggingMiddleware> _logger;

        public SuccessRequestLoggingMiddleware(ILogger<SuccessRequestLoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);

            if (context.Response.StatusCode >= 200 && context.Response.StatusCode < 300)
            {
                _logger.LogInformation(
                    "Successful request: {Method} {Path} - Status: {StatusCode}",
                    context.Request.Method,
                    context.Request.Path,
                    context.Response.StatusCode);
            }
        }
    }
} 