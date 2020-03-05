using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreDll.Extensions
{
    public static class ArrayExtensions
    {
        public static TArrayType[] Concat<TArrayType>(this TArrayType[] arraySource, params TArrayType[][] additions)
        {
            if (arraySource.EqualNull())
            {
                throw new ArgumentNullException("arraySource");
            }
            if (additions.EqualNull())
            {
                throw new ArgumentNullException("additions");
            }
            if (additions.Any<TArrayType[]>((TArrayType[] x) => x.EqualNull()))
            {
                throw new ArgumentNullException("additions");
            }
            TArrayType[] tArrayTypeArray = new TArrayType[(int)arraySource.Length + additions.Sum<TArrayType[]>((TArrayType[] x) => (int)x.Length)];
            int length = (int)arraySource.Length;
            Array.Copy(arraySource, 0, tArrayTypeArray, 0, (int)arraySource.Length);
            TArrayType[][] tArrayTypeArray1 = additions;
            for (int i = 0; i < (int)tArrayTypeArray1.Length; i++)
            {
                TArrayType[] tArrayTypeArray2 = tArrayTypeArray1[i];
                Array.Copy(tArrayTypeArray2, 0, tArrayTypeArray, length, (int)tArrayTypeArray2.Length);
                length += (int)tArrayTypeArray2.Length;
            }
            return tArrayTypeArray;
        }

        public static Array ToClear(this Array array)
        {
            if (array.EqualNull())
            {
                return null;
            }
            Array.Clear(array, 0, array.Length);
            return array;
        }
    }
}