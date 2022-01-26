namespace Logger
{
    internal class SomeOtherLogger : BaseLogger
    {
        private string classNameInitializer;

        public SomeOtherLogger(string classNameInitializer)
        {
            this.classNameInitializer = classNameInitializer;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}