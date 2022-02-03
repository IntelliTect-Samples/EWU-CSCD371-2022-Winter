using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace CanHazFunny.Tests;

[Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
public class JokeServiceTests
{
    [TestMethod]
    public void JokeService_GetJokeReturnsAJoke_True()
    {
        Mock<JokeService> mockJoke = new();
      
        mockJoke.SetupSequence(joke => joke.GetJoke()).Returns("this is a joke, ha, ha, ha");

        Assert.AreEqual<string?>("this is a joke, ha, ha, ha", mockJoke.Object.GetJoke());
    }
}


