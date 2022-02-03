
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests;
[TestClass]
public class JesterTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Jester_ConstructorIConsoleDisplay_Null()
    {

        new Jester(null, new JokeService());
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Jester_ConstructorIJokeService_Null()
    {

        new Jester( new DisplayService() , null);
    }

    [TestMethod]
    public void TellJoke_ReturnValidJoke()
    {
        string temp = "Test Joke";
        Mock<IJokeService> mock = new Mock<IJokeService>();
        mock.Setup(service => service.GetJoke()).Returns("Test Joke");

        Assert.AreEqual<string>(temp, mock.Object.GetJoke());
        
    }

}

