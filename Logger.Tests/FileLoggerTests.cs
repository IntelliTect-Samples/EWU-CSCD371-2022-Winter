using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void CreateFileLogger_ReturnNonNull()
        {
            FileLogger logger = new("NonNullFileLogger.txt");
            logger.ClassName = this.GetType().Name;
            Assert.IsNotNull(logger);            
        }

        [TestMethod]
        public void LoggerFileWithContentsExists()
        {
            FileLogger logger = new("FileLogger.txt");
            logger.ClassName = this.GetType().Name;
            logger.Log(LogLevel.Debug, "SomeTestMessage");
            Assert.IsTrue(File.Exists(logger.GetFilePath()));
        }

        [TestMethod]
        public void FileContentMatches()
        {
            //TODO: add test to check actual file contents   
        }
    }
}
