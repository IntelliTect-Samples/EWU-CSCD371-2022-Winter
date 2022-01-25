using System;
namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string? _FilePath;
        //public string? FilePath {  get; set; } 
/*        public string FilePath
        {
            get => _FilePath!;

            set
            {
                if (value is null) { throw new ArgumentNullException(nameof(value)); }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        $"{nameof(Name)} cannot be an empty or whitespace.", nameof(value));
                }
                _Name = value;
            }
        }*/


        public FileLogger(string? filePath) {  }  

        public override void Log(LogLevel logLevel, string message)
        {
            Console.WriteLine("bingus");
        }

    }
}