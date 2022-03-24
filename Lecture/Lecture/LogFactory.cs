namespace Logger;

public class LogFactory
{
    private string? FilePath { get; set; }

    public BaseLogger CreateLogger(string className)
    {
        switch ((FilePath, className))
        {
            case (not null, "FileLogger"):
                FileLogger fileLogger = new(className, FilePath);
                return fileLogger;
            case (null, _):
                throw new InvalidOperationException(
                    $"{nameof(FilePath)} is not set.");
            case (_, null):
                throw new InvalidOperationException(
                    $"{nameof(FilePath)} is not set.");
            default:
                throw new InvalidOperationException(
                    "nameof(className)} is unknown.");
        }
        //if (FilePath is null)
        //{
        //    return null;
        //}
        //switch (className)
        //{
        //    case "FileLogger":
        //        FileLogger fileLogger = new(className, FilePath);
        //        return fileLogger;

        //    default:
        //        return null!;
        //}
    }

    public void ConfigureFileLogger(string loggerPath)
    {
        _ = loggerPath ?? throw new ArgumentNullException(nameof(loggerPath));
        FilePath = loggerPath;
    }
}

