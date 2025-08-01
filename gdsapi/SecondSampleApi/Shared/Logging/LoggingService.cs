using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using SecondSampleApi.Enums;

namespace SecondSampleApi.Shared.Logging
{
    public enum LogCategoryEnum
    {
        Undefined = 0,
        HttpRequest = 1,
        BackgroundTask = 2,
        JobScheduler = 3,
    }

    public enum EventEnum
    {
        Undefined = 0,
        WarmUp = 1,
    }

    public class LogPayload
    {
        public string TraceId { get; set; } = string.Empty;
        public LogCategoryEnum? Category { get; set; } // ex) "HttpRequest", "BackgroundTask", "JobScheduler"
        public EventEnum? Event { get; set; }     // ex) "SendEmail", "DataSync", "TimerTrigger"
        public ErrorCodeEnum? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public long? DurationMs { get; set; }
        public object? Request { get; set; }
        public object? Response { get; set; }
        public object? Exception { get; set; }
        public Dictionary<string, object>? Metadata { get; set; } // Custom props

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            Converters = new List<JsonConverter> { new StringEnumConverter() }
        });
    }

    public interface ILoggingService
    {
        void LogInfo(LogPayload payload);
        void LogError(LogPayload payload);
        void LogDebug(LogPayload payload);
    }

    public class LoggingService : ILoggingService
    {
        private readonly ILogger<LoggingService> _logger;

        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        public void LogInfo(LogPayload payload)
        {
            _logger.LogInformation("\n{Log}", payload);
        }

        public void LogError(LogPayload payload)
        {
            _logger.LogError("\n{Log}", payload);
        }

        public void LogDebug(LogPayload payload)
        {
            _logger.LogDebug("\n{Log}", payload);
        }
    }
}
