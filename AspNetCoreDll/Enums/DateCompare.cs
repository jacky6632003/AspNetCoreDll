using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreDll.Enums
{
    [Flags]
    public enum DateCompare
    {
        InFuture = 1,
        InPast = 2,
        Today = 4,
        WeekDay = 8,
        WeekEnd = 16
    }
}