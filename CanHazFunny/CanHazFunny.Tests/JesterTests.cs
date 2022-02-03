
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

    //[TestMethod]
    //public void Jester_Instantiate_Success()
    //{
    //    Jester jester = new (new DisplayService(), new JokeService());

    //}

    [TestMethod]
    public void TellJoke_ReturnValidJoke() 
    // this returned zero code coverage for the telljoke method... no idea why
    {
        string temp = "Test Joke";
        Mock<IJokeService> mock = new Mock<IJokeService>();
        mock.Setup(service => service.GetJoke()).Returns("Test Joke");

        Assert.AreEqual<string>(temp, mock.Object.GetJoke());
 
    }

    [TestMethod]
    public void TellJoke_ReturnsString_WithChuckNorris_IsFalse()
    {
        Jester jester = new (new DisplayService(), new JokeService());

        StringWriter output = new();
        Console.SetOut(output);

        jester.TellJoke();
        //Jester.Main(new string[] { });

        Assert.IsFalse(output.ToString().ToLower().Contains("chuck"));
        Assert.IsFalse(output.ToString().ToLower().Contains("norris"));
        //Console.WriteLine(output.ToString());
        //Assert.AreEqual<string>("Compare", output.ToString());

        // code from the web about console output testing
        // Assert.That(output.ToString(),Is.EqualTo(
        // string.Format("What's your name?{0}Hello Somebody!!{0}", Environment.NewLine)));
    }

}

