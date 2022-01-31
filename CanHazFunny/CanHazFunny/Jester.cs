using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        // Implement the Jester class. It should take in both interfaces as dependencies.
        // These dependencies should be null checked.
        private readonly DisplayService _displayService;
        private readonly JokeService _jokeService;

        public Jester(DisplayService? displayService, JokeService? jokeService)
        {
            if (displayService == null)
            {
                throw new ArgumentNullException(nameof(displayService)); // verify this is the right way to check
            }
            if (jokeService == null)
            {
                throw new ArgumentNullException(nameof(jokeService)); // verify this is the right way to check
            }
            _displayService = displayService;
            _jokeService = jokeService;
        }

        // The Jester class TellJoke() method should retrieve a joke from the JokeService.
        // If the joke contains "Chuck Norris", skip it and get another.
        // The joke should be written to the output dependency.

        public void TellJoke()
        {
            // loop to get non chuck norrris joke
            string validatedJoke = "";
            bool jokeIsValid = false;

            int jokeCount = 0; // for testing purposes only
            while (!jokeIsValid)
            {
                jokeCount++; // for testing purposes only 
                string unvalidatedJoke = _jokeService.GetJoke();
                if (!unvalidatedJoke.Contains("Chuck Norris"))
                {
                    validatedJoke = unvalidatedJoke;
                    jokeIsValid = true;
                }
            }

            _displayService.Display(validatedJoke);

        }
    }
}
