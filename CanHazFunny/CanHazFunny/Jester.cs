using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    class Jester
    {
        public Jester(IOutputtable outputDevice, IServiceable inputService)
        {
           OutputDevice = outputDevice;
           InputService = inputService;
        }

        private IOutputtable OutputDevice { get; }
        private IServiceable InputService { get; }

    }
}
