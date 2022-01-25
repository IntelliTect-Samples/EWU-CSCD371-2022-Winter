using System;

namespace Logger.Mixins
{
    public static class BaseLoggerMixins
    {
        public static void errorLog(this BaseLogger logger, string message, params string[] arr)
        {
            if(logger == null){
                throw new ArgumentNullException();
            }
        
            string res = String.Format(message, arr);
        
            logger.Log(LogLevel.Error, res);
        }

        public static void warningLog(this BaseLogger logger, string message, params string[] arr)
        {
            if(logger == null){
                throw new ArgumentNullException();
            }

            string res = String.Format(message, arr);

            logger.Log(LogLevel.Warning, res);
        }

        public static void informationLog(this BaseLogger logger, string message, params string[] arr)
        {
            if(logger == null){
                throw new ArgumentNullException();
            }
        
            string res = String.Format(message, arr);

            logger.Log(LogLevel.Information, res);
        }

        public static void debugLog(this BaseLogger logger, string message, params string[] arr)
        {
            if(logger == null){
                throw new ArgumentNullException();
            }
        
            string res = String.Format(message, arr);

            logger.Log(LogLevel.Debug, res);
        }
        
    }
}
