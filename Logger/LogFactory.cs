using System;
namespace Logger
{
    public class LogFactory
    {

        private string? _FilePath;
        private string? FilePath
        {
            get => _FilePath!;

            set
            {
                if (value == null) { throw new ArgumentNullException(nameof(value)); }

                _FilePath = value;
            }
        }


        public BaseLogger? CreateLogger(string className, string? filePath)
        {
            if (filePath != null)
            {
                ConfigureFileLogger(filePath);
                
                FileLogger fileLogger = new FileLogger(FilePath)
                {
                    ClassName = className
                }; 

                return fileLogger;
            }

            return null; 
        }

        public void ConfigureFileLogger (string filePath) 
        {
            FilePath = filePath;
        }
    }
}
  