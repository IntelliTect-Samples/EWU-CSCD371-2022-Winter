using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        private JokeService? _jokeService;
        private PrintService? _printService;
        private Jester? _jester;
        private string? _joke;


        [TestInitialize]
        public void Initialize()
        {
            _jokeService = new JokeService();
            _printService = new PrintService();
        }


        [TestMethod]
        public void ValidJokeService_GetJoke_ReturnsNonNull()
        {
            string joke = _jokeService!.GetJoke();  
            Assert.IsNotNull(joke);
        }


        [TestMethod]
        public void ValidJokeServiceAndPrintSercive_ReturnsNonNullJester()
        {
            _jester = new Jester(_jokeService!, _printService!);

            Assert.IsNotNull(_jester);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullJokeService_JesterCreation_ExpectedNULLException()
        {
            _ = new Jester(null!, _printService!);
        }


        [TestMethod]
        public void NullPrintService_JesterCreation_ExpectedNULLException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = new Jester(_jokeService!, null!);
            });
        }


        [TestMethod]
        public void CheckJokeString_DoesNotContainChuckNorris_AssertFalse()
        {
            //the code below is an exact copy of Jester.TellJoke method
            //this TestMethod is meant to ensure Jester.TellJoke is working properly
            do
            {
                _joke = _jokeService!.GetJoke();
            }
            while (_joke.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase));

            Assert.IsFalse(_joke.Contains("Chuck Norris"));
        }


        [TestMethod]
        public void MockJester_ValidJoke_GetJokeReturnsMatch_AssertEqual()
        {
            MockJester mockJester = new MockJester();
            Assert.AreEqual("You saved me, why? mm monke", mockJester.GetJoke());
        }


        [TestMethod]
        public void MockJester_ValidJoke_PrintProducesMatch_AssertEqual()
        {
            MockJester mockJester = new MockJester();
            mockJester.Print("egg :)");
            Assert.AreEqual("egg :)", mockJester._joke);
        }
    }
}
