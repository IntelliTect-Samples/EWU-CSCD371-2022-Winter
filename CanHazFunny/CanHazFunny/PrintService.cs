using System;

namespace CanHazFunny{

    public class PrintService : IPrintJoke 
    {
        public void PrintJoke(string joke){
            Console.WriteLine(joke);
        }
    }
}