using System;
using System.IO;
namespace Logger;

public class FileLogger : BaseLogger
{
    private string FilePath { get; set; }

    public FileLogger(string filePath)
    {
        FilePath = filePath;
    }

    public void Log(LogLevel logLevel, string message)
    {
        // TODO: turn this in to a separate method
        string newLogLine = "Test Line";
        File.AppendAllLines(FilePath);
    }

}