using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class ToStringUpperCaseExtensionDemo
    {
        public static string ToStringUpperCase(this string str)
        {
            return str.ToUpper().Trim();
        }
        public static int Linenumber(this Exception ex)
        {
            int lineNumber =  Convert.ToInt32(ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(":line") + 5)); 

            return lineNumber;
        }
    }
}
