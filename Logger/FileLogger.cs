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

    public override void Log(LogLevel logLevel, string message)
    {
        string newLogLine = BuildMessageLine(logLevel, message);

        if (!string.IsNullOrEmpty(newLogLine))
        {
            File.AppendAllText(FilePath, newLogLine);
        }
    }

    private string BuildMessageLine(LogLevel logLevel, string message)
    {
        string fullLine = string.Format("{0} {1} {2}: {3}", GetFormatedDateTime(), nameof(ClassName), logLevel.ToString(), message);

        return fullLine;
    }

    private string GetFormatedDateTime()
    {
        DateTime localDate = DateTime.Now;
        string cultureName = "en-US";

        return localDate.ToString(cultureName);
    }

    public string GetFilePath()
    {
        return FilePath;
    }
}