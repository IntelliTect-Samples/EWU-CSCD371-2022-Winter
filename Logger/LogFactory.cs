using System;

namespace Logger
{
    public class LogFactory
    {
        public string ClassName;
        public LogType Type;
        private string _filePath;
        public bool IsLogConfigured;

        public LogFactory(string className)
        {
            ClassName = className;
            _filePath = "";
            IsLogConfigured = false;
        }

        // passing in enum (LogType type) for creating different types of loggers. Extra Credit
        public BaseLogger? CreateLogger(string className, LogType type)
        {
            //If the file logger has not be configured in the LogFactory, its CreateLogger method should return null
            if (!IsLogConfigured)
            {
                return null;
            }

            if (type == LogType.File)
            {
                //method to get filePath
                string filePath = _filePath; // add the path
                return new FileLogger(className, filePath);
            }
            else return new SomeOtherLogger(className);// needs cleaner logic for processing other types of logs

        }

        public string GetFilePath()
        {
            return _filePath;
        }


        // This should take in a file path and store it in a private member. It should use
        // this when instantiating a new FileLogger in its CreateLogger method.
        // order is: create LogFactory -> configure Factory -> create <Type>logger
        public string ConfigureFileLogger(string filePath)
        {
            _filePath = filePath;
            IsLogConfigured = true;
            return filePath;
        }
    }
}
