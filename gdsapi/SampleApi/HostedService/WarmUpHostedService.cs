using AGL.Api.ApplicationCore.Extensions;
using Microsoft.Extensions.Options;
using SampleApi.Enums;
using SampleApi.Options;
using SampleApi.Services.Interfaces;
using SampleApi.Shared.Logging;
using System.Diagnostics;

namespace SampleApi.HostedService
{
    public class WarmUpHostedService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly WarmUpSettings _settings;
        private readonly ILoggingService _loggingService;

        public WarmUpHostedService(IServiceProvider serviceProvider, IOptions<WarmUpSettings> options, ILoggingService loggingService)
        {
            _serviceProvider = serviceProvider;
            _settings = options.Value;
            _loggingService = loggingService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await RunWarmUpAsync(stoppingToken);

            using PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromMinutes(_settings.IntervalMinutes));

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                await RunWarmUpAsync(stoppingToken);
            }
        }

        private async Task RunWarmUpAsync(CancellationToken token)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var warmUpServices = scope.ServiceProvider.GetServices<IWarmUpService>() ?? Enumerable.Empty<IWarmUpService>();

                foreach (var warmUpService in warmUpServices)
                {
                    await warmUpService.WarmUpAsync();
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError(new LogPayload
                {
                    TraceId = Activity.Current?.TraceId.ToString()
                        ?? Guid.NewGuid().ToString(),
                    Category = LogCategoryEnum.BackgroundTask,
                    Event = EventEnum.WarmUp,
                    ErrorCode = ErrorCodeEnum.WarmUpError,
                    ErrorMessage = ErrorCodeEnum.WarmUpError.Description(),
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
