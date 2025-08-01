using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Options;

namespace API_Gateway.Extensions.Configurations
{
    public class ConfigureKestrelOptions : IConfigureNamedOptions<KestrelServerOptions>
    {
        public void Configure(string? name, KestrelServerOptions options)
        {
            Configure(options);
        }

        public void Configure(KestrelServerOptions options)
        {
            options.ListenAnyIP(5028, listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
            });

            options.ListenAnyIP(7184, listenOptions =>
            {
                listenOptions.UseHttps();
                listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
            });
        }
    }
}