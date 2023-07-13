namespace SimpleCLIGameLauncher;

public class Game
{
    public int GameId { get; set; }
    public string? GameName { get; set; }
    public string? GameDeveloper { get; set; }
    public string? GameReleaseDate { get; set; }
    public string? GameGenre { get; set; }
    public string? GameType { get; set; }
    public string? GamePath { get; set; }

    public override string ToString()
    {
        return "Game ID: " + GameId + "\nGame Name: " + GameName + "\nGame Developer: " + GameDeveloper +
               "\nGame Release Date: " + GameReleaseDate + "\nGame Genre: " + GameGenre +
               "\nGame Type: " + GameType + "\nGame Path: " + GamePath;
    }
}