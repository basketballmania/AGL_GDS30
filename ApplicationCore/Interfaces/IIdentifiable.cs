using System.Security.Claims;

namespace AGL.Api.ApplicationCore.Interfaces
{
    public interface IIdentifiable
    {
        string GetIdentityId();
        string GetUserName();
        string GetRequestId();
        string GetRequestUrl();
        string GetHttpMethod();
        string GetRemoteIp();
        ClaimsPrincipal GetClaimsPrincipal();
    }
}
