using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    class Jester
    {
        public Jester(IServiceable inputService,IOutputtable outputDevice)
        {
            InputService = inputService ?? throw new ArgumentNullException("Input Service object is null");
            OutputDevice = outputDevice ?? throw new ArgumentNullException("Output Service object is null");
        }

        private IServiceable InputService { get; }
        private IOutputtable OutputDevice { get; }

        public void TellJoke()
        {

        }

        private bool? CheckJoke(string joke)
        {
            return null;
        }
    }
}
