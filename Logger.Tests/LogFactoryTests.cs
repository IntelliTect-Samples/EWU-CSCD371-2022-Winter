using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogFactory_WithValidFileLogger()
        {
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger("TestLogFile.txt");

            string currentClassName = this.GetType().Name;
            BaseLogger fileLogger = logFactory.CreateLogger(currentClassName);

            Assert.IsNotNull(fileLogger);            
            Assert.AreEqual("LogFactoryTests", fileLogger.ClassName);
        }
    }
}