using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Logger.Mixins;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange
            BaseLogger logger = null;

            // Act
            logger.errorLog(null, "");

            // Assert
            
        }

        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.errorLog("Message {0}", "42");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void warning_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.warningLog("Message {0}", "42");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void information_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.informationLog("Message {0}", "42");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void debug_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.debugLog("Message {0}", "42");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

    }

    public class TestLogger : BaseLogger
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }
}
