using Serilog;

namespace TestEngine.Core
{
    public class LoggingService
    {
        private readonly ILogger _logger;

        public LoggingService()
        {
            // Configure Serilog to log to both the console and a file
            _logger = new LoggerConfiguration()
               .WriteTo.Console()
               .MinimumLevel.Debug()
               .WriteTo.NUnitOutput()
               .WriteTo.File($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent}\\Logs\\TestReportLogging", rollingInterval: RollingInterval.Day)
               .CreateLogger();
        }

        public void LogInformation(string message)
        {
            _logger.Information(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warning(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogException(Exception ex, string message)
        {
            _logger.Error(ex, message);
        }
    }
}