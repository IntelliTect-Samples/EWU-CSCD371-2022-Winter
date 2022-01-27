using System;
namespace Logger
{
    public class LogFactory
    {
        //wrong needs updating

        //used in FileLogger creation | can be null as only FileLogger should need a filePath
        //private string? _FilePath;
        private string? FilePath
        {
            get => FilePath!;

            set
            {
                if (value == null) { throw new ArgumentNullException(nameof(value)); }

                FilePath = value;
            }
        }


        public BaseLogger? CreateLogger(string className, string? filePath)
        {
            //if filePath isn't null (not neccesarily valid)...
            if (filePath != null)
            {
                //run ConfigFileLogger to store filePath as a private member
                ConfigureFileLogger(filePath);
                
                //following ConfigFileLogger, create a new FileLogger using object initializer
                FileLogger fileLogger = new (FilePath)
                {
                    ClassName = className
                }; //object initializer to edit the class name (requirement 1)

                //return the valid FileLogger object
                return fileLogger;
            }

            return null; //(to meet requirement 4)
        }

        public void ConfigureFileLogger (string filePath) 
        {
            FilePath = filePath;
        }
    }
}
