using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CanHazFunny.Tests;

[TestClass]
public class JesterTests
{
  

    [TestMethod]
    public void Jester_HasJokeOutputDependancy_True()
    {
        JokeService jokeService = new();
        JokeOutput jokeOutput = new();
        Jester jester = new(jokeOutput, jokeService);

        Assert.AreEqual<IJokeOutput>(jester.JokeOutput, jokeOutput);
    }

    [TestMethod]
    public void Jester_HasJokeServiceDependancy_True()
    {
        JokeService jokeService = new();
        JokeOutput jokeOutput = new();
        Jester jester = new(jokeOutput, jokeService);

        Assert.AreEqual<IJokeService>(jester.JokeService, jokeService);

    }
    [TestMethod]
    public void Jester_JokeDoesNotContainChuckNorris_True()
    {
        JokeService jokeService = new();
        JokeOutput jokeOutput = new();
        Jester jester = new(jokeOutput, jokeService);

        jester.TellJoke();

        Assert.IsFalse(jester.Joke!.Contains("Chuck Norris"));

    }
    [TestMethod]
    public void Jester_IfJokeServiceIsNullThrowException_Pass()
    {
        JokeService? jokeService = null;
        JokeOutput? jokeOutput = new();



        Jester jester;
        Assert.ThrowsException<ArgumentNullException>(() => jester = new(jokeOutput, jokeService!));


    }
    [TestMethod]
    public void Jester_IfJokeOutputIsNullThrowException_Pass()
    {
        JokeService? jokeService = new();
        JokeOutput? jokeOutput = null;



        Jester jester;
        Assert.ThrowsException<ArgumentNullException>(() => jester = new(jokeOutput!, jokeService!));


    }

}   
     