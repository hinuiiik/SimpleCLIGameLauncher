namespace SimpleGameLauncher;
using System.Data.SQLite;

public static class SqliteData
{
    private static readonly string Datapath = Configuration.DataDir;
    
    public static void CreateDatabase()
    {
        Console.WriteLine("Creating Database...");
        // Create a new SQLite database file
        SQLiteConnection.CreateFile($"{Datapath}/GameDB.sqlite");

        // Connect to the database
        SQLiteConnection connection = new SQLiteConnection($"Data Source={Datapath}/GameDB.sqlite;Version=3;");
        connection.Open();

        // Create a Games table
        string createTableSql = "CREATE TABLE Games (GameID INTEGER PRIMARY KEY, GameName TEXT, Developer TEXT, ReleaseDate DATE, Genre TEXT, Type TEXT, FilePath TEXT)";
        SQLiteCommand createTableCmd = new SQLiteCommand(createTableSql, connection);
        createTableCmd.ExecuteNonQuery();

        // Close the database connection
        connection.Close();
    }

    public static void AddTestGame() // method for adding sample data
    {
        using (var connection = new SQLiteConnection($"Data Source={Datapath}/GameDB.sqlite")) {
            connection.Open();

            // var command = connection.CreateCommand();

            // Insert sample game data
            string insertSql = "INSERT INTO Games (GameName, Developer, ReleaseDate, Genre, Type, FilePath) VALUES (@GameName, @Developer, @ReleaseDate, @Genre, @Type, @FilePath)";
            SQLiteCommand insertGame = new SQLiteCommand(insertSql, connection);
            insertGame.Parameters.AddWithValue("@GameName", "Test Game");
            insertGame.Parameters.AddWithValue("@Developer", "Testing Co.");
            insertGame.Parameters.AddWithValue("@ReleaseDate", "2023-4-27");
            insertGame.Parameters.AddWithValue("@Genre", "Simulation");
            insertGame.Parameters.AddWithValue("@Type", "Native");
            insertGame.Parameters.AddWithValue("@FilePath", "");
            insertGame.ExecuteNonQuery();
            connection.Close();
        }
    }
    public static List<Game> GetAllGames()
    {
        List<Game> games = new List<Game>();

        using (var connection = new SQLiteConnection($"Data Source={Datapath}/GameDB.sqlite"))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Games";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Game game = new Game()
                    {
                        GameId = reader.GetInt32(0),
                        GameName = reader.GetString(1),
                        GameDeveloper = reader.GetString(2),
                        GameReleaseDate = reader.GetString(3),
                        GameGenre= reader.GetString(4),
                        GameType = reader.GetString(5),
                        GamePath = reader.GetString(6),
                    };

                    games.Add(game);
                }
            }
        }

        return games;
    }

        // public static int NumOfGames()
        // {
        //     using (var connection = new SQLiteConnection($"Data Source={Datapath}/GameDB.sqlite"))
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
            using (var connection = new SQLiteConnection($"Data Source={Datapath}/GameDB.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM Games WHERE GameID = @gameID LIMIT 1";
                command.Parameters.AddWithValue("@gameID", gameId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Game()
                        {
                            GameId = reader.GetInt32(0),
                            GameName = reader.GetString(1),
                            GameDeveloper = reader.GetString(2),
                            GameReleaseDate = reader.GetString(3),
                            GameGenre= reader.GetString(4),
                            GameType = reader.GetString(5),
                            GamePath = reader.GetString(6),
                        };
                    }
                    else
                    {
                        // Handle the case where no game was found with the specified ID
                        throw new Exception($"No game found with ID {gameId}");
                        
                    }
                }
            }
        }
}
