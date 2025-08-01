using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace SecondSampleApi.Middlewares
{
    public class TraceIdMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // 기존 TraceId 헤더 확인
            var traceId = context.Request.Headers["X-TraceId"].FirstOrDefault()
                          ?? Activity.Current?.TraceId.ToString()
                          ?? Guid.NewGuid().ToString();

            // HttpContext에 설정
            context.Items["TraceId"] = traceId;
            context.TraceIdentifier = traceId;

            // 응답 헤더에도 추가 (클라이언트 추적 용이)
            context.Response.OnStarting(() =>
            {
                context.Response.Headers["X-TraceId"] = traceId;
                return Task.CompletedTask;
            });

            await next(context);
        }
    }
} 