using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;
[TestClass]

public class ConsoleLoggerTests
{
    [TestMethod]
    public void ConsoleLogger_LogGivenMessage_CreatesLogString()
    {
        ConsoleLogger testConsoleLogger = new ConsoleLogger();
        testConsoleLogger.Log(LogLevel.Debug, "test message");
        Assert.AreEqual($"{DateTime.Now} ConsoleLogger Debug test message", testConsoleLogger.LogText);
    }

}