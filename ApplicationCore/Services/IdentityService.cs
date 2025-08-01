using AGL.Api.ApplicationCore.Interfaces;
using AGL.Api.ApplicationCore.Models.Queries;
using Microsoft.AspNetCore.Http;

namespace AGL.Api.ApplicationCore.Services
{
    public class IdentityService : Identifiable, IIdentityService
    {
        public IdentityService(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) { }

        public uint UserId
        {
            get
            {
                uint.TryParse(_httpContextAccessor.HttpContext.Request.Headers["user-id"], out uint i);
                return i;
            }
        }

        public string Language
        {
            get
            {
                string value = _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("language") ? _httpContextAccessor.HttpContext.Request.Headers["language"] : "KO";

                if (string.IsNullOrEmpty(value)) value = "KO";

                return value;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _httpContextAccessor.HttpContext.Request.Headers["language"] = value;
                }
            }
        }

        public string Currency
        {
            get
            {
                string value = _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("currency") ? _httpContextAccessor.HttpContext.Request.Headers["currency"] : "KRW";
                if (string.IsNullOrEmpty(value)) value = "KRW";

                return value;
            }
        }

        public string ClientId
        {
            get
            {
                var httIpList = new string[] { "0.0.0.1", "15.164.249.67", "118.32.134.203", "13.209.210.58", "222.109.244.205" };

                if (httIpList.Contains(IpAddress))
                    return "HEYTEETIME";

                return _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("client-id") ? _httpContextAccessor.HttpContext.Request.Headers["client-id"] : "";
            }
        }

        public string Device
        {
            get
            {
                return _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("request-device") ? _httpContextAccessor.HttpContext.Request.Headers["request-device"] : "";
            }
        }

        public string Nation
        {
            get
            {
                return _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("nation") ? _httpContextAccessor.HttpContext.Request.Headers["nation"] : "";
            }
        }
        public string UserEmail
        {
            get
            {
                return _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("user-email") ? _httpContextAccessor.HttpContext.Request.Headers["user-email"] : "";
            }
        }

        public string SessionId
        {
            get
            {
                return _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("session-id") ? _httpContextAccessor.HttpContext.Request.Headers["session-id"] : "";
            }
        }

        public ClientQuery ClientQuery
        {
            get
            {
                return new ClientQuery
                {
                    ClientId = this.ClientId,
                    UserId = this.UserId,
                    Language = this.Language,
                    Currency = this.Currency,
                    Device = this.Device,
                    Nation = this.Nation,
                    UserEmail = this.UserEmail,
                };
            }
        }

        public void UserCheck()
        {
            if (UserId == 0)
            {
                throw new DomainException(ApplicationCore.Models.Enum.ResultCode.비로그인, "Not Allowed User");
            }
        }


        // Referer 헤더를 가져옴
        public string Referer
        {
            get
            {
                var headers = _httpContextAccessor.HttpContext?.Request.Headers;
                return headers != null && headers.ContainsKey("Referer") ? headers["Referer"].ToString() : string.Empty;
            }
        }

        // IP 주소를 가져옴
        public string IpAddress
        {
            get
            {
                return _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? string.Empty;
            }
        }

        public string ClientOrginDomain
        {
            get
            {
                return _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("request-domain") ? _httpContextAccessor.HttpContext.Request.Headers["request-domain"] : "https://www.heyteetime.com";
            }
        }

        public string ClientDomain
        {
            get
            {
                string origindomain = _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("request-domain") ? _httpContextAccessor.HttpContext.Request.Headers["request-domain"] : "https://www.heyteetime.com";

                var httDomainList = new string[] { "heyteetime.com", "tigerbooking.golf" };

                foreach (var htt in httDomainList)
                {
                    if (origindomain.Contains(htt))
                        return htt;
                }

                return httDomainList[1];
            }
        }
        public string Token
        {
            get
            {
                return _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("token") ? _httpContextAccessor.HttpContext.Request.Headers["token"] : "";
            }
        }

        public string OTA_ClientId
        {
            get
            {
                return _httpContextAccessor?.HttpContext?.Request.Headers["ClientId"].FirstOrDefault() ?? string.Empty;
            }
        }

        public string OTA_AccessKey
        {
            get
            {
                string? authorization = _httpContextAccessor?.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();

                if (string.IsNullOrEmpty(authorization))
                {
                    return string.Empty;
                }

                return authorization.Split("Bearer")[1];
            }
        }
    }
}