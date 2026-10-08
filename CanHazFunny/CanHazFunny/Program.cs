namespace CanHazFunny;

class Program
{
    /// <summary>
    /// The main entry point of the application. This method initializes the JokeService and ConsoleOutputService, creates a Jester instance, and tells a joke by fetching it from the external API.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        //contact joke api and get joke
        IJokeService jokeService = new JokeService();
        IOutputService outputService = new ConsoleOutputService();
        
        //Create a Jester instance and tell a joke
        Jester jester = new(jokeService, outputService);
        jester.TellJoke();
    }
}
