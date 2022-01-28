using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger: BaseLogger
    {
        private string? ClassName { get; set; }
        private string? FilePath { get; set; }

        public FileLogger(string? className, string? filepath)
        {
            ClassName = className;
            FilePath = filepath;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            using StreamWriter file = new(FilePath, append: true);
            string currentTime = DateTime.Now.ToString();
            string log = $"{currentTime} {ClassName} {logLevel}: {message}";
            file.WriteLine(log);
        }
    }
}
