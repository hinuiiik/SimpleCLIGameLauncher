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
            Console.WriteLine("Game ID: " + game.GameId);
            Console.WriteLine("Game Name: " + game.GameName);
            Console.WriteLine("Game Developer: " + game.GameDeveloper);
            Console.WriteLine("Game Release Date: " + game.GameReleaseDate);
            Console.WriteLine("Game Genre: " + game.GameGenre);
            Console.WriteLine("Game Type: " + game.GameType);
            Console.WriteLine("Game Path: " + game.GamePath);
            Console.WriteLine();
        }
    }
    public static void Add(string? gameName, string? developer, string? date, string? genre, string? type, string? path)
    {
        SqliteData.AddGame(gameName, developer, date, genre, type, path);
    }
    public static void Remove(int num)
    {
        
    }
    public static void Edit(int num)
    {
        
    }
}

public class Game
{
    public int GameId { get; set;  }
    public string? GameName { get; set; }
    public string? GameDeveloper { get; set; }
    public string? GameReleaseDate { get; set; }
    public string? GameGenre { get; set; }
    public string? GameType { get; set; }
    public string? GamePath { get; set; }
    
}