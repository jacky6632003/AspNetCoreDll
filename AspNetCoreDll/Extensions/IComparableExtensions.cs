using AspNetCoreDll.Comparison;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreDll.Extensions
{
    public static class IComparableExtensions
    {
        public static bool Between<T>(this T value, T min, T max, IComparer<T> comparer = null)
        where T : IComparable
        {
            if (comparer.EqualNull())
            {
                comparer = new GenericComparer<T>();
            }
            if (comparer.Compare(max, value) < 0)
            {
                return false;
            }
            return comparer.Compare(value, min) >= 0;
        }
    }
}