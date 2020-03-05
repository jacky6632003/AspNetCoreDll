using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreDll.Helpers
{
    public class Base64Helper
    {
        private readonly static char[] Base64Chars;

        static Base64Helper()
        {
            Base64Helper.Base64Chars = new Char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/' };
        }

        public Base64Helper()
        {
        }

        public static string Decode(string base64EncodedData)
        {
            byte[] numArray = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(numArray);
        }

        public static string Encode(string plainText)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
        }

        public static bool IsBase64Encode(string value)
        {
            if (String.IsNullOrEmpty(value) || value.Length % 4 != 0 || value.Contains<char>(' ') || value.Contains<char>('\t') || value.Contains<char>('\r') || value.Contains<char>('\n'))
            {
                return false;
            }
            int length = value.Length - 1;
            if (value[length] == '=')
            {
                length--;
            }
            if (value[length] == '=')
            {
                length--;
            }
            for (int i = 0; i <= length; i++)
            {
                if (!Base64Helper.Base64Chars.Contains<char>(value[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}