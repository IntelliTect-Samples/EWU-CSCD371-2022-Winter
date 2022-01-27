using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void LogFactory_DefaultFilePath_IsEmpty()
    {
        LogFactory testFactory = new();
        Assert.AreEqual("", testFactory.FilePath);
    }
    [TestMethod]
    public void LogFactory_ConfigureFileLogger_StoresFilePath()
    {
        LogFactory testFactory = new();
        testFactory.ConfigureFileLogger("TestPath");

        Assert.AreEqual("TestPath", testFactory.FilePath);
    }

    [TestMethod]
    public void LogFactory_CreateFileLoggerGivenFileLoggerName_ReturnsFileLogger()
    {
        LogFactory testFactory = new();
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
        LogFactory testFactory = new();
        BaseLogger? FileLoggerTest = testFactory.CreateLogger(testFactory.FilePath);
        Assert.IsNull(FileLoggerTest);
    }

    [TestMethod]
    public void LogFactory_NotGivenFileLoggerName_ReturnsConsoleLogger()
    {
        LogFactory testFactory = new();
        testFactory.ConfigureFileLogger("TestPath");
        BaseLogger? ConsoleLoggerTest = testFactory.CreateLogger("");
        Assert.IsInstanceOfType(ConsoleLoggerTest, typeof(ConsoleLogger));
    }
}

