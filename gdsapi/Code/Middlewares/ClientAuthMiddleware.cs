using System.Net;
using AGL.Api.ApplicationCore.Exceptions;
using AGL.Api.ApplicationCore.Models.Enum;
using AGL.Api.Domain.Entities;
using AGL.Api.Infrastructure.Data;
using Code.Enums;
using Code.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Code.Middlewares
{
    public class ClientAuthMiddleware : IMiddleware
    {
        private readonly CmsDbContext _cmsDbContext;

        public ClientAuthMiddleware(CmsDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path.StartsWithSegments("/swagger") || context.Request.Path.Equals("/"))
            {
                await next(context);
                return;
            }

            // ClientId & AccessToken 유효성 체크
            var clientId = context.Request.Headers["clientId"].FirstOrDefault();
            var authorization = context.Request.Headers["authorization"].FirstOrDefault();

            if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(authorization))
            {
                throw new CodeAPIException(API_ResultCode.AuthenticationFailed, ErrorCodeEnum.UnauthorizedClient);
            }

            var accessToken = authorization.Split("Bearer")[1].Trim();

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new CodeAPIException(API_ResultCode.AuthenticationFailed, ErrorCodeEnum.UnauthorizedClient);
            }

            // 클라이언트 유효성 체크
            TA_Client? client = await _cmsDbContext.TA_Client
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ClientID == clientId && x.ClientKey == accessToken);

            if (client == null)
            {
                throw new CodeAPIException(API_ResultCode.AuthenticationFailed, ErrorCodeEnum.UnauthorizedClient);
            }

            await next(context);
        }
    }
}