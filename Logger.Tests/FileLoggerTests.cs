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
            Assert.IsNotNull(logger);
        }
    }
}
