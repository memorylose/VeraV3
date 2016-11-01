using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vera.Utility
{
    public class RegexOperator
    {
        public const string QueryFormat = "^[0-9]*$";

        public static bool ValidationQueryString(object queryId)
        {
            if (queryId.ToString().Length > 5)
                return false;
            Regex regex = new Regex(QueryFormat);
            return regex.IsMatch(queryId.ToString());
        }

        public static bool ValidationIndexQUeryString(object queryId)
        {
            Regex regex = new Regex(QueryFormat);
            return regex.IsMatch(queryId.ToString());
        }
    }
}
