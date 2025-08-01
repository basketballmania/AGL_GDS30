using AGL.Api.ApplicationCore.Models.Queries;

namespace AGL.Api.ApplicationCore.Interfaces
{
    public interface IIdentityService : IIdentifiable
    {
        string ClientId { get; }
        uint UserId { get; }
        string Language { get; set; }
        string Currency { get; }
        string Nation { get;  }
        string UserEmail { get; }
        string SessionId { get; }
        ClientQuery ClientQuery { get; }
        public void UserCheck();
        string Referer { get; }
        string IpAddress { get; }
        string ClientOrginDomain { get; }
        string ClientDomain { get; }
        string Token { get; }
        string Device { get; }
        string OTA_ClientId { get; }
        string OTA_AccessKey { get; }
    }
}