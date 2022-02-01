using System;

namespace CanHazFunny
{
    public class Jester
    {
        private JokeService _jokeService;
        private PrintService? _printService;
        private string? _joke;

        public Jester(JokeService jokeServ, PrintService printServ)
        {
            _jokeService = jokeServ ?? throw new ArgumentNullException(nameof(jokeServ));
            _printService = printServ ?? throw new ArgumentNullException(nameof(printServ));
        }

        
        public void TellJoke()
        {
            do
            {
                _joke = _jokeService.GetJoke();
            }
            while (_joke.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase));

            _printService!.Print(_joke);
        }

    }
}
