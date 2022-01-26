namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger? logger, string message, params string[] loggerMessage)
        {
            if (logger is null)
            {
                throw new ArgumentNullException();
            }
            string temp = String.Format(message, loggerMessage);
            logger.Log(LogLevel.Error, temp);
        }
      
        public static void Warning(this BaseLogger? logger, string message, params string[] loggerMessage)
        {
            if (logger is null)
            {
                throw new ArgumentNullException();
            }
            string temp = String.Format(message, loggerMessage);
            logger.Log(LogLevel.Warning, temp);

        }

        public static void Information(this BaseLogger? logger, string message, params string[] loggerMessage)
        {
            if (logger is null)
            {
                throw new ArgumentNullException();
            }
            string temp = String.Format(message, loggerMessage);
            logger.Log(LogLevel.Information, temp);
        }

        public static void Debug(this BaseLogger? logger, string message, params string[] loggerMessage)
        {
            if (logger is null)
            {
                throw new ArgumentNullException();
            }
            string temp = String.Format(message, loggerMessage);
            logger.Log(LogLevel.Debug, temp);
        }

    }
}
