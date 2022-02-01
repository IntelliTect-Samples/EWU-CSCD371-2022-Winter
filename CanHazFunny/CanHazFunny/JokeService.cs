using System.Net.Http;

namespace CanHazFunny
{
    public class JokeService :IServiceable
    {

        public string? URL { get; private set; }
        private HttpClient HttpClient { get; } = new();


        public string GetJoke()
        {
            string joke = HttpClient.GetStringAsync(URL).Result;
            return joke;
        }

        public void SetupService(string serviceAccess)
        {
            URL = serviceAccess;
        }
    }
}