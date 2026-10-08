using System;
using System.Net.Http;

namespace CanHazFunny;

// Core 2: the JokeService will need to have the interface applied to it
public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; }

    public JokeService() : this(new HttpClient()) { }

    public JokeService(HttpClient httpClient)
    {
        HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public string GetJoke()
    {
        return HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
    }
}
