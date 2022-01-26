using System;
namespace Logger
{
    public static class BaseLoggerMixins
    {
        
        public class void Error(this BaseLogger logger, string message, params object[] list)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
        }

        public class void Warning(this BaseLogger logger, string message, params object[] list)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
        }

        public class void Information(this BaseLogger logger, string message, params object[] list)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
        }
        public class void Debug(this BaseLogger logger, string message, params object[] list)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
        }

    }
}
