namespace Logger
{
    public abstract class BaseLogger
    {
        //auto-property for BaseLogger.ClassName | should never be null (requirement 1)
        public string ClassName { get; set; } = "Base_Logger";

        public abstract void Log(LogLevel logLevel, string message);
    }
}
