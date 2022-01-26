

namespace Logger;

public class FileLogger : BaseLogger
{
    private string _filePath;
    public FileLogger(string className, string filePath)
    {
        ClassName = className;
        _filePath = filePath;

    }
    public override void Log(LogLevel logLevel, string message)
    {
        //is there a file

        StreamWriter sw = File.AppendText(_filePath);
        //#pragma warning disable CA1305 // Specify IFormatProvider
        sw.WriteLine($"{DateTime.Now.ToString()} {ClassName} {logLevel} {message}");// use nameof() for Classname?
                                                                                    //#pragma warning restore CA1305 // Specify IFormatProvider
        sw.Close();

    }   
}

