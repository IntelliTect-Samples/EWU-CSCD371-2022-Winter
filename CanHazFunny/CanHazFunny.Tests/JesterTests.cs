using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_NullJokeOutput_ArgumentNullException()
        {
            _ = new Jester(new JokeService(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_NullJokeService_ArgumentNullException()
        {
            _ = new Jester(null, new JokeOutput());
        }

        [TestMethod]
        public void Jester_WorkingJokeOutput()
        {
            JokeService jokeService = new JokeService();
            JokeOutput jokeOutput = new JokeOutput();

            Jester jester = new Jester(jokeService, jokeOutput);

            Assert.AreEqual(jokeService, jokeOutput);
        }

        [TestMethod]
        public void Jester_WorkingJokeService()
        {

            JokeService jokeService = new JokeService();
            JokeOutput jokeOutput = new JokeOutput();

            Jester jester = new Jester(jokeService, jokeOutput);

            Assert.AreEqual(jokeService, jokeService);
        }

        [TestMethod]
        public void TellJoke_ChuckNorrisTest_FindNewJoke()
        {

            Mock<JokeService> mock = new Mock<JokeService>();

            mock.SetupSequence(jokeService => jokeService.GetJoke())
                .Returns("Chuck Norris does not sleep. He waits.")
                .Returns("Chuck Norris can divide by zero, and counted to infinity 3 times.")
                .Returns("When Chuck Norris falls in water, Chuck Norris doesn't get wet. Water gets Chuck Norris.")

            Jester jester = new Jester(mock.Object, new JokeOutput());

            jester.TellJoke();

            //
            mock.Verify(jokeService => jokeService.GetJoke(), Times.Exactly(4));
        }

        
    }
}
