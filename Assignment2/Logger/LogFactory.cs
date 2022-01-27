namespace Logger
{
    public class LogFactory
    {
        private string? ClassName(get; set;)
        private string? FilePath(get; set;)
        public LogFactory(string classname)
        {
            ClassName = ClassName;
        }
        public ConfigureFileLogger(string filepath)
        {
            FilePath = filepath;
        }
        public BaseLogger? CreateLogger(string className)
        {
            if(FilePath is not null) return new FileLogger(ClassName, FilePath);
            return null;
        }
    }
}
