using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using AGL.Api.ApplicationCore;
using AGL.Api.Infrastructure;
using AGL.Api.ApplicationCore.Middleware;
using AGL.Api.ApplicationCore.Utilities;
using SecondSampleApi.Extensions.Configurations;
using Microsoft.AspNetCore.Mvc;
using SecondSampleApi.Middlewares;
using SecondSampleApi.Extensions;
using SecondSampleApi.HostedService;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var configuration = builder.Configuration;

// ## (공통) ApplicationCore 서비스 ##
builder.Services.AddControllerSerivce();
builder.Services.AddCustomService();
builder.Services.AddApplicationCore();
builder.Services.AddInfrastructure(configuration);
builder.Services.AddCommonDependencyInjection();

// ## (프로젝트 종속) 서비스 ##
builder.Services.AddHttpContextAccessor();
builder.Services.AddOptions();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 프로젝트 DI 등록 확장메서드
builder.Services.AddProjectDependencyInjection();

// 프로젝트 옵션 등록 확장메서드
builder.Services.AddProjectOptions(configuration);

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1.0);
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

// Warm up Hosted service add
builder.Services.AddHostedService<WarmUpHostedService>();

// Logger configuration
builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration);
});

var app = builder.Build();

// 프로젝트 미들웨어 등록 확장메서드
app.AddProjectMiddlewares();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        IReadOnlyList<ApiVersionDescription> descriptions = app.DescribeApiVersions();
        foreach (ApiVersionDescription description in descriptions)
        {
            string url = $"/swagger/{description.GroupName}/swagger.json";
            string name = description.GroupName.ToUpperInvariant();

            options.SwaggerEndpoint(url, name);
        }
    });

    app.MapGet("/", context =>
    {
        context.Response.Redirect("/swagger");
        return Task.CompletedTask;
    });
}

app.UseHsts();
app.UseHttpsRedirection();
app.UseCors("default");

app.MapControllers();

app.Logger.LogInformation("Starting GDS30_API - SecondSampleApi host...");

app.Run(); 