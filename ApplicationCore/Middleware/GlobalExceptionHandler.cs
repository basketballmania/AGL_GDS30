using System.Net;
using AGL.Api.ApplicationCore.Models;
using AGL.Api.ApplicationCore.Models.Enum;
using AGL.Api.ApplicationCore.Utilities;
using Microsoft.AspNetCore.Http;

namespace AGL.Api.ApplicationCore.Middleware
{
    public class GlobalExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (DomainException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest, ex.Code);
            }
            catch(UnauthorizedAccessException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.Unauthorized, ResultCode.비로그인);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError, ResultCode.잘못된요청);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception e, HttpStatusCode statusCode, ResultCode resultCode)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var jsonResult = new Failure
            {
                Code = resultCode,
                RstMsg = e.Message
            };

            var ExceptionType = e.GetType().FullName;
            var StatusCode = (int)statusCode;
            var Message = e.Message;
            var ErrorPath = e.StackTrace?.Substring(3, e.StackTrace.IndexOf("line") + 7);

            LogService.logError($"Type: {ExceptionType} ({StatusCode}) || Message: {Message} || Path: {ErrorPath}");

            await context.Response.WriteAsJsonAsync(jsonResult);
        }
    }
}
