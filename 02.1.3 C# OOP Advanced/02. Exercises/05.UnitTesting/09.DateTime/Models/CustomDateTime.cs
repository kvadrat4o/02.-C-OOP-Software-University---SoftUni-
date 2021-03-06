﻿using System;
using System.Collections.Generic;
using System.Text;

public class CustomDateTime : IDatetime
{
    public void AddDays(DateTime date, double daysToAdd) => date.AddDays(daysToAdd);

    public DateTime Now() => DateTime.Now;

    public TimeSpan SubstractDays(DateTime date, int daysToSybstract)
        => date.Subtract(DateTime.Parse($"{daysToSybstract}", System.Globalization.CultureInfo.InvariantCulture));
}
