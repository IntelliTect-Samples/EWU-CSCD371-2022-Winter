using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_NullFilePath_ReturnsNullLogger()
        {
            // Arrange
            string filePath = null;

            // Act
            LogFactory factory = new LogFactory();
            BaseLogger logger = factory.CreateLogger(filePath);

            // Assert
            Assert.IsNull(logger); 
        }


    }
}
