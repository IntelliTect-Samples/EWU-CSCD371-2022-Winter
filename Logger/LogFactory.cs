
namespace Logger
{
    public class LogFactory
    {
        private string _FilePath;
        public string FilePath => _FilePath;
        private bool IsLogConfigured;

        public LogFactory()
        {
            _FilePath = "";
            IsLogConfigured = false;
        }

        public BaseLogger? CreateLogger(string className)
        {
            if (!IsLogConfigured)
            {
                return null;
            }


            return className == "FileLogger" ? new FileLogger(className, FilePath) : new ConsoleLogger();
        }

        public void ConfigureFileLogger(string filePath)
        {
            _FilePath = filePath;
            IsLogConfigured = true;
        }
    }
}
