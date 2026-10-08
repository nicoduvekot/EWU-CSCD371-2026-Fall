using System;

namespace CanHazFunny;

// Core 4: Implement the jester class - it should take both interfaces as dependencies. These are null checked.
public class Jester(IJokeService jokeService, IOutputService outputService)
{
    private readonly IJokeService _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
    private readonly IOutputService _outputService = outputService ?? throw new ArgumentNullException(nameof(outputService));

    // Core 5: the jester class TellJoke() should:
    // retrieve a joke from the jokeService
    // SeeJokeService : if the joke contains - ChuckNorris, skip it and get another
    // this joke should be written to the output dependency
    public void TellJoke()
    {
        string joke = _jokeService.GetJoke();
        _outputService.Output(joke);
    }
}