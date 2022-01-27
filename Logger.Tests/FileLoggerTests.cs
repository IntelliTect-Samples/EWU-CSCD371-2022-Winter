using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        LogFactory logFactory;
        FileLogger fileLogger;

        [TestInitialize]
        public void TestInitialize()
        {
            logFactory = new LogFactory();
        }

        [TestMethod]
        public void ValidFileLogger_IsNotNull()
        {
            fileLogger = (FileLogger) logFactory.CreateLogger("FileLog", "C://Egg");
            Assert.IsNotNull(fileLogger);

            //run an example log method and run it
        }

        [TestMethod]
        public void InValidFileLogger_ReturnNull()
        {
            fileLogger = (FileLogger) logFactory.CreateLogger("FileLog", null);
            Assert.IsNull(fileLogger);
        }
    }
}
