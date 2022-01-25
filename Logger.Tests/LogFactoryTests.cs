using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void createlogger_returns_null_when_not_configured()
        {
            // Arrange
            LogFactory factory = new LogFactory();
            
            // Act
            FileLogger res = (FileLogger) factory.CreateLogger("","doesntexist");
            
            // Assert
            Assert.AreEqual(null, res);
        }

        [TestMethod]
        public void factory_creates_logger()
        {
            // Arrange
            LogFactory factory = new LogFactory();
            
            // Act
            FileLogger res = (FileLogger) factory.CreateLogger("class","testfile.txt");
            
            // Assert
            Assert.AreEqual(res.className, "class");
            Assert.AreEqual(res.filePath, "testfile.txt");
            
        }
        


        
    }
}
