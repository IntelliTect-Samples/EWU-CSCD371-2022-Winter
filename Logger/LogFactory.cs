namespace Logger
{
    public class LogFactory
    {
        private string _className;
        private string _filePath;
        public LogFactory(string className, string filePath)
        {
            _className = className;
            _filePath = filePath;
        }
        
        public BaseLogger CreateLogger(string className, string filePath)
        {
            // object initializer
            // double check how this is done
            string classNameInitializer = className;


            return new FileLogger(classNameInitializer, filePath);
        }
    }
}
