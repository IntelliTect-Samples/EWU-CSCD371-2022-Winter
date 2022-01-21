namespace Logger
{
    public class LogFactory : BaseLogger
    {
        public BaseLogger CreateLogger(string className)
        {
            ClassName = className;
            return null;
        }
    }
}
