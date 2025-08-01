using AGL.Api.ApplicationCore.Handler;
using AGL.Api.ApplicationCore.Interfaces;
using AGL.Api.ApplicationCore.Mapping;
using AGL.Api.ApplicationCore.Middleware;
using AGL.Api.ApplicationCore.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.WebEncoders;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Security.Authentication;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace AGL.Api.ApplicationCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        // ## (공통) 의존성 주입 ##
        public static void AddCommonDependencyInjection(this IServiceCollection service)
        {
            // <!-- SCOPED SERVICES ----->

            // <!-- TRANSIENT SERVICES -->
            service.AddTransient<GlobalExceptionHandler>();
            service.AddTransient<HttpClientRequestIdDelegatingHandler>();
            service.AddTransient<IIdentifiable, Identifiable>();
            service.AddTransient<LoggerMiddleware>();

            // <!-- SINGLETON SERVICES -->
            service.AddSingleton<IIdentityService, IdentityService>();
        }
    }

    public static class CustomExtensionsMethods
    {
        public static void AddControllerSerivce(this IServiceCollection service)
        {
            service.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.UseCamelCasing(true);
            });
        }

        public static void AddCustomService(this IServiceCollection service)
        {
            // ## CORS 설정 ##
            service.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // ## Custom HttpClient 설정 ##
            service.AddHttpClient<IApiClient, ApiClient>(client =>
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
			{
				// TLS 1.2 강제 설정
				SslProtocols = SslProtocols.Tls13 | SslProtocols.Tls12,
			}).AddHttpMessageHandler<HttpClientRequestIdDelegatingHandler>();

            // 한글이 인코딩되는 문제 해결
            service.Configure<WebEncoderOptions>(options =>
            {
                options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
            });
        }
    }
}
