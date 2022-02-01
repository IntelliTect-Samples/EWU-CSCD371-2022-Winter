using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace CanHazFunny
{
    public class JsonJokeService : JokeService
    {

        new public string? GetJoke()
        {
            _Joke? joke = JsonSerializer.Deserialize<_Joke?>(HttpClient.GetStringAsync(URL).Result);
            return joke?.joke;
        }


        private class _Joke
        {
            public string? joke { get; set; }
        }
    }
}
