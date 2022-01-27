using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;
[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void FileLogger_LogGivenMessage_CreatesLogString()
    {
        FileLogger testFileLogger = new FileLogger("FileLogger","testpath");
        testFileLogger.Log(LogLevel.Debug, "test message");
        Assert.AreEqual($"{DateTime.Now.ToString()} FileLogger Debug test message", testFileLogger.LogText);
    }
}
