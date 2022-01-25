namespace Logger
{
    public class LogFactory
    {
        private string classname;
        private string filepath;

        public BaseLogger CreateLogger(string className)
        {
            
            classname = className;
        }

        public void ConfigureFileLogger(string filePath)
        {
            filepath = filePath;
        }
    }
}
