using System;
using System.Net.Http;

namespace CanHazFunny
{
    public class JokeService:IJokeServices, IJokeOut
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            string somejoke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
            return somejoke;
        }
        public void printJoke(string? somejoke)
        {
            Console.WriteLine(somejoke);
        }
    }
}
