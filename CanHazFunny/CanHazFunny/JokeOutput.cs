using System;

namespace CanHazFunny
{
    public class JokeOutput : IJokeOutput
    {
        public void PrintJoke(string joke)
        {
            Console.WriteLine(joke);
        }
    }
}
