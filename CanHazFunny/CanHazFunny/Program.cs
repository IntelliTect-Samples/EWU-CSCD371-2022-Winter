﻿namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {
            //Feel free to use your own setup here - this is just provided as an example
            //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();

            //temp code - this actually returns a string that is a "joke". May have to edit some firewall settings to get it to work however
            JokeService jokeService = new JokeService();
            string jokeExample = jokeService.GetJoke();
            Console.WriteLine(jokeExample);
        }
    }
}
