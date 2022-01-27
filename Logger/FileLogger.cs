using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {

        private string? _FilePath;
        public string? FilePath
        {
            get => _FilePath;

            set
            {
                if (value == null) { throw new ArgumentNullException(nameof(value)); }

                _FilePath = value;
            }
        }

        public FileLogger(string? filePath) { FilePath = filePath; }  

        public override void Log(LogLevel logLevel, string message)
        {
            string logResult = $"{DateTime.Now} {ClassName} {logLevel}: {message} \n";
            File.AppendAllText(FilePath, logResult);
        }

    }
}