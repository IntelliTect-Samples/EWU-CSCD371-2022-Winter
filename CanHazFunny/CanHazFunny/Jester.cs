using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        private JokeService jokeService;
        private PrintService printService;

        public Jester(JokeService jokeServ, PrintService printServ)
        {
            jokeService = jokeServ ?? throw new ArgumentNullException(nameof(jokeServ));
            printService = printServ ?? throw new ArgumentNullException(nameof(printServ));
        }

        
        public void TellJoke()
        {
            string joke = "Chuck Norris"; // purposefully bad

            do
            {
                joke = jokeService.GetJoke();
            }
            while (joke.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase));

            printService.Print(joke);
        }

    }
}
