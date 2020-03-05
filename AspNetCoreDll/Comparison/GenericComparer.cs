using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreDll.Comparison
{
    public class GenericComparer<T> : IComparer<T>
   where T : IComparable
    {
        public GenericComparer()
        {
        }

        public int Compare(T x, T y)
        {
            if (!typeof(T).IsValueType | (!typeof(T).IsGenericType ? false : typeof(T).GetGenericTypeDefinition().IsAssignableFrom(typeof(Nullable<>))))
            {
                T t = default(T);
                if (Object.Equals(x, t))
                {
                    t = default(T);
                    if (!Object.Equals(y, t))
                    {
                        return -1;
                    }
                    return 0;
                }
                t = default(T);
                if (Object.Equals(y, t))
                {
                    return -1;
                }
            }
            if (x.GetType() != y.GetType())
            {
                return -1;
            }
            IComparable<T> comparable = (object)x as IComparable<T>;
            if (comparable != null)
            {
                return comparable.CompareTo(y);
            }
            return x.CompareTo(y);
        }
    }
}