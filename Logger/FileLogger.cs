namespace Logger;

public class FileLogger : BaseLogger
{
    
    public LogType = LogType.File;
    public FileLogger(string className, string filePath)
    {
        ClassName = className;

    }

    // double check implementation for get/set
    public override string ClassName { get; set; }



    public override void Log(LogLevel logLevel, string message)
    {
        throw new System.NotImplementedException();
    }
}

