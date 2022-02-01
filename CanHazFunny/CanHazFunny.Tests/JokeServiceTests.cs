using System;
using System.IO;
using Moq;
namespace CanHazFunny.Tests;

[TestClass]
public class JokeServiceTests
{
    [TestMethod]
    public void GetJoke_NoParameters_RetrievesJoke()
    {
        //Arrange
        var jokeServiceMock = new Mock<IJokeService>();
        jokeServiceMock
            .SetupSequence(x => x.GetJoke())
            .Returns("Insert Joke Here")
            .Returns("Insert Joke 2 Here");
        //Act
        Assert.AreEqual<string?>("Insert Joke Here", jokeServiceMock.Object.GetJoke());
        Assert.AreEqual<string?>("Insert Joke 2 Here", jokeServiceMock.Object.GetJoke());
        //Assert
        jokeServiceMock.Verify<string?>(x => x.GetJoke(), Times.Exactly(2));
    }

    [TestMethod]
    [DataRow("Is the sky blue?")]
    [DataRow("Is the sky red?")]
    public void PrintJoke_Joke_WritesJokeToConsole(string joke)
    {
        //Arrange 
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        JokeService jokeService = new JokeService();
        
        //Act 
        jokeService.PrintJoke(joke);
        
        //Assert
        Assert.AreEqual(joke+"\n", stringWriter.ToString());
    }
}