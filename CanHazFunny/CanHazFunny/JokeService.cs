using System;
using System.Net.Http;

namespace CanHazFunny;

// Core 2: the JokeService will need to have the interface applied to it
public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string joke;

        do
        {
            joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
        } 
        while (ContainsChuckNorris(joke));
        
        return joke;
    }

    public bool ContainsChuckNorris(string joke)
    {
        return joke.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase);
    }
}
