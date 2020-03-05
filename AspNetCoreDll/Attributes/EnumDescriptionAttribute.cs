using System;

namespace AspNetCoreDll.Attributes
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        public string Description
        {
            get;
        }

        public EnumDescriptionAttribute(string description)
        {
            this.Description = description;
        }
    }
}