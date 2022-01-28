using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    internal class ConsoleOutput : IOutputtable
    {
        public void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}
