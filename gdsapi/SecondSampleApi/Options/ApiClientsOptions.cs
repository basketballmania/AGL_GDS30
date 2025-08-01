using SecondSampleApi.Enums;

namespace SecondSampleApi.Options
{
    public class ApiClientsOptions
    {
        public const string SectionName = "ApiClients";
        public string BaseUrl { get; set; } = string.Empty;
        public int TimeOutSeconds { get; set; } = 30;
        public int RetryCount { get; set; } = 3;
        public int RetryDelaySeconds { get; set; } = 2;
        public int CircuitBreakCount { get; set; } = 3;
        public int CircuitBreakSecond { get; set; } = 30;
        public Authentication? Authentication { get; set; }
    }

    public class Authentication
    {
        public AuthenticationType Type { get; set; }
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
    }


    public class ApiClientsConfiguration
    {
        public Dictionary<string, ApiClientsOptions> Clients { get; set; } = new();
    }
}
