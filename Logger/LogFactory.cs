﻿using System;

namespace Logger
{
    public class LogFactory
    {
        private string _className;
        private LogType _type;

        public LogFactory(string className, LogType type)
        {
            _className = className;
            _type = type;
        }

        public BaseLogger CreateLogger(string className, LogType type)
        {
            // object initializer
            // double check how this is done
            string classNameInitializer = className;


            if (type == LogType.File)
            {
                //method to get filePath
                string filePath = getFilePath();
                return new FileLogger(classNameInitializer, filePath);
            }
            else return new SomeOtherLogger(classNameInitializer);

        }

        private string getFilePath()
        {
            return "LogFile.txt";
        }
    }
}
