using System;

namespace CanHazFunny
{
    public class Jester
    {
        private JokeService jokeService;
        private JokeOutput jokeOutput;

        public Jester(JokeService jokeService, JokeOutput jokeOutput)
        {
            this.jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
            this.jokeOutput = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));
        }

        public void TellJoke()
        {
            string joke = jokeService.GetJoke();

            while (joke.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase))
                joke = jokeService.GetJoke();

            jokeOutput.PrintJoke(joke);
        }
    }
}
