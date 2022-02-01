using System;

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
