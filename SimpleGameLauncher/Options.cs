using CommandLine;

namespace SimpleGameLauncher;

// Command-line options for the --run argument
[Verb("run", HelpText = "Run a game.")]
public class RunOptions
{
    [Option('i', "id", Required = true, HelpText = "Game ID.")]
    public int Id { get; set; }
}

// Command-line options for the --remove argument
[Verb("remove", HelpText = "Remove a game.")]
public class RemoveOptions
{
    [Option('i', "id", Required = true, HelpText = "Game ID.")]
    public int Id { get; set; }
}

// Command-line options for the --list argument
[Verb("list", HelpText = "List all games.")]
public class ListOptions
{
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