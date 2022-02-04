using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class JokeOutput : IOutput
    {
        public string? Joke { get; set; }

        public void WriteJoke()
        {
            if(Joke is null)
            {
                throw new ArgumentNullException(nameof(Joke));
            }
            else
            {
                Console.WriteLine(Joke);
            }
        }
    }
}
