using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


public class DateModifier
{
    private DateTime datediff;

    public DateTime DateDiff { get => this.datediff; set => this.datediff = value; }

    public DateTime CalcDateDiff(string date1, string date2)
    {
        var parsed1 = DateTime.ParseExact(date1, "YYYY MM DD", CultureInfo.InvariantCulture);
        var parsed2 = DateTime.ParseExact(date2, "YYYY MM DD", CultureInfo.InvariantCulture);
        var result = 
    }
}
