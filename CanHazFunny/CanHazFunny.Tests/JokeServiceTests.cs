using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JokeServiceTests
    {
        [TestMethod]
        public void JokeServices_ReturnValidString_Success()
        {
            JokeService jokeService = new JokeService();
            Assert.IsNotNull(jokeService.GetJoke());
            Assert.IsInstanceOfType(jokeService.GetJoke(), typeof(string));
        }
    }
}
