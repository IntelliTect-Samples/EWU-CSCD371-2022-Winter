using System;
using System.Diagnostics;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger logger, string message, params object[] args)
        {
            CheckLoggerExists(logger);
            message = String.Format(message, args);

            logger.Log(LogLevel.Error, message);
        }

        public static void Warning(this BaseLogger logger, string message, params object[] args)
        {
            CheckLoggerExists(logger);
            message = String.Format(message, args);

            logger.Log(LogLevel.Warning, message);
        }

        public static void Debug(this BaseLogger logger, string message, params object[] args)
        {
            CheckLoggerExists(logger);
            message = String.Format(message, args);

            logger.Log(LogLevel.Debug, message);
        }

        public static void Information(this BaseLogger logger, string message, params object[] args)
        {
            CheckLoggerExists(logger);
            message = String.Format(message, args);

            logger.Log(LogLevel.Information, message);
        }

        private static void CheckLoggerExists(BaseLogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("Logger cannot be null: {0}", nameof(logger));
            }
        }
        
    }
}
