using Logger.Contracts;
using System.Globalization;

namespace Logger.Models
{
    public class SimpleLayout : ILayout
    {
        const string Format = "{0} - {1} - {2}";
        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            return string.Format(Format, dateString, error.ErrorLevel.ToString(), error.Message);
        }
    }
}
