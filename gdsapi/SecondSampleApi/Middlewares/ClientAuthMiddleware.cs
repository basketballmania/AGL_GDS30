using Microsoft.AspNetCore.Http;

namespace SecondSampleApi.Middlewares
{
    public class ClientAuthMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // 클라이언트 인증 로직 구현
            var clientId = context.Request.Headers["X-Client-Id"].FirstOrDefault();
            var apiKey = context.Request.Headers["X-API-Key"].FirstOrDefault();

            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(apiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized: Missing client credentials");
                return;
            }

            // 실제 환경에서는 데이터베이스에서 클라이언트 정보를 확인
            // 여기서는 간단한 검증만 수행
            if (!IsValidClient(clientId, apiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized: Invalid client credentials");
                return;
            }

            await next(context);
        }

        private bool IsValidClient(string clientId, string apiKey)
        {
            // 실제 환경에서는 데이터베이스 조회 또는 설정에서 확인
            return !string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(apiKey);
        }
    }
} 