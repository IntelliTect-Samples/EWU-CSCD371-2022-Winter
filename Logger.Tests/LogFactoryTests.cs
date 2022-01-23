using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void LogFactory_GivenLogType_File_ReturnsFileLogger()
    {
        LogFactory testFactory = new LogFactory("Files", LogType.File);

        // this needs work
        Assert.IsInstanceOfType(testFactory, typeof(FileLogger));
    }
}

