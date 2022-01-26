﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => BaseLoggerMixins.Error("",null!));
        }
        
        [TestMethod]
        public void Warning_WithNullLogger_ThrowsException()
        {
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => BaseLoggerMixins.Warning("",null!));
        }
        
        [TestMethod]
        public void Debug_WithNullLogger_ThrowsException()
        {
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => BaseLoggerMixins.Debug("",null!));
        }
        
        [TestMethod]
        public void Information_WithNullLogger_ThrowsException()
        {
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => BaseLoggerMixins.Information("",null!));
        }

        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
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
