﻿namespace Logger;
public class FileLogger : BaseLogger
{
    public string FilePath { get; }

    public FileLogger(string filePath)
    {
        FilePath = filePath;
    }

    public override void Log(LogLevel logLevel, string message, [System.Runtime.CompilerServices.CallerMemberName] string loggedBy = "")
    {
        string logEvent = $"{DateTime.Now} {loggedBy} {logLevel}: {message}\n";
        File.AppendAllText(FilePath, logEvent);
    }
}
