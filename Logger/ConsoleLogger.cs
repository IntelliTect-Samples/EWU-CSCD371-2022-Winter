namespace Logger
{
    internal class ConsoleLogger : BaseLogger
    {

        public ConsoleLogger()
        {
            ClassName = "ConsoleLogger";
        }

        public override void Log(LogLevel logLevel, string message)
        {
            string logText = ($"{DateTime.Now.ToString()} {nameof(ClassName)} {logLevel} {message}");

        }
    }
}