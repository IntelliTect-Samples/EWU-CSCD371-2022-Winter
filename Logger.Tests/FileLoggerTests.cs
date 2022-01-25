using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_IsLoggable()
        {
            FileLogger fileLogger = new FileLogger();
            //fileLogger.Log()
            Assert.IsNotNull(fileLogger);

        }
    }
}
