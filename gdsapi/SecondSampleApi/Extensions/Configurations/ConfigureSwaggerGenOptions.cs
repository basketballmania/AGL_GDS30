using System.Reflection;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SecondSampleApi.Extensions.Configurations
{
    public class ConfigureSwaggerGenOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (ApiVersionDescription description in _provider.ApiVersionDescriptions)
            {
                var openApiInfo = new OpenApiInfo
                {
                    Title = $"Reservation.Api v{description.ApiVersion}",
                    Version = description.ApiVersion.ToString()
                };

                options.SwaggerDoc(description.GroupName, openApiInfo);
            }

            // XML 주석 추가
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
            
            var securityDefinitions = new Dictionary<string, OpenApiSecurityScheme>
            {
                {
                    "Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                    }
                },
                {
                    "ClientId", new OpenApiSecurityScheme
                    {
                        Name = "ClientId",
                        Type = SecuritySchemeType.ApiKey,
                        In = ParameterLocation.Header,
                    }
                },
                {
                    "Currency", new OpenApiSecurityScheme
                    {
                        Name = "Currency",
                        Type = SecuritySchemeType.ApiKey,
                        In = ParameterLocation.Header,
                    }
                },
                {
                    "Language", new OpenApiSecurityScheme
                    {
                        Name = "Language",
                        Type = SecuritySchemeType.ApiKey,
                        In = ParameterLocation.Header,
                    }
                }
            };

            // 보안 정의 추가
            foreach (var definition in securityDefinitions)
            {
                options.AddSecurityDefinition(definition.Key, definition.Value);
            }

            // 보안 요구 사항 추가
            var securityRequirement = new OpenApiSecurityRequirement();
            foreach (var definition in securityDefinitions)
            {
                securityRequirement.Add(new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = definition.Key
                    }
                }, []);
            }

            options.AddSecurityRequirement(securityRequirement);
        }
    }
}