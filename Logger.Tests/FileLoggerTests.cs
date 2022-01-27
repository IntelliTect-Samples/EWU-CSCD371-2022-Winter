using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;
[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void FileLogger_LogGivenMessage_CreatesLogString()
    {
        FileLogger testFileLogger = new(nameof(FileLogger), "testpath");
        testFileLogger.Log(LogLevel.Debug, "test message");
        Assert.AreEqual($"{DateTime.Now} FileLogger Debug test message", testFileLogger.LogText);
    }
}
