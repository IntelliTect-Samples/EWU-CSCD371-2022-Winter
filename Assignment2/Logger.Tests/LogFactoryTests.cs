using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void loggerconfignull()
        {
            // Arrange
            LogFactory fact = new LogFactory();
            // Act
            FileLogger test = (FileLogger) fact.CreateLogger("","null");
            // Assert
            Assert.AreEqual(null, test);
        }

        [TestMethod]
        public void loggerfromfact()
        {
            // Arrange
            LogFactory fact = new LogFactory();
            // Act
            FileLogger test = (FileLogger) fact.CreateLogger("class","file.txt");
            // Assert
            Assert.AreEqual(test.className, "class");
            Assert.AreEqual(test.filePath, "file.txt");

        }
    }
}
