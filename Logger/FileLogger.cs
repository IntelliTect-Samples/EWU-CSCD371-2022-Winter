using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string FilePath { get; }
        private StreamWriter FileWriter;

        public FileLogger(string sourceClass, string filePath)
        {
            SourceClass = sourceClass ?? throw new ArgumentNullException(nameof(sourceClass));
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            FileWriter = new StreamWriter(FilePath, append: true);
        }

        public override void Log(LogLevel logLevel, string? message)
        {
            message = message ?? throw new ArgumentNullException(nameof(message));
            string dateAndTime = DateTime.Now.ToString();
            string lineToWrite = dateAndTime + " from " + SourceClass + " " + logLevel + ": " + message;
            FileWriter.WriteLine(lineToWrite);
        }
    }
}
