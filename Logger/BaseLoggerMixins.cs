using System;
namespace Logger
{
    public static class BaseLoggerMixins
    {
        
        public static void Error(this BaseLogger logger, string message, params object[] list)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            string message_ = string.Format(message, list);
            logger.Log(LogLevel.Error, message_);

        }

        public static void Warning(this BaseLogger logger, string message, params object[] list)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            string message_ = string.Format(message, list);
            logger.Log(LogLevel.Warning, message_);

        }

        public static void Information(this BaseLogger logger, string message, params object[] list)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            string message_ = string.Format(message, list);
            logger.Log(LogLevel.Information, message_);

        }
        public static void Debug(this BaseLogger logger, string message, params object[] list)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            string message_ = string.Format(message, list);
            logger.Log(LogLevel.Debug, message_);
        }

    }
}
