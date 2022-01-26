namespace Logger
{
    internal class ConsoleLogger : BaseLogger
    {
        private string classNameInitializer;

        public ConsoleLogger(string classNameInitializer)
        {
            this.classNameInitializer = classNameInitializer;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}