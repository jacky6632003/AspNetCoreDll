using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreDll.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class ValidatedNotNullAttribute : Attribute
    {
        public ValidatedNotNullAttribute()
        {
        }
    }
}