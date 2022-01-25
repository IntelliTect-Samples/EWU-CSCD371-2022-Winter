using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger.Mixins;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void LogTest()
        {
            // Arrange
            FileLogger logger = new FileLogger {
                filePath = "testfile.txt"
            };

            // Act
            logger.Log(LogLevel.Debug, "message");

            string[] res = System.IO.File.ReadAllText(logger.filePath).Split(' ');
            
            // Assert
            Assert.AreEqual("Debug", res[4].Trim());
            Assert.AreEqual("message", res[5].Trim());
        }
        
    }
}
