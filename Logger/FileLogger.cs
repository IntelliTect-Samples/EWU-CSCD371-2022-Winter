

namespace Logger;

public class FileLogger : BaseLogger
{
    private string filePath;
    private string? _LogText;
    public string? LogText { get { return _LogText; } }
    public FileLogger(string className, string path)
    {
        ClassName = className;
        filePath = path;

    }
    public override void Log(LogLevel logLevel, string message)
    {
        StreamWriter sw = File.AppendText(filePath);
        _LogText = $"{DateTime.Now.ToString()} {nameof(FileLogger)} {logLevel} {message}";
        sw.WriteLine(LogText);
        sw.Close();

    }   
}


