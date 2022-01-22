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
        string newLogLine = BuildMessageLine(logLevel, message);

        if (string.IsNullOrEmpty(newLogLine))
        {
            File.AppendAllLines(FilePath, newLogLine);
        }
    }

    private string BuildMessageLine(LogLevel logLevel, string message)
    {
        string fullLine = "";
        fullLine = string.Format("{0} {1} {2}: {3}", GetFormatedDateTime(), nameof(this), logLevel.ToString, message);

        return fullLine;
    }

    private string GetFormatedDateTime()
    {
        DateTime localDate = DateTime.Now;
        string cultureName = "en-US";

        return localDate.ToString(cultureName);
    }
}