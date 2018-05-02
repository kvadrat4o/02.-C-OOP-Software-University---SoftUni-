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

    public int CalcDateDiff(DateTime date1, DateTime date2)
    {
        return Math.Abs((date1 - date2).Days);
    }
}
