using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JokeServiceTests
    {
        JokeService? jokeService;
        string fakeUrl = @"https://fakewebsite.edu";

        [TestInitialize]
        public void TestInit()
        {
            jokeService = new();

        }
        [TestMethod]
        public void SetupService_StoresURL()
        {
            jokeService?.SetupService(fakeUrl);
            Assert.AreEqual<string>(fakeUrl, jokeService?.URL!);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetJoke_ExceptionWhenNotSetup()
        {
            jokeService?.GetJoke();
        }


        [TestMethod]
        public void GetJoke_ReturnsStringGivenAPI()
        {
            string apiUrl = @"https://geek-jokes.sameerkumar.website/api";
            jokeService?.SetupService(apiUrl);
            Assert.IsNotNull(jokeService?.GetJoke());
        }

    }
}
