using System.Diagnostics;

namespace SimpleGameLauncher
{
    class Sgl
    {
        public static void Main(String[] args)
        {
            // Creating config files if necessary
            Configuration.FirstLaunch();
                
            // remove later
            //SqliteData.AddTestGame();
            
            ControlActions.List();
            
             // Console.WriteLine("Control+C to exit\n" +
             //     "[add],[remove], or [edit] a game...");
             // Console.WriteLine("");
             Console.Write("Enter a game number: ");
             ControlActions.Run(Convert.ToInt32(Console.ReadLine()));

        }
    }
    
}