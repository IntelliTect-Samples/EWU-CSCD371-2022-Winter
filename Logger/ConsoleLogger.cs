namespace Logger
{
    internal class ConsoleLogger : BaseLogger
    {

        public ConsoleLogger(string className)
        {
            ClassName = className;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            string logText = ($"{DateTime.Now.ToString()} {nameof(ClassName)} {logLevel} {message}");

        }
    }
}