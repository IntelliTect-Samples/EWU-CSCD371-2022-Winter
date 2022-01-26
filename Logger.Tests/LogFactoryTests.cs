using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void LogFactory_Constructor_ReturnsLogFactoryObject()
    {
        LogFactory testFactory = new LogFactory("Files");

        Assert.IsInstanceOfType(testFactory, typeof(LogFactory));
    }

    [TestMethod]
    public void LogFactory_ConfigureFileLogger_StoresFilePath()
    {
        LogFactory testFactory = new LogFactory("Test");
        testFactory.ConfigureFileLogger("TestPath");

        Assert.AreEqual("TestPath", testFactory.FilePath);
    }

    [TestMethod]
    public void LogFactory_CreateLoggerGivenFileLoggerName_ReturnsFileLogger()
    {
        LogFactory testFactory = new LogFactory("FileLogger");
        testFactory.ConfigureFileLogger("TestPath");
        BaseLogger? FileLoggerTest = testFactory.CreateLogger(testFactory.FilePath);
        Assert.IsInstanceOfType(FileLoggerTest, typeof(FileLogger));
    }
}

