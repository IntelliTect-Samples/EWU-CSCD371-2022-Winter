using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        LogFactory logFactory; 
        FileLogger fileLogger; 

        [TestInitialize]
        public void Initialize()
        {
            logFactory = new LogFactory();
        }

        [TestMethod]
        public void NonNullFileLogger()
        {
            fileLogger = (FileLogger) logFactory.CreateLogger("FileLog", "C://Egg");

            //Assert.IsNotNull(fileLogger);
            Assert.AreEqual("FileLog", fileLogger.ClassName);
            
        }
        
    }
}
