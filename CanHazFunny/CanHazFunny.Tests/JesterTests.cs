using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        Jester jester;
        StringWriter stringWriter = new();

        [TestInitialize]
        public void TestInit()
        {
            jester = new Jester(new JokeService(), new WriteJokeService());
            Console.SetOut(stringWriter);
        }

        [TestMethod]
        public void TellJoke_GetsJoke_NotNull()
        {
            jester.TellJoke();
            Assert.IsNotNull(stringWriter.ToString());
        }

        [TestMethod]
        public void TellJoke_GetsJokeWithoutChuckNorris_JokeIsNorrisFree()
        {
            jester.TellJoke();
            Assert.IsFalse(stringWriter.ToString().Contains("Chuck Norris"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_CheckParameterJokeService_NotNull()
        {
            jester = new Jester(new JokeService(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_CheckParameterWriteJokeService_NotNull()
        {
            jester = new Jester(null, new WriteJokeService());
        }
    }
}
