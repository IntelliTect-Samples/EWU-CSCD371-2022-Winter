using System;
using System.IO;

namespace Logger
{
    public class LogFactory
    {
        private bool configured = false;

        private string path;

        public void ConfigureFileLogger(string path)
        {
            if(File.Exists(path))
            {
                this.path = path;

                this.configured = true;
            }else{
                return;
            }
            
        }

        public BaseLogger CreateLogger(string className, string path)
        {
            this.ConfigureFileLogger(path);

            if(this.configured == false){
                return null;
            }

            FileLogger logger = new FileLogger
            {
                className = className,

                filePath = this.path
            };

            return logger;
        }
    }
}
