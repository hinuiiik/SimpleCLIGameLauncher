namespace SimpleGameLauncher
{
    class Sgl
    {
        public static void Main(String[] args)
        {

            if (args != null && args.Length != 0)
            {
                // with params launch game num
                Console.WriteLine("args");
            }
            // no params
            else
            {
//                Console.WriteLine("Control+C to exit\n" +
//                                  "[add],[remove], or [edit] a game...");
//                Console.WriteLine("");
//                Console.Write("Enter a game number: ");
//                //ControlActions.Run(Convert.ToInt32(Console.ReadLine()));
//
//                var osu = new Game("osu!", "/home/gwargoomba/Coding/echo.sh", 1);
//                Console.WriteLine(osu.ID);

                // Database shenanigans
                if (!File.Exists("GameDB.sqlite"))
                {
                    Console.WriteLine("Checking if an initial Games database exists.");
                    SqliteData.CreateDatabase();
                }
                else{Console.WriteLine("Database exists... Continuing...");}
                
                // remove later
                SqliteData.AddTestGame();
            }
        }
    }
    
}