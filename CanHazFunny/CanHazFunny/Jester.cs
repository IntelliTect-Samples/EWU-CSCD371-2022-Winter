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
        // These dependencies should be null checked

        private readonly IJokeService _jokeService;
        private readonly IConsoleDisplay _consoleDisplay;

        public Jester(IConsoleDisplay? output, IJokeService? service)
        {
            if (service is null)
            {
                throw new ArgumentNullException(nameof(service)); // verify this is the right way to check
            }
            if (output is null)
            {
                throw new ArgumentNullException(nameof(output)); // verify this is the right way to check
            }
            _consoleDisplay = output;
            _jokeService = service;
        }

        // The Jester class TellJoke() method should retrieve a joke from the JokeService.
        // If the joke contains "Chuck Norris", skip it and get another.
        // The joke should be written to the output dependency.

        public void TellJoke()
        {
            string validFormat = _jokeService.GetJoke();
            while (
                validFormat.ToLower().Contains("chuck") ||
                validFormat.ToLower().Contains("norris") ||
                validFormat.Contains("\\u"))
            {
                validFormat = _jokeService.GetJoke();
            }
            _consoleDisplay.Display(validFormat);

        }
        //{"joke": "No statement can catch the ChuckNorrisException."}

    }
}
