using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vera.Utility
{
    public class DateOperator
    {
        public static string ShowMonth(string month)
        {
            string result = string.Empty;
            string[] monthArray = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二" };
            for (int j = 1; j < monthArray.Length + 1; j++)
            {
                if (j == Convert.ToInt32(month))
                {
                    result = monthArray[j - 1].ToString();
                    break;
                }
            }
            return result;
        }
    }
}
