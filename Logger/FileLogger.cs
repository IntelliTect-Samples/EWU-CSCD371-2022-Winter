

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
        //is there a file

        StreamWriter sw = File.AppendText(filePath);
#pragma warning disable CA1305 // Specify IFormatProvider
        sw.WriteLine($"{DateTime.Now.ToString()} {nameof(ClassName)} {logLevel} {message}");// use nameof() for Classname?
#pragma warning restore CA1305 // Specify IFormatProvider
        sw.Close();

    }   
}

