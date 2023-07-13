using System.Data.SQLite;

namespace SimpleCLIGameLauncher;

public static class SqliteData
{
    private static readonly string DataPath = Configuration.DataDir;

    public static void CreateDatabase()
    {
        if (File.Exists(Path.Combine(Configuration.DataDir, "GameDB.sqlite"))) return;
        Console.WriteLine("Creating Database...");
        // Create a new SQLite database file
        SQLiteConnection.CreateFile($"{DataPath}/GameDB.sqlite");

        // Connect to the database
        using var connection = new SQLiteConnection($"Data Source={DataPath}/GameDB.sqlite");
        //var connection = new SQLiteConnection($"Data Source={DataPath}/GameDB.sqlite;Version=3;");
        connection.Open();

        // Create a Games table
        const string createTableSql = "CREATE TABLE Games (GameID INTEGER PRIMARY KEY, GameName TEXT, Developer TEXT, ReleaseDate DATE, Genre TEXT, Type TEXT, FilePath TEXT)";
        var createTableCmd = new SQLiteCommand(createTableSql, connection);
        createTableCmd.ExecuteNonQuery();

        // Close the database connection
        connection.Close();
    }

    public static void AddGame(string? gameName, string? developer, string? date, string? genre, string? type,
        string? path) // method for adding sample data
    {
        using var connection = new SQLiteConnection($"Data Source={DataPath}/GameDB.sqlite");
        connection.Open();

        // var command = connection.CreateCommand();

        // Insert game data
        const string insertSql = "INSERT INTO Games (GameName, Developer, ReleaseDate, Genre, Type, FilePath) VALUES (@GameName, @Developer, @ReleaseDate, @Genre, @Type, @FilePath)";
        var insertGame = new SQLiteCommand(insertSql, connection);
        insertGame.Parameters.AddWithValue("@GameName", gameName);
        insertGame.Parameters.AddWithValue("@Developer", developer);
        insertGame.Parameters.AddWithValue("@ReleaseDate", date);
        insertGame.Parameters.AddWithValue("@Genre", genre);
        insertGame.Parameters.AddWithValue("@Type", type);
        insertGame.Parameters.AddWithValue("@FilePath", path);
        insertGame.ExecuteNonQuery();
        connection.Close();
    }

    public static void EditGame(int id, string? gameName, string? developer, string? date, string? genre, string? type,
        string? path) // has to replace all at once
    {
        using var connection = new SQLiteConnection($"Data Source={DataPath}/GameDB.sqlite");
        connection.Open();

        const string editSql = "UPDATE Games SET GameName = @GameName, Developer = @Developer, ReleaseDate = @GameDate, " +
                               "Genre = @GameGenre, Type = @GameType, FilePath = @GamePath WHERE GameID = @Id";
        var editGame = new SQLiteCommand(editSql, connection);
        editGame.Parameters.AddWithValue("@Id", id);
        editGame.Parameters.AddWithValue("@GameName", gameName);
        editGame.Parameters.AddWithValue("@Developer", developer);
        editGame.Parameters.AddWithValue("@GameDate", date);
        editGame.Parameters.AddWithValue("@GameGenre", genre);
        editGame.Parameters.AddWithValue("@GameType", type);
        editGame.Parameters.AddWithValue("@GamePath", path);
        editGame.ExecuteNonQuery();
        connection.Close();
    }

    public static void RemoveGame(int? gameId)
    {
        using var connection = new SQLiteConnection($"Data Source={DataPath}/GameDB.sqlite");
        connection.Open();

        // var command = connection.CreateCommand();

        // remove game data
        const string insertSql = "DELETE FROM Games where GameID = @GameID";
        var removeGame = new SQLiteCommand(insertSql, connection);
        removeGame.Parameters.AddWithValue("@GameID", gameId);
        removeGame.ExecuteNonQuery();
        connection.Close();
    }

    public static List<Game> GetAllGames()
    {
        var games = new List<Game>();

        using var connection = new SQLiteConnection($"Data Source={DataPath}/GameDB.sqlite");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM Games";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var game = new Game
            {
                GameId = reader.GetInt32(0),
                GameName = reader.GetString(1),
                GameDeveloper = reader.GetString(2),
                GameReleaseDate = reader.GetString(3),
                GameGenre = reader.GetString(4),
                GameType = reader.GetString(5),
                GamePath = reader.GetString(6)
            };

            games.Add(game);
        }

        return games;
    }

    // public static int NumOfGames()
    // {
    //     using (var connection = new SQLiteConnection($"Data Source={DataPath}/GameDB.sqlite"))
    //     {
    //         connection.Open();
    //
    //         var command = connection.CreateCommand();
    //         command.CommandText = @"SELECT COUNT(*) from Games";
    //
    //         using (var reader = command.ExecuteReader())
    //         {
    //             while (reader.Read())
    //             {
    //                 return reader.GetInt32(0);
    //             }
    //         }
    //     }
    //     return 0;
    // }

    public static Game GetGameById(int gameId)
    {
        using var connection = new SQLiteConnection($"Data Source={DataPath}/GameDB.sqlite");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM Games WHERE GameID = @gameID LIMIT 1";
        command.Parameters.AddWithValue("@gameID", gameId);
        using var reader = command.ExecuteReader();
        if (reader.Read())
            return new Game
            {
                GameId = reader.GetInt32(0),
                GameName = reader.GetString(1),
                GameDeveloper = reader.GetString(2),
                GameReleaseDate = reader.GetString(3),
                GameGenre = reader.GetString(4),
                GameType = reader.GetString(5),
                GamePath = reader.GetString(6)
            };
        // Handle the case where no game was found with the specified ID
        throw new Exception($"No game found with ID {gameId}");
    }
}