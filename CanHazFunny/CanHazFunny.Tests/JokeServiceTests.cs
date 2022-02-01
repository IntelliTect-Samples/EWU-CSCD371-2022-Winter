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
        JokeService? _JokeService;
        string _FakeUrl = @"https://fakewebsite.edu";

        [TestInitialize]
        public void TestInit()
        {
            _JokeService = new();

        }
        [TestMethod]
        public void SetupService_StoresURL()
        {
            _JokeService?.SetupService(_FakeUrl);
            Assert.AreEqual<string>(_FakeUrl, _JokeService?.URL!);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetJoke_ExceptionWhenNotSetup()
        {
            _JokeService?.GetJoke();
        }


        [TestMethod]
        public void GetJoke_ReturnsStringGivenAPI()
        {
            string apiUrl = @"https://geek-jokes.sameerkumar.website/api";
            _JokeService?.SetupService(apiUrl);
            Assert.IsNotNull(_JokeService?.GetJoke());
        }

    }
}
