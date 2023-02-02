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


    public static string SecretKey
    {
        get
        {
            try
            {
                return GetConfig("SecretKey");
            }
            catch
            {
                return "A@fderwfQQSDXCCer34";
            }
        }
    }


    public static string Audience
    {
        get
        {
            try
            {
                return GetConfig("Audience");
            }
            catch
            {
                return "Audience";
            }
        }
    }

    public static string Issuer
    {
        get
        {
            try
            {
                return GetConfig("Issuer");
            }
            catch
            {
                return "IWantAppIssuer";
            }
        }
    }

    public static int ExpiryTimeInSeconds
    {
        get
        {
            try
            {
                return Convert.ToInt32(GetConfig("ExpiryTimeInSeconds"));
            }
            catch
            {
                return 60;
            }
        }
    }
}
