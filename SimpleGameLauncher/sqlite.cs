namespace SimpleGameLauncher;
using System.Data.SQLite;

class SqliteData
{
    private static string _datapath = Configuration.Datadir();
    
    public static void CreateDatabase()
    {
        Console.WriteLine("Creating Database...");
        // Create a new SQLite database file
        SQLiteConnection.CreateFile(_datapath + "/GameDB.sqlite");

        // Connect to the database
        SQLiteConnection connection = new SQLiteConnection("Data Source=" + _datapath + "/GameDB.sqlite;Version=3;");
        connection.Open();

        // Create a Games table
        string createTableSql = "CREATE TABLE Games (GameID INTEGER PRIMARY KEY, GameName TEXT, Developer TEXT, ReleaseDate DATE, Genre TEXT, Type TEXT, FilePath TEXT)";
        SQLiteCommand createTableCmd = new SQLiteCommand(createTableSql, connection);
        createTableCmd.ExecuteNonQuery();

        // Close the database connection
        connection.Close();
        Console.WriteLine("Database Created!");
    }
    
    public static void AddTestGame()
    {
        using var connection = new SQLiteConnection("Data Source=" + _datapath + "/GameDB.sqlite");
        connection.Open();
            
        var command = connection.CreateCommand();
            
        // Insert sample game data
        string insertSql = "INSERT INTO Games (GameName, Developer, ReleaseDate, Genre, Type, FilePath) VALUES (@GameName, @Developer, @ReleaseDate, @Genre, @Type, @FilePath)";
        SQLiteCommand insertGame = new SQLiteCommand(insertSql, connection);
        insertGame.Parameters.AddWithValue("@GameName", "Super Mario Bros.");
        insertGame.Parameters.AddWithValue("@Developer", "Nintendo");
        insertGame.Parameters.AddWithValue("@ReleaseDate", "1985-09-13");
        insertGame.Parameters.AddWithValue("@Genre", "Platformer");
        insertGame.Parameters.AddWithValue("@Type", "Emulator");
        insertGame.Parameters.AddWithValue("@FilePath", "C:\\Games\\SuperMarioBros.exe");
        insertGame.ExecuteNonQuery();
        connection.Close();
    }
}
