namespace Logger
{
    internal class ConsoleLogger : BaseLogger
    {
        private string _className;

        public ConsoleLogger(string className)
        {
            this._className = className;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}