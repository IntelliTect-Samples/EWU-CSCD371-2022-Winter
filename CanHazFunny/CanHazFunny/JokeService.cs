using System.Net.Http;

namespace CanHazFunny
{
    public class JokeService :IServiceable
    {

        private string? URL { get; set; }
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            string joke = HttpClient.GetStringAsync(URL).Result;
            return joke;
        }

        public void GetService(string serviceAcsess)
        {
            URL = serviceAcsess;
        }
    }
}