namespace Logger;

public class FileLogger : BaseLogger
{
     
    public FileLogger(string className, string filePath)
    {
        ClassName = className;
        Type = LogType.File;

    }

    // double check implementation for get/set
    public override string ClassName { get; set; }



    public override void Log(LogLevel logLevel, string message)
    {
        throw new System.NotImplementedException();
    }
}

