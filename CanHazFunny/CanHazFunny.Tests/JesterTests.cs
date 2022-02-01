using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.IO;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_IfIServiceableIsNull_ThrowsException()
        {
            
            IServiceable? js = null;
            IOutputtable co = new ConsoleOutput();
            Jester jester = new(js!,co);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_IfIOutputtableIsNull_ThrowsException()
        {
            JokeService js = new JokeService();
            ConsoleOutput? co = null;
            Jester jester = new(js, co!);
        }

        [TestMethod]
        public void TellJoke_OnStringContainingChuckNorris_GetsAnotherJoke()
        {
            var mockService = new Mock<IServiceable>();
            mockService.SetupSequence(IServiceable => IServiceable.GetJoke()).Returns("A joke containing Chuck Norris").Returns("A better joke");

            ConsoleOutput co = new();

            Jester jester = new(mockService.Object, co);

            jester.TellJoke();
            mockService.Verify(IServiceable => IServiceable.GetJoke(), Times.Exactly(2)); 

        }

        [TestMethod]
        public void TellJoke_WorksWithJsonJokeService()
        {
            StringWriter sw = new();
            Console.SetOut(sw);

            JsonJokeService js = new();
            js.SetupService(@"https://geek-jokes.sameerkumar.website/api?format=json");
            Jester jester = new(js, new ConsoleOutput());
            jester.TellJoke();

            Assert.IsFalse(String.IsNullOrEmpty(sw.ToString()));
            sw.Dispose();

        }
    }
}
