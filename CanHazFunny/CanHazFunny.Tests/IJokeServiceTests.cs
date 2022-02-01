using System;
using System.IO;
using Moq;
namespace CanHazFunny.Tests;

[TestClass]
public class JokeServiceTests
{

    [TestMethod]
    [DataRow("something is here")]
    [DataRow("something else is here")]
    public void PrintJoke_toConsole(string somejoke)
    {
        //Arrange 
        var writer = new StringWriter();
        Console.SetOut(writer);
        JokeService jokeService = new JokeService();

        //Act 
        jokeService.PrintJoke(somejoke);

        //Assert
        Assert.AreEqual(somejoke + "\n", writer.ToString());
    }

    [TestMethod]
    public void GetJoke_CheckNoParameters()
    {
        //Arrange
        var jsMock = new Mock<IJokeService>();
        jsMock
            .SetupSequence(x => x.GetJoke())
            .Returns("This is a joke")
            .Returns("This is also a joke");
        //Act
        Assert.AreEqual<string?>("This is a joke", jsMock.Object.GetJoke());
        Assert.AreEqual<string?>("This is also a joke", jsMock.Object.GetJoke());
        //Assert
        jsMock.Verify<string?>(x => x.GetJoke(), Times.Exactly(2));
    }

}