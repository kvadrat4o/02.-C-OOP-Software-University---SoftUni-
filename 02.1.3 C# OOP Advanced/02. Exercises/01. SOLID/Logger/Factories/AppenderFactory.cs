using Logger.Contracts;
using Logger.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        const string DEFAULT_FILENAME = "logFile{0}.txt";

        private LayoutFactory layoutFactory;
        private int fileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumber = 0;
        }

        public IAppender CreateAppender(string appenderType, string errorLevelString, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = this.ParseErrorLevel(errorLevelString);
            IAppender appender = null;

            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, errorLevel);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DEFAULT_FILENAME, this.fileNumber));
                    appender = new FileAppender(layout, errorLevel, logFile);
                    break;
                default:
                    throw new ArgumentException("Invalid appender type!");
            }

            return appender;
        }

        private ErrorLevel ParseErrorLevel(string errorLevelString)
        {
            try
            {
                return (ErrorLevel)Enum.Parse(typeof(ErrorLevel), errorLevelString);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Invalid error level type!", e);
            }
        }
    }
}
