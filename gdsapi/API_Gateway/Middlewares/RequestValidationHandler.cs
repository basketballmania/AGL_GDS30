using System.Net;

namespace API_Gateway.Middlewares
{
    public class RequestValidationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var path = context.Request.Path.Value ?? "";

            // Default 경로 예외 처리 (검증 없이 통과)
            if (path.Equals("/"))
            {
                await next(context);
                return;
            }

            // 1. clientId 및 Authorization 헤더 확인
            var clientId = context.Request.Headers["clientId"].FirstOrDefault();
            var authorization = context.Request.Headers["authorization"].FirstOrDefault();

            if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(authorization))
            {
                await WriteJsonResponseAsync(context, "Unauthorized: Missing credentials");
                return;
            }

            // 2. Authorization 헤더에서 "Bearer" 토큰 추출
            var accessToken = authorization.ToString().Split("Bearer")[1].Trim();
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                await WriteJsonResponseAsync(context, "Unauthorized: Invalid or missing accessToken");
                return;
            }

            await next(context);
        }

        private async Task WriteJsonResponseAsync(HttpContext context, string message)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.ContentType = "application/json";

            var jsonResponse = new
            {
                RstCd = "FL01", // 잘못된 요청
                RstMsg = message
            };

            await context.Response.WriteAsJsonAsync(jsonResponse);
        }
    }
}
