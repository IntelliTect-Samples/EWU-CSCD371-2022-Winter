using System;
namespace Logger.Tests
{
    public class FileLogger : BaseLogger
    {
        public override void Log(LogLevel logLevel, string message)
        {
            Console.WriteLine("bingus");
        }

    }
}