using System.Diagnostics;

namespace SimpleGameLauncher;

public static class ControlActions
{
    public static void Run(int num)
    {
        try
        {
            Game game = SqliteData.GetGameById(num);

            Process.Start(game.GamePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error running game: {ex.Message}");
        }
    }
    public static void List()
    {
        List<Game> games = SqliteData.GetAllGames();
        
        foreach (Game game in games)
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
    public static void Add(int num)
    {
        
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
    public string GameName { get; set; }
    public string GameDeveloper { get; set; }
    public string GameReleaseDate { get; set; }
    public string GameGenre { get; set; }
    public string GameType { get; set; }
    public string GamePath { get; set; }
    
}