using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Options;

namespace Code.Extensions.Configurations
{
    public class ConfigureKestrelOptions : IConfigureNamedOptions<KestrelServerOptions>
    {
        public void Configure(string? name, KestrelServerOptions options)
        {
            Configure(options);
        }

        public void Configure(KestrelServerOptions options)
        {
            options.ListenAnyIP(5030, listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
            });

            options.ListenAnyIP(7024, listenOptions =>
            {
                listenOptions.UseHttps();
                listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
            });
        }
    }
}