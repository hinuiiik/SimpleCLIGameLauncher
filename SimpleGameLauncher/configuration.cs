using System.Net;
using System.Runtime.InteropServices;

namespace SimpleGameLauncher;
using Tomlyn;

public sealed class Configuration {
    public static String DataDir { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, 
        Environment.SpecialFolderOption.Create), "SimpleGameLauncher");
    public static String ConfigDir { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, 
        Environment.SpecialFolderOption.Create), "SimpleGameLauncher");
    public static int Platform { get; set; } = GetPlatform();
    
    private static int GetPlatform()
    {
        if (RuntimeInformation.IsOSPlatform((OSPlatform.Linux)))
        {
            return 0;
        }
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return 1;
        }
        throw new Exception("Unknown/Unsupported platform.");
    }
}