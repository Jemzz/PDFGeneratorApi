using Microsoft.Extensions.Configuration; 

namespace PDF.Core.Utilities;

public class ConfigurationHelper
{
    private static ConfigurationHelper? _appSettings;

    public string appSettingValue { get; set; }

    public static string AppSetting(string Key)
    {
        _appSettings = GetCurrentSettings(Key);
        return _appSettings?.appSettingValue ?? "";
    }

    public ConfigurationHelper(IConfiguration config, string Key)
    {
        this.appSettingValue = config.GetValue<string>(Key);
    }

    public static ConfigurationHelper? GetCurrentSettings(string Key)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        IConfigurationRoot configuration = builder.Build();

        var settings = new ConfigurationHelper(configuration, Key);

        return settings;
    }
}