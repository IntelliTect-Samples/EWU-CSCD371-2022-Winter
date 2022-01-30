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
            string testFilePath = "FileLogger2.txt";
            string[] testMessages = new[]
            {
                "Some first Warning TestMessage 1st",
                "Some second Warning TestMessage 2nd",
                "Some third Warning TestMessage 3rd",
                "Some forth Warning TestMessage 4th"
            };

            FileLogger logger = new(testFilePath);
            logger.ClassName = this.GetType().Name;

            foreach (string msg in testMessages)
            {
                logger.Log(LogLevel.Warning, msg);
            }


            if (File.Exists(testFilePath))
            {
                try
                {
                    string[] fileMessages = File.ReadAllLines(testFilePath);

                    for (int i = 0; i < fileMessages.Length; i++)
                    {
                        StringAssert.Equals(fileMessages[i], testMessages[i]);
                    }

                }
                catch (InvalidOperationException)
                {
                    throw;
                }

            }
            else
            {
                throw new FileNotFoundException($"The file: {testFilePath} was not found!");
            }
        }
    }
}
