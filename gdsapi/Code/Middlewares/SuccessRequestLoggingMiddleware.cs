using AGL.Api.ApplicationCore.Utilities;
using Code.Shared.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Code.Middlewares
{
    public class SuccessRequestLoggingMiddleware : IMiddleware
    {
        private readonly ILoggingService _loggingService;
        private readonly IWebHostEnvironment _env;

        public SuccessRequestLoggingMiddleware(ILoggingService loggingService, IWebHostEnvironment env)
        {
            _loggingService = loggingService;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // HTTP GET 요청은 로깅하지 않음
            if (!_env.IsDevelopment() && context.Request.Method.ToUpper() == "GET")
            {
                await next(context);
                return;
            }

            var stopwatch = Stopwatch.StartNew();
            context.Request.EnableBuffering();

            // 응답 본문 가로채기
            var originalResponseBody = context.Response.Body;
            using var responseBodyMemory = new MemoryStream();
            context.Response.Body = responseBodyMemory;

            try
            {
                await next(context); // 예외 발생 가능
            }
            finally
            {
                stopwatch.Stop();

                // 응답 스트림 복원
                context.Response.Body = originalResponseBody;

                // 응답 본문 원래 스트림에 복사
                responseBodyMemory.Seek(0, SeekOrigin.Begin);
                await responseBodyMemory.CopyToAsync(originalResponseBody);
            }

            // 상태 코드가 200인 경우만 로깅
            if (context.Response.StatusCode == 200)
            {
                responseBodyMemory.Seek(0, SeekOrigin.Begin);
                string responseBody = await new StreamReader(responseBodyMemory).ReadToEndAsync();

                _loggingService.LogInfo(new LogPayload
                {
                    TraceId = context.TraceIdentifier,
                    Category = LogCategoryEnum.HttpRequest,
                    DurationMs = stopwatch.ElapsedMilliseconds,
                    Request = await LogBuilder.CreateRequestInfoAsync(context),
                    Response = new
                    {
                        StatusCode = context.Response.StatusCode,
                        Headers = context.Response.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()),
                        Body = LogBuilder.TryParseJsonOrRaw(responseBody)
                    }
                });
            }
        }
    }
}
