using System;

namespace CanHazFunny;

public class Jester
{
    public Jester(IJokeOutput jokeOutput, IJokeService jokeService)
    {
        JokeOutput = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));
        JokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
    }

    public IJokeOutput JokeOutput { get; }
    public IJokeService JokeService { get; }

    public string? Joke { get; set; }

    public virtual void TellJoke()
    {
        do
        {

            Joke = JokeService.GetJoke();

        } while (Joke.Contains("Chuck Norris"));
        
        JokeOutput.TellJoke(Joke);

    }
    
}
