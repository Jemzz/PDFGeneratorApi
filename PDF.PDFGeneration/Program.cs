using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Targets.Syslog;
using NLog.Web;
using System;
using System.Linq;
using PDF.Core.Options;
using LogLevel = NLog.LogLevel;

namespace PDF.PDFGeneration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            var host = CreateHostBuilder(args).Build();
            var config = host.Services.GetRequiredService<IConfiguration>();
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            GlobalDiagnosticsContext.Set("sender", $"PDF.pdfgeneration.{environment.ToLower()}");

            CustomiseLoggingConfiguration(config);

            LogManager.ConfigurationReloaded += (sender, e) => { CustomiseLoggingConfiguration(config); };

            try
            {
                logger.Debug("App starting");
                host.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }
        }

        private static void CustomiseLoggingConfiguration(IConfiguration configuration)
        {
            var loggingOptions = new LoggingOptions();
            configuration.GetSection(nameof(LoggingOptions)).Bind(loggingOptions);

            var nlogConfiguration = LogManager.Configuration;

            var syslogTarget = (SyslogTarget)nlogConfiguration.AllTargets
                .FirstOrDefault(x => x.Name == "syslogPaperTrail_wrapped");

            if (syslogTarget != null)
            {
                syslogTarget.MessageSend.Tcp.Server = loggingOptions.LogDestinationHost ?? "";
                syslogTarget.MessageSend.Tcp.Port = loggingOptions.LogDestinationPort ?? 0;
            }

            var msLogRule = nlogConfiguration.FindRuleByName("filterMicrosoftLogs");
            if (msLogRule != null)
            {
                var maxFilterLogLevel = LogLevel.FromString(loggingOptions.MicrosoftMaxFilterLevel ?? "Info");
                msLogRule.DisableLoggingForLevels(LogLevel.Trace, maxFilterLogLevel);
            }

            LogManager.Configuration = nlogConfiguration;

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development)
                {
                    logging.AddConsole();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                }
                else
                {
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Warning);
                }
            })
                .UseNLog(new NLogAspNetCoreOptions
                {

                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseStartup<Startup>()
                    .UseSetting("detailedErrors", "true")
                    .CaptureStartupErrors(true);
                });
    }
}
