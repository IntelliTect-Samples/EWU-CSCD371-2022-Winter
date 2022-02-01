using System;
using System.IO;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_ThrowsArgumentNullExceptionNullInter()
        { 
            new Jester(null, null);
        }
        [TestMethod]
        public void TellJoke_NoParams()
        {
            //Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            JokeService js = new JokeService();
            var jsMock = new Mock<IJokeService>();
            jsMock
                .SetupSequence(x => x.GetJoke())
                .Returns("chuck norris")
                .Returns("Chuck Norris")
                .Returns("a joke by Chuck Norris")
                .Returns("somejoke");

            //Act
            var jester = new Jester(jsMock.Object, js);
            jester.TellJoke();

            //Asserts
            Assert.AreEqual<string>("Joke\n", writer.ToString());
        }
    }
}