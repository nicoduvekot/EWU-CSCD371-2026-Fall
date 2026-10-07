using System;

namespace CanHazFunny;

public class Jester(IJokeService jokeService, IOutputService outputService)
{
    private readonly IJokeService _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
    private readonly IOutputService _outputService = outputService ?? throw new ArgumentNullException(nameof(outputService));

    public void TellJoke()
    {
        string joke = _jokeService.GetJoke();
        _outputService.Output(joke);
    }
}