namespace Logger
{
    public class LogFactory
    {
        public BaseLogger CreateLogger(string className, string filePath)
        {
            // object initializer
            // double check how this is done
            string classNameInitializer = className;


            return new FileLogger(classNameInitializer, filePath);
        }
    }
}
