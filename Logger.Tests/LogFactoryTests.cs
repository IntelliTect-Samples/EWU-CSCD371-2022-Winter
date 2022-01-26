using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        LogFactory exLogFactory; //'example LogFactory
        FileLogger exLogger; //'example Logger'

        [TestInitialize]
        public void Initialize()
        {
            exLogFactory = new LogFactory();
            exLogger = (FileLogger) exLogFactory.CreateLogger("fileLog", "C://Egg");
        }

        [TestMethod]
        public void ValidInput_MatchesValidFileLogger()
        {
            FileLogger logger = (FileLogger) exLogFactory.CreateLogger("fileLog1", "C://Egg");

            //Assert.Equals(exLogger.ClassName, logger.ClassName);
            Assert.Equals("C://Egg", logger.FilePath);
        }
        
    }
}
