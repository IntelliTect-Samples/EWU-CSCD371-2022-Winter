namespace Logger
{
    public class LogFactory
    {
        private string FilePath { get; set; }

        public BaseLogger CreateLogger(string className)
        {
            if (!string.IsNullOrEmpty(className))
            {
                ConfigureFileLogger("Assignment2_Logs.txt");

                BaseLogger baseLogger = new FileLogger(FilePath);
                baseLogger.ClassName = className;

                return baseLogger;
            }

            return null;
        }

        public void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;

            // TODO: Create File here
        }
    }
}
