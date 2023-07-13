using CommandLine;

namespace SimpleCLIGameLauncher;

public static class Sgl
{
    public static void Main(string[] args)
    {
        // create directory and database if not already created
        Directory.CreateDirectory(Configuration.DataDir);
        Directory.CreateDirectory(Configuration.ConfigDir);
        SqliteData.CreateDatabase();

        Parser.Default.ParseArguments<AddOptions, ListOptions, RunOptions, RemoveOptions, EditOptions>(args)
            .WithParsed<AddOptions>(RunAdd)
            .WithParsed<ListOptions>(RunList)
            .WithParsed<RemoveOptions>(RunRemove)
            .WithParsed<RunOptions>(RunRun)
            .WithParsed<EditOptions>(RunEdit);
        //.WithNotParsed(HandleParseError);
    }

    private static void RunAdd(AddOptions options)
    {
        ControlActions.Add(options.Name, options.Developer, options.Date, options.Genre, options.Type, options.Path);
    }

    private static void RunList(ListOptions options)
    {
        ControlActions.List();
    }

    private static void RunRemove(RemoveOptions options)
    {
        ControlActions.Remove(options.Id);
    }

    private static void RunRun(RunOptions options)
    {
        ControlActions.Run(options.Id);
    }
    
    private static void RunEdit(EditOptions options)
    {
        ControlActions.Edit(options.Id, options.Name, options.Developer, options.Date, options.Genre, options.Type, options.Path);
    }

    // private static void HandleParseError(IEnumerable<Error> errors)
    // {
    //     // Handle command-line argument parsing errors
    //     foreach (var error in errors) Console.WriteLine(error.ToString());
    // }
}