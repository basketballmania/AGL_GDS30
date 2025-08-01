using AGL.Api.ApplicationCore.Extensions;
using AGL.Api.ApplicationCore.Models.Enum;
using AGL.Api.ApplicationCore.Utilities;
using AGL.Api.Domain.Entities;
using AGL.Api.Infrastructure.Data;
using Code.Enums;
using Code.Exceptions;
using Code.Shared.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;

namespace Code.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly CmsDbContext _oApiDbContext;
        private readonly IWebHostEnvironment _env;
        private readonly ILoggingService _loggingService;

        private const string _serviceName = "code";

        public ExceptionMiddleware(CmsDbContext oApiDbContext, IWebHostEnvironment env, ILoggingService loggingService)
        {
            _oApiDbContext = oApiDbContext;
            _env = env;
            _loggingService = loggingService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                context.Request.EnableBuffering();
                await next(context);
            }
            catch (CodeAPIException ex)
            {
                await HandleExceptionAsync(context, ex.ResultCode, ex.ErrorCode, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, API_ResultCode.SystemError, ErrorCodeEnum.InternalServerError, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, API_ResultCode resultCode, ErrorCodeEnum errorCode, Exception exception)
        {
            try
            {
                API_ResultCode resonseResultCode = resultCode;
                ErrorCodeEnum responseErrorCode = errorCode;

                // 내부 오류 가림 처리
                if (resultCode == API_ResultCode.SystemError || resultCode == API_ResultCode.ExternalSystemError)
                {
                    resonseResultCode = API_ResultCode.SystemError;
                    responseErrorCode = ErrorCodeEnum.InternalServerError;
                }

                // response 데이터 생성
                context.Response.StatusCode = (int)resonseResultCode;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    status = resonseResultCode.Description(),
                    data = new
                    {
                        code = responseErrorCode.ToString(),
                        message = responseErrorCode.Description(),
                        traceId = context.TraceIdentifier,
                        details = _env.IsDevelopment() ? new List<string> { exception.ToString() } : null
                    }
                };

                // response 전송
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Formatting = Formatting.Indented
                }));

                var logPayload = new LogPayload
                {
                    TraceId = context.TraceIdentifier,
                    Category = LogCategoryEnum.HttpRequest,
                    ErrorCode = errorCode,
                    ErrorMessage = errorCode.Description(),
                    Request = await LogBuilder.CreateRequestInfoAsync(context),
                    Response = new
                    {
                        StatusCode = context.Response.StatusCode,
                        Headers = context.Response.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()),
                        Body = response
                    }
                };

                _loggingService.LogError(logPayload);

            }
            catch (Exception ex)
            {
                _loggingService.LogError(new LogPayload
                {
                    TraceId = context.TraceIdentifier,
                    Category = LogCategoryEnum.HttpRequest,
                    ErrorCode = ErrorCodeEnum.UndefinedError,
                    ErrorMessage = ErrorCodeEnum.UndefinedError.Description(),
                    Exception = new
                    {
                        ex.GetType().Name,
                        ex.Message,
                        ex.StackTrace
                    }
                });
            }
        }
    }
}
