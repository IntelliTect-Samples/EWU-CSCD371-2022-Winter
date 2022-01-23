using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, string[] args)
        {
            if (baseLogger is null)
                throw new ArgumentNullException("The BaseLogger reference can not be null");


        }

        public static void Warning(this BaseLogger baseLogger, string message, string[] args)
        {
            if (baseLogger is null)
                throw new ArgumentNullException("The BaseLogger reference can not be null");


        }

        public static void Information(this BaseLogger baseLogger, string message, string[] args)
        {
            if (baseLogger is null)
                throw new ArgumentNullException("The BaseLogger reference can not be null");


        }

        public static void Debug(this BaseLogger baseLogger, string message, string[] args)
        {
            if (baseLogger is null)
                throw new ArgumentNullException("The BaseLogger reference can not be null");


        }

    }
}
