using CommandLine;

namespace SimpleGameLauncher
{
        public static class Sgl
        {
            public static void Main(string[] args)
            {
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
            foreach (var error in errors)
            {
                Console.WriteLine(error.ToString());
            }
        }
    }

    // Command-line options for the --add argument
    [Verb("add", HelpText = "Add a game.")]
    public class AddOptions
    {
        [Option('n', "name", Required = true, HelpText = "Game name.")]
        public string? Name { get; set; }

        [Option('d', "developer", Required = true, HelpText = "Game developer.")]
        public string? Developer { get; set; }

        [Option('r', "date", Required = true, HelpText = "Release date.")]
        public string? Date { get; set; }

        [Option('g', "genre", Required = true, HelpText = "Game genre.")]
        public string? Genre { get; set; }

        [Option('t', "type", Required = true, HelpText = "Game type.")]
        public string? Type { get; set; }

        [Option('p', "path", Required = true, HelpText = "Game path.")]
        public string? Path { get; set; }
    }

    // Command-line options for the --list argument
    [Verb("list", HelpText = "List all games.")]
    public class ListOptions
    {
    }

    // Command-line options for the --remove argument
    [Verb("remove", HelpText = "Remove a game.")]
    public class RemoveOptions
    {
        [Option('i', "id", Required = true, HelpText = "Game ID.")]
        public int Id { get; set; }
    }
    
    [Verb("run", HelpText = "Run a game.")]
    public class RunOptions
    {
        [Option('i', "id", Required = true, HelpText = "Game ID.")]
        public int Id { get; set; }
    }
}