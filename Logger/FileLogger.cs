

namespace Logger;

public class FileLogger : BaseLogger
{
    private string filePath;
    public FileLogger(string className, string path)
    {
        ClassName = className;
        filePath = path;

    }
    public override void Log(LogLevel logLevel, string message)
    {
        StreamWriter sw = File.AppendText(filePath);
        sw.WriteLine($"{DateTime.Now.ToString()} {nameof(ClassName)} {logLevel} {message}");
        sw.Close();

    }   
}


