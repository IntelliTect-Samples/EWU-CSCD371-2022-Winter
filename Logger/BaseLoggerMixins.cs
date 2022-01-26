using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        private static string? messageWithArgs;
        public static void Error(this BaseLogger? logger, string message, params object[] args) 
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            
            messageWithArgs = String.Format(message, args);

            logger.Log(LogLevel.Error, messageWithArgs);
        }

        public static void Warning(this BaseLogger? logger, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            messageWithArgs = String.Format(message, args);

            logger.Log(LogLevel.Warning, messageWithArgs);
        }

        public static void Information(this BaseLogger? logger, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            messageWithArgs = String.Format(message, args);

            logger.Log(LogLevel.Information, messageWithArgs);
        }

        public static void Debug(this BaseLogger? logger, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            messageWithArgs = String.Format(message, args);

            logger.Log(LogLevel.Debug, messageWithArgs);
        }


    }
}
