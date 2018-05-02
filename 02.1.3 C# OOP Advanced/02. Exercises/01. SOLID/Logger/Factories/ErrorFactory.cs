using Logger.Contracts;
using Logger.Models;
using System;
using System.Globalization;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string dateTimeString, string errorLevelString, string message)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeString, DateFormat, CultureInfo.InvariantCulture);
            ErrorLevel errorLevel = ParseErrorLevel(errorLevelString);

            return new Error(dateTime, errorLevel, message);
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
