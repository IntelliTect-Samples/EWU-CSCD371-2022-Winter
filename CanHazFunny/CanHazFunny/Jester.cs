using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        public IOutput JokeOutput { get; set; }
        public IService JokeService { get; set; }

        public Jester (IService inputJokeService, IOutput inputJokeOutput)
        {
            JokeOutput = inputJokeOutput;
            JokeService = inputJokeService;
        }

        public string TellJoke()
        {
            bool chuckNorrisJoke = false;
            string joke = "";
            do
            {
                joke = JokeService.GetJoke();
                chuckNorrisJoke = joke.Contains("Chuck Norris");

            }while (chuckNorrisJoke);

            JokeOutput.Joke = joke;
            JokeOutput.WriteJoke();

            return joke;
        }
    }
}
