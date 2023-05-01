namespace SimpleGameLauncher;
using Tomlyn;

public sealed class Configuration {
    public static String DataDir { get; set; } = XdgDataDir();
    public static String ConfigDir { get; set; } = XdgConfigDir();

    public static void FirstLaunch()
    {
        if(!Directory.Exists(DataDir))
        {
            Directory.CreateDirectory(DataDir);
            Console.WriteLine("Created Data Directory at " + DataDir);
        }
        if(!Directory.Exists(ConfigDir))
        {
            Directory.CreateDirectory(ConfigDir);
            Console.WriteLine("Created Config Directory at " + ConfigDir);
        }
        if (!File.Exists($"{DataDir}/GameDB.sqlite"))
        {
            SqliteData.CreateDatabase();
            Console.WriteLine("Created Game database.");
        }
    }

    private static string XdgDataDir()
    {
        // other XDG_DATA_HOME dir set
        if(!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("XDG_DATA_HOME")))
        {
            return Environment.ExpandEnvironmentVariables("%XDG_DATA_HOME%/SimpleGameLauncher");
        }
            // defaulting to the user's home
            return Environment.ExpandEnvironmentVariables("%HOME%/.local/share/SimpleGameLauncher");
    }

    private static string XdgConfigDir()
    {
        // other XDG_DATA_HOME dir set
        if(!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("XDG_CONFIG_HOME")))
        {
            return Environment.ExpandEnvironmentVariables("%XDG_CONFIG_HOME%/SimpleGameLauncher");
        }

        // defaulting to the user's home
        return Environment.ExpandEnvironmentVariables("%HOME%/.config/SimpleGameLauncher");
    }
}