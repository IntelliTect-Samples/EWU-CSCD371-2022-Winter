namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger? logger, string message, params string[] loggerMessage)
        {
            if (logger is null)
            {
                throw new ArgumentNullException("BaseLogger cannot be null", nameof(BaseLoggerMixins));
            }
            string logText = string.Format(message, loggerMessage);
            logger.Log(LogLevel.Error, logText);
        }

        public static void Warning(this BaseLogger? logger, string message, params string[] loggerMessage)
        {
            if (logger is null)
            {
                throw new ArgumentNullException("BaseLogger cannot be null", nameof(BaseLoggerMixins));
            }
            string logText = string.Format(message, loggerMessage);
            logger.Log(LogLevel.Warning, logText);

        }

        public static void Information(this BaseLogger? logger, string message, params string[] loggerMessage)
        {
            if (logger is null)
            {
                throw new ArgumentNullException("BaseLogger cannot be null", nameof(BaseLoggerMixins));
            }
            string logText = string.Format(message, loggerMessage);
            logger.Log(LogLevel.Information, logText);
        }

        public static void Debug(this BaseLogger? logger, string message, params string[] loggerMessage)
        {
            if (logger is null)
            {
                throw new ArgumentNullException("BaseLogger cannot be null", nameof(BaseLoggerMixins));
            }
            string logText = string.Format(message, loggerMessage);
            logger.Log(LogLevel.Debug, logText);
        }

    }
}
