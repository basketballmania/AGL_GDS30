using API_Gateway;
using API_Gateway.Extensions.Configurations;
using API_Gateway.Middlewares;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<RequestValidationMiddleware>();

// ocelot.json 변수 값을 실행된 환경변수로 치환
var apiConfigs = builder.Configuration.GetSection("API").Get<List<ApiConfig>>();

if (apiConfigs == null || apiConfigs.Count == 0)
{
    throw new Exception("ApiConfig cannot be null. Update API section in appsettings.json file.");
}

var ocelotJosnFile = "ocelot.json";
var ocelotJson = File.ReadAllText(ocelotJosnFile);

foreach (var api in apiConfigs)
{
    ocelotJson = ocelotJson
        .Replace($"{{{api.Name}.Host}}", api.Host)
        .Replace($"{{{api.Name}.Port}}", api.Port.ToString());
}

File.WriteAllText("ocelot.temp.json", ocelotJson);
builder.Configuration.AddJsonFile("ocelot.temp.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot();
builder.Services.ConfigureOptions<ConfigureKestrelOptions>();

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();

app.UseMiddleware<RequestValidationMiddleware>();

await app.UseOcelot();

app.Run();
