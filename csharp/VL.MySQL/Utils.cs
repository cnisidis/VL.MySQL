using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.MySQL
{
    public static class Utils
    {
        public static string GetMySqlDataType(Type csharpType)
        {
            if (csharpType == typeof(int) || csharpType == typeof(long))
                return "INT";
            if (csharpType == typeof(string))
                // Default to a reasonable VARCHAR size if length isn't specified, or TEXT
                return "VARCHAR(255)";
            if (csharpType == typeof(DateTime))
                return "DATETIME";
            if (csharpType == typeof(decimal))
                return "DECIMAL(18, 4)"; // Example precision
            if (csharpType == typeof(bool))
                return "TINYINT(1)";
            if (csharpType == typeof(double) || csharpType == typeof(float))
                return "DOUBLE";

            // Default fallback
            return "TEXT";
        }
    }
}
