using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void TellJoke_NormalJoke_Succeeds()
        {
            var jokeServiceMock = new Mock<IService>();
            var jokeOutputMock = new Mock<IOutput>();

            jokeServiceMock.Setup(s => s.GetJoke()).Returns("Chickens can't fly");
            jokeOutputMock.Setup(o => o.WriteJoke());

            Jester jester = new Jester(jokeServiceMock.Object, jokeOutputMock.Object);
            string jokeTold = jester.TellJoke();

            Assert.AreEqual<string>("Chickens can't fly",jokeTold);
        }

        [TestMethod]
        public void TellJoke_ChuckNorrisFirstJoke_Succeeds()
        {
            var jokeServiceMock = new Mock<IService>();
            var jokeOutputMock = new Mock<IOutput>();

            jokeServiceMock.SetupSequence(s => s.GetJoke())
                .Returns("Chuck Norris can't do push ups")
                .Returns("Chickens can't fly");
            jokeOutputMock.Setup(o => o.WriteJoke());

            Jester jester = new Jester(jokeServiceMock.Object, jokeOutputMock.Object);
            string jokeTold = jester.TellJoke();

            Assert.AreEqual<string>("Chickens can't fly", jokeTold);


        }
    }
}
