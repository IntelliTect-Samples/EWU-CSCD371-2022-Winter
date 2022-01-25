using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger.Mixins;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
     [TestClass]
     public void TestLog()
        {
            //Arrange
            FileLogger logger = new FileLogger 
            {
                filepath = "file.txt" //this is an empty file.
            };
            //Act
            logger.Log(LogLevel.Debug, "message");

            string[] test = System.IO.File.ReadAllText(logger.filepath);
            //Assert
            Assert.AreEqual("message", ResolveEventArgs[5].Trim());
            Assert.AreEqual("Debug", ResolveEventArgs[4].Trim());
        }

    }
}
