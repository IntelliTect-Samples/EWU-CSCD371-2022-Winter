
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests;
[TestClass]
public class JesterTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void JesterConstructor_GivenNullIConsoleDisplay_ThrowsNullException()
    {
        new Jester(null, new JokeService());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void JesterConstructor_GivenNullIJokeService_ThrowsNullException()
    {
        new Jester( new DisplayService() , null);
    }

    [TestMethod]
    public void TellJoke_ReturnValidJoke() 
    {
        string tempJoke = "Test Joke";
        Mock<IJokeService> mock = new Mock<IJokeService>();
        mock.Setup(service => service.GetJoke()).Returns("Test Joke");

        Assert.AreEqual<string>(tempJoke, mock.Object.GetJoke());
    }

    [TestMethod]
    public void TellJoke_ReturnsString_WithChuckNorris_IsFalse()
    {
        Jester jester = new (new DisplayService(), new JokeService());

        StringWriter output = new();
        Console.SetOut(output);

        jester.TellJoke();

        Assert.IsFalse(output.ToString().ToLower().Contains("chuck"));
        Assert.IsFalse(output.ToString().ToLower().Contains("norris"));
    }

    // create a mock class that implements IJokeService and returns a predictable joke whe GetJoke() is called
    // save the joke to a variable and use that variable in the unit test
}

