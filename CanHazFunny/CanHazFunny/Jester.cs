using System;
namespace CanHazFunny;
public class Jester
{
    private IJokesOut? _JokesOut;
    private IJokeService? _JokeServices;

    public void TellJoke()
    {
        string? somejoke = _JokeServices?.GetJoke();
        while (somejoke != null && somejoke.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase))
        {
            somejoke = _JokeServices?.GetJoke();
        }
        _JokesOut?.PrintJoke(somejoke);
    }

    public Jester(IJokeService? jokeService, IJokesOut? jokesOut)
    {
        _JokeServices = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        _JokesOut = jokesOut ?? throw new ArgumentNullException(nameof(jokesOut));
    }
}