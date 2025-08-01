using AGL.Api.ApplicationCore.Exceptions;
using AGL.Api.ApplicationCore.Models.Enum;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using SampleApi.Exceptions;

namespace SampleApi.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new
            {
                Success = false,
                Message = exception.Message,
                TraceId = context.TraceIdentifier
            };

            switch (exception)
            {
                case SampleAPIException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case DomainException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response = new
                    {
                        Success = false,
                        Message = "An unexpected error occurred.",
                        TraceId = context.TraceIdentifier
                    };
                    break;
            }

            _logger.LogError(exception, "An error occurred: {Message}", exception.Message);

            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
} 