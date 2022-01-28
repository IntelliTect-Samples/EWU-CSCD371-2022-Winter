namespace Logger
{
    public class LogFactory
    {
        private string? LoggerFilePath { get; set; }

        public BaseLogger? CreateLogger(string filePath)
        {
            FileLogger? logger = null;
            if (ConfigureFileLogger(filePath)) 
            {
                logger = new FileLogger(nameof(LogFactory), filePath);
            }
            return logger;
        }

        private bool ConfigureFileLogger(string filepath)
        {
            bool configured = false;

            if(!string.IsNullOrEmpty(filepath))
            {
                LoggerFilePath = filepath;
                configured = true;
            }

            return configured;
        }
    }
}
