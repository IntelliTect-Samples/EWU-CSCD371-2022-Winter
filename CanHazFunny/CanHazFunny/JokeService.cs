﻿using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace CanHazFunny
{
    public class JokeService : IJoke
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
            return joke;
        }
    }
}
