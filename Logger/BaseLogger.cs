namespace Logger
{
    public abstract class BaseLogger
    {
        //auto-property for BaseLogger.Name | should never be null (requirement 1)
        public string Name { get; set; } = "Base_Logger";

        public abstract void Log(LogLevel logLevel, string message);
    }
}
