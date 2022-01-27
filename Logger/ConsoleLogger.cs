namespace Logger
{
    public class ConsoleLogger : BaseLogger
    {
        private string? _LogText;
        public string? LogText { get { return _LogText; } }

        public ConsoleLogger()
        {
            ClassName = "ConsoleLogger";
            _LogText = "";
        }

        public override void Log(LogLevel logLevel, string message)
        {
            _LogText = $"{DateTime.Now} {nameof(ConsoleLogger)} {logLevel} {message}";
            Console.WriteLine(LogText);
        }
    }
}