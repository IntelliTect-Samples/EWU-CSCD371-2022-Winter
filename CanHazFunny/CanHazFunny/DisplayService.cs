using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public class DisplayService : IConsoleDisplay
{
    public void Display(string message)
    {
        Console.WriteLine(message);
    }
}

