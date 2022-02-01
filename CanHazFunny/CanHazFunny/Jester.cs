using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CanHazFunny
{
    public class Jester
    {
        public Jester(IServiceable inputService,IOutputtable outputService)
        {
            InputService = inputService ?? throw new ArgumentNullException(nameof(inputService) + " object is null");
            OutputService = outputService ?? throw new ArgumentNullException(nameof(outputService) + " object is null");
        }

        private IServiceable InputService { get; }
        private IOutputtable OutputService { get; }

        public void TellJoke()
        {
            string joke = new("");
            do
            {
                joke = InputService.GetJoke();

            } while (!IsJokeGood(joke));

            OutputService.Output(joke);
        }

        private bool IsJokeGood(string joke)
        {
            if (joke.Contains("Chuck Norris")) { return false; }

            return true;
        }
    }
}
