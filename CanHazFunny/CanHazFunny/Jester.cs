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

       
        public Jester(IConsoleDisplay output, IJokeService service )

        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service)); // verify this is the right way to check
            }
            if (output == null)
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
            string withoutChuckNorris = _jokeService.GetJoke();
            while(withoutChuckNorris.Contains("Chuck Norris")){
                withoutChuckNorris = _jokeService.GetJoke();
            }
            _consoleDisplay.Display(withoutChuckNorris);

        }

        public void IsJson()
        {
            string input = _jokeService.GetJoke().Trim();
            if(input.StartsWith("{") && input.EndsWith("}") || input.StartsWith("[") && input.EndsWith("]")){
                Console.WriteLine("This is JSON.");
            }else
            {
                Console.WriteLine("This is XML.");
            }
        }
    
    }
}
