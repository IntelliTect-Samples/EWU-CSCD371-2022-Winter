using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void LogFactory_DefaultFilePath_IsEmpty()
    {
        LogFactory testFactory = new LogFactory();
        Assert.AreEqual("", testFactory.FilePath);
    }
    [TestMethod]
    public void LogFactory_ConfigureFileLogger_StoresFilePath()
    {
        LogFactory testFactory = new LogFactory();
        testFactory.ConfigureFileLogger("TestPath");

        Assert.AreEqual("TestPath", testFactory.FilePath);
    }

    [TestMethod]
    public void LogFactory_CreateFileLoggerGivenFileLoggerName_ReturnsFileLogger()
    {
        LogFactory testFactory = new LogFactory();
        testFactory.ConfigureFileLogger("TestPath");
        BaseLogger? FileLoggerTest = testFactory.CreateLogger("FileLogger");
        if (FileLoggerTest != null)
        {
            Assert.AreEqual("FileLogger", FileLoggerTest.ClassName);
        }
        Assert.IsInstanceOfType(FileLoggerTest, typeof(FileLogger));
    }

    [TestMethod]
    public void LogFactory_CreateLoggerWithoutConfugureTrue_ReturnsNull()
    {
        LogFactory testFactory = new LogFactory();
        BaseLogger? FileLoggerTest = testFactory.CreateLogger(testFactory.FilePath);
        Assert.IsNull(FileLoggerTest);
    }

    [TestMethod]
    public void MyTestMethod()
    {

    }
}

