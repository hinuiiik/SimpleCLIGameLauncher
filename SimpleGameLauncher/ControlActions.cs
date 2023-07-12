using System.Diagnostics;

namespace SimpleGameLauncher;

public static class ControlActions
{
    public static void Run(int num)
    {
        try
        {
            var game = SqliteData.GetGameById(num);

            Process.Start(game.GamePath ?? throw new InvalidOperationException());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error running game: {ex.Message}");
        }
    }

    public static void List()
    {
        var games = SqliteData.GetAllGames();

        foreach (var game in games)
        {
            Console.WriteLine(game);
            Console.WriteLine("-------------------------");
        }
    }

    public static void Add(string? gameName, string? developer, string? date, string? genre, string? type, string? path)
    {
        SqliteData.AddGame(gameName, developer, date, genre, type, path);
    }

    public static void Remove(int num)
    {
        SqliteData.RemoveGame(num);
    }

    public static void Edit(int num)
    {
    }
}