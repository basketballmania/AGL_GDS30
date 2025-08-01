using AGL.Api.ApplicationCore.Utilities;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text;

namespace AGL.Api.ApplicationCore.Middleware
{
    public class LoggerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            #region 요청 데이터 로깅
            if (context.Request.Method.ToLower() != "options")
            {
                string log = $"Method: \"{context.Request.Method}\", Path: \"{context.Request.Path}\"";
                string data = string.Empty;

                if (context.Request.Method.ToLower() != "get")
                {
                    // Request.Body 복사하기 명령어 추가
                    context.Request.EnableBuffering();
                    context.Request.Body.Seek(0, SeekOrigin.Begin);

                    Stream requestBody = context.Request.Body;
                    byte[] buffer = new byte[Convert.ToInt32(context.Request.ContentLength)];
                    await requestBody.ReadAsync(buffer, 0, buffer.Length);
                    data = Encoding.UTF8.GetString(buffer);

                    context.Request.Body.Seek(0, SeekOrigin.Begin);

                    // if (!string.IsNullOrEmpty(data))
                    // {
                    //     log += $", Body: {data}";

                    //     LogService.logInformation(log);
                    // }
                }
                else
                {
                    // if (context.Request.Query.Count > 0)
                    // {
                    //     foreach (var queryData in context.Request.Query)
                    //     {
                    //         data += $"{queryData.Key}: {queryData.Value},";
                    //     }
                    // if (context.Request.Query.Count > 0)
                    // {
                    //     foreach (var queryData in context.Request.Query)
                    //     {
                    //         data += $"{queryData.Key}: {queryData.Value},";
                    //     }

                    //     log += ", Query: { " + data.Substring(0, data.Length - 1) + " }";
                    // }
                    //     log += ", Query: { " + data.Substring(0, data.Length - 1) + " }";
                    // }

                    // LogService.logInformation(log);
                }
            }

            #endregion

            #region 응답데이터 로깅
            var stopwatch = Stopwatch.StartNew();
            context.Response.OnStarting(async () =>
            {
                stopwatch.Stop();
                // LogService.logInformation($"HTTP {context.Request.Method} {context.Request.Path} responded {context.Response.StatusCode} in {stopwatch.ElapsedMilliseconds}ms");
                await Task.CompletedTask;
            });

            await next(context);
            
            #endregion
        }
    }
}

