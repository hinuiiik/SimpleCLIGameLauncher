namespace SimpleGameLauncher;

public class Game
{
    public Guid ID {get; private set; }
    public string GameAddress {get; set;}
    public string GameName{get; set;}
    public int GameId{get; set;}

    public Game(string gameName, string gameAddress, int gameId)
    {
        this.GameAddress = gameAddress;
        this.GameName = gameName;
        this.GameId = gameId;
        this.ID = Guid.NewGuid();
    }

}