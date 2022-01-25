using System;
using System.Linq;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params object[] messageArgs)
        {
            if (baseLogger is null)
                throw new ArgumentNullException("The BaseLogger reference can not be null");

            baseLogger.Log(LogLevel.Error, BuildStringMessage(message, messageArgs));
        }

        public static void Warning(this BaseLogger baseLogger, string message, params object[] messageArgs)
        {
            if (baseLogger is null)
                throw new ArgumentNullException("The BaseLogger reference can not be null");

            baseLogger.Log(LogLevel.Warning, BuildStringMessage(message, messageArgs));
        }

        public static void Information(this BaseLogger baseLogger, string message, params object[] messageArgs)
        {
            if (baseLogger is null)
                throw new ArgumentNullException("The BaseLogger reference can not be null");

            baseLogger.Log(LogLevel.Information, BuildStringMessage(message, messageArgs));
        }

        public static void Debug(this BaseLogger baseLogger, string message, params object[] messageArgs)
        {
            if (baseLogger is null)
                throw new ArgumentNullException("The BaseLogger reference can not be null");

            baseLogger.Log(LogLevel.Debug, BuildStringMessage(message, messageArgs));
        }

        private static string BuildStringMessage(string message, params object[] messageArgs)
        {
            message = string.IsNullOrEmpty(message) ? "" : message;
            string joinedArgs = messageArgs is null ? "" : string.Join(" ", messageArgs.Select(x => x.ToString()));
            string messageWithArgs = $"{message} {joinedArgs}";

            return messageWithArgs;
        }
    }
}
