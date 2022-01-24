namespace Logger
{
    public abstract class BaseLogger
    {

        public string? Name { get; set; } = "Base_Logger";
        public abstract void Log(LogLevel logLevel, string message);
    }
}
