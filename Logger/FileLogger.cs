using System;
using System.IO;
using Logger.Mixins;

namespace Logger{

    public class FileLogger : BaseLogger
    {
        public string filePath { get; set; }
        
        
        public override void Log(LogLevel logLevel, string message)
        {
            StreamWriter writer = new StreamWriter(filePath);

            writer.WriteLine(DateTime.Now.ToString() + " " + nameof(this.className)
            + " " + logLevel + " " + message);

            writer.Close();

            return;
        }
    }
}