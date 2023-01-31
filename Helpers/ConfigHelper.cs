namespace IWantApp.Helpers;
public class ConfigHelper
{
    private static string GetConfig(string key, bool isConnectionString = false)
    {
        var appSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        if (isConnectionString)
            return appSettings.GetSection("ConnectionString")[key];

        return appSettings.GetSection("AppSettings")[key];
    }

    public static string ConnectionString()
    {
        var value = GetConfig("IWantDb", true);
        return value;
    }

    public static string SecretKey()
    {
        return GetConfig("SecretKey");
    }

    public static string Audience()
    {
        return GetConfig("Audience");
    }

    public static string Issuer()
    {
        return GetConfig("Issuer");
    }

    public static int ExpiryTimeInSeconds()
    {
        return Convert.ToInt32(GetConfig("ExpiryTimeInSeconds"));
    }
}
