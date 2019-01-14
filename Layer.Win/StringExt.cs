using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Win
{
    public static class StringExt
    {
        public static bool IsNumeric(this string text)
        {
            return double.TryParse(text, out double test);
        }
    }
}
