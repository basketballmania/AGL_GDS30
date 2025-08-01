using Microsoft.Extensions.Configuration;
using Serilog;

namespace AGL.Api.ApplicationCore.Utilities
{
    public static class LogService
    {
        public static void InitLogger()
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "noEnv";


            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // 기본 설정 파일 로드
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true) // 환경별 설정 파일 로드
                .Build();


            //var logFilePath = configuration["Serilog:LogFilePath"];
            //Log.Logger = new LoggerConfiguration()
            //    //.MinimumLevel.Verbose()
            //    .Enrich.FromLogContext()
            //    .WriteTo.Console()
            //    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
            //    .ReadFrom.Configuration(configuration)
            //    .CreateLogger();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }


        public static void logVerbose(string message)
        {
            InitLogger();
            Log.Verbose(message);
            Log.CloseAndFlush();
        }

        public static void logDebug(string message)
        {
            InitLogger();
            Log.Debug(message);
            Log.CloseAndFlush();
        }

        public static void logInformation(string message)
        {
            InitLogger();
            Log.Information(message);
            Log.CloseAndFlush();
        }

        public static void logWarning(string message)
        {
            InitLogger();
            Log.Warning(message);
            Log.CloseAndFlush();
        }

        public static void logError(string message)
        {
            InitLogger();
            Log.Error(message);
            Log.CloseAndFlush();
        }

        public static void logFatal(string message)
        {
            InitLogger();
            Log.Fatal(message);
            Log.CloseAndFlush();
        }

        private static readonly object lockObject = new object();
        public static void logCustom(string message)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "noEnv";
            try
            {
                DateTime kstTime = DateTime.UtcNow.AddHours(9);

                string fullPath = Path.Combine($"C:\\AGL\\Logs\\OpenAPI\\{environment}\\HTT", "PAY");
                string fileName = Path.Combine(fullPath, $"HTT-PAY-{kstTime:yyyyMMdd}.log");

                Directory.CreateDirectory(fullPath);

                lock (lockObject)
                {
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine($"{kstTime:yyyy-MM-dd HH:mm:ss.fff} +09:00  INF  {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                // 예외 처리는 필요한 경우에 맞게 수정해주세요.
                Console.WriteLine(ex.Message);
            }
        }

    }
}