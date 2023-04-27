namespace SimpleGameLauncher;

public sealed class Configuration {
  public static string Datadir()
  {
      // other XDG_DATA_HOME dir set
      if(!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("%XDG_DATA_HOME%/SimpleGameLauncher")))
      {
          return Environment.ExpandEnvironmentVariables("%XDG_DATA_HOME%/SimpleGameLauncher");
      }
      else
      {
          // defaulting to the user's home
          return Environment.ExpandEnvironmentVariables("%HOME%/.local/share/SimpleGameLauncher");
      }
  }
}