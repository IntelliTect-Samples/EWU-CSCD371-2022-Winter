using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

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
            Assert.AreEqual(exLogger.FilePath, logger.FilePath);
            Assert.AreEqual("fileLog1", logger.ClassName);
        }

        [TestMethod]
        public void NullFilePath_ThrowNullException()
        {
            FileLogger logger = (FileLogger)exLogFactory.CreateLogger("badInput", null);

            Assert.IsNull(logger);
        }


        
        
    }
}
