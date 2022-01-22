namespace Logger
{
    public class LogFactory : BaseLogger
    {
        private string FilePath { get; set; }

        public BaseLogger CreateLogger(string className)
        {
            ClassName = className;

            return (string.IsNullOrEmpty(FilePath) ? null : new FileLogger(FilePath));
        }

        public void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
