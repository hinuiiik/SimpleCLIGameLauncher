using System.Runtime.InteropServices;

namespace SimpleGameLauncher;

public static class Configuration
{
    public static string DataDir { get; set; } = Path.Combine(Environment.GetFolderPath(
        Environment.SpecialFolder.LocalApplicationData,
        Environment.SpecialFolderOption.Create), "SimpleGameLauncher");

    public static string ConfigDir { get; set; } = Path.Combine(Environment.GetFolderPath(
        Environment.SpecialFolder.ApplicationData,
        Environment.SpecialFolderOption.Create), "SimpleGameLauncher");

    public static LauncherPlatform Platform { get; set; } = GetPlatform();

    private static LauncherPlatform GetPlatform()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return LauncherPlatform.Windows;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return LauncherPlatform.Linux;

        return LauncherPlatform.Unsupported;
    }
}