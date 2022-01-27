using System;

namespace Logger
{
    public class LogFactory
    {
        private string _FilePath;
        public string FilePath { get => _FilePath; }
        private bool IsLogConfigured;

        public LogFactory()
        {
            _FilePath = "";
            IsLogConfigured = false;
        }

        public BaseLogger? CreateLogger(string className)
        {
            if (!IsLogConfigured)
            {
                return null;
            }

            if (className == "FileLogger")
            {
                return new FileLogger(className, FilePath);
            }

            else return new ConsoleLogger(className);// needs cleaner logic for processing other types of logs

        }

        public void ConfigureFileLogger(string filePath)
        {
            _FilePath = filePath;
            IsLogConfigured = true;
        }
    }
}
