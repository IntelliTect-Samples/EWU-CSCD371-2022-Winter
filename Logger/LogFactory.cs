using System;
using System.IO;

namespace Logger
{
    public class LogFactory
    {
        private string? filepath { get; set; }

        public BaseLogger? CreateLogger(string className)
        {
            if (filepath != null)
                return new FileLogger(className,filepath);
            return null;
        }

        public void ConfigureFileLogger(string filePath)
        {
            filepath = filePath;
        }
    }
}
