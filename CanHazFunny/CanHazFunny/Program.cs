namespace CanHazFunny;

class Program
{
    static void Main(string[] args)
    {
        IJokeService jokeService = new JokeService();
        IOutputService outputService = new ConsoleOutputService();
        
        Jester jester = new(jokeService, outputService);
        jester.TellJoke();
    }
}
