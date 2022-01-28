using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void FileLogger_NullFilePath_ThrowsException()
        {
            // Arrange
            string filePath = null;
            string className = nameof(FileLoggerTests);

            // Act
            FileLogger logger = new FileLogger(className, filePath);

            // Assert
            
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void FileLogger_NullSourceClass_ThrowsException()
        {
            // Arrange
            string filePath = "/";
            string className = null;

            // Act
            FileLogger logger = new FileLogger(className, filePath);

            // Assert

        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Log_NullMessage_ThrowsException()
        {
            // Arrange
            string filePath = Path.GetTempFileName();
            string className = nameof(FileLoggerTests);
            FileLogger logger = new FileLogger(className, filePath);

            // Act
            logger.Log(LogLevel.Error, null!);
            
            // Assert

        }


    }
}
