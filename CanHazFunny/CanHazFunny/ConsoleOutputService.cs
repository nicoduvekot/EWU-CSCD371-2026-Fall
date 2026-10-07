using System;

namespace CanHazFunny;

public class ConsoleOutputService : IOutputService
{
    public void Output(string message)
    {
        Console.WriteLine(message);
    }
}