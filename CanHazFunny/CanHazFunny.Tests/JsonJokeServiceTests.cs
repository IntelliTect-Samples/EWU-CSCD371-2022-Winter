using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JsonJokeServiceTests
    {
        [TestMethod]
        public void GetJoke_ProperlyDeserializesJSON()
        {
            JsonJokeService jokeService = new();
            jokeService.SetupService(@"https://geek-jokes.sameerkumar.website/api?format=json");
            Console.WriteLine(jokeService.GetJoke());

        }
    }
}
