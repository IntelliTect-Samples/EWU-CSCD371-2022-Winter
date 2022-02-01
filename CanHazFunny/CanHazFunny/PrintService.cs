using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class PrintService : IPrint
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
