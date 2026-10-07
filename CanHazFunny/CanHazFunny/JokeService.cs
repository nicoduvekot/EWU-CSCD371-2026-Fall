using System.Net.Http;

namespace CanHazFunny;

// Core 2: the JokeService will need to have the interface applied to it
public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
        return joke;
    }
}
