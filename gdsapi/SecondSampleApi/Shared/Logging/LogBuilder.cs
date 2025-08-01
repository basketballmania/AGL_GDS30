using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace SecondSampleApi.Shared.Logging
{
    public static class LogBuilder
    {
        public static async Task<object> CreateRequestInfoAsync(HttpContext context)
        {
            context.Request.Body.Position = 0;

            using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            context.Request.Body.Position = 0;

            var headers = context.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());

            return new
            {
                method = context.Request.Method,
                path = context.Request.Path,
                query = context.Request.QueryString.ToString(),
                contentType = context.Request.ContentType,
                host = context.Request.Host.ToString(),
                scheme = context.Request.Scheme,
                remoteIpAddress = context.Connection.RemoteIpAddress?.ToString(),
                userAgent = context.Request.Headers["User-Agent"].ToString(),
                headers,
                body = TryParseJsonOrRaw(body)
            };
        }

        public static object? TryParseJsonOrRaw(string text)
        {
            try { return JsonConvert.DeserializeObject(text); }
            catch { return text; }
        }
    }
}
