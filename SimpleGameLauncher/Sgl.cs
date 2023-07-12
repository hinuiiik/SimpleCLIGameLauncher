using CommandLine;

namespace SimpleGameLauncher;

public static class Sgl
{
    public static void Main(string[] args)
    {
        // create directory and database if not already created
        Directory.CreateDirectory(Configuration.DataDir);
        Directory.CreateDirectory(Configuration.ConfigDir);
        SqliteData.CreateDatabase();

        Parser.Default.ParseArguments<AddOptions, ListOptions, RunOptions, RemoveOptions>(args)
            .WithParsed<AddOptions>(RunAdd)
            .WithParsed<ListOptions>(RunList)
            .WithParsed<RemoveOptions>(RunRemove)
            .WithParsed<RunOptions>(RunRun);
        //.WithNotParsed(HandleParseError);
    }

    private static void RunAdd(AddOptions options)
    {
        // Call ControlActions.Add() with the provided values
        ControlActions.Add(options.Name, options.Developer, options.Date, options.Genre, options.Type, options.Path);
    }

    private static void RunList(ListOptions options)
    {
        // Call ControlActions.List()
        ControlActions.List();
    }

    private static void RunRemove(RemoveOptions options)
    {
        // Call ControlActions.Remove() with the provided ID
        ControlActions.Remove(options.Id);
    }

    private static void RunRun(RunOptions options)
    {
        ControlActions.Run(options.Id);
    }

    private static void HandleParseError(IEnumerable<Error> errors)
    {
        // Handle command-line argument parsing errors
        foreach (var error in errors) Console.WriteLine(error.ToString());
    }
}