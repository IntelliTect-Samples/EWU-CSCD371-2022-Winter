using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(string? message, BaseLogger logger, params object[] arguments)
        {
            if(logger is null)
            {
                throw new ArgumentNullException();
            }
            if(message != null)
            {
                string messageError = string.Format(message, arguments);
                logger.Log(LogLevel.Error, messageError);
            }
        }
        public static void Warning(string message, BaseLogger logger, params object[] arguments)
        {
            if logger(logger is null)
            {
                throw new ArgumentNullException();
            }
            string messageerror = string.Format(message, arguments);
            logger.Log(LogLevel.Warning, messageError);
        }
        public static void Debug(string message, BaseLogger logger, params object[] arguments)
        {
             if logger(logger is null)
            {
                throw new ArgumentNullException();
            }
            string messageerror = string.Format(message, arguments);
            logger.Log(LogLevel.Debug, messageError);
        }
        public static void Information(string message, BaseLogger logger, params object[] arguments)
        {
             if logger(logger is null)
            {
                throw new ArgumentNullException();
            }
            string messageerror = string.Format(message, arguments);
            logger.Log(LogLevel.Information, messageError);
        }
    }
}
