using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Vera.UI.Pager
{
    public class Pager
    {
        public string GetPager(int totalCount, int pageSize, int currentPage, string pageQuerystringName, string redirectPage, string redirectSign, string enableClass, string disableClass, bool isClearBoth, ref int startPage, ref int endPage)
        {
            if (currentPage == 0)
            {
                startPage = 1;
                endPage = pageSize;
            }
            else
            {
                startPage = (currentPage - 1) * pageSize + 1;
                endPage = currentPage * pageSize;
            }

            decimal totalPager = Math.Ceiling((decimal)totalCount / (decimal)pageSize);
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 1; i <= totalPager; i++)
            {
                if (i == currentPage)
                {

                    strBuilder.Append("<div class=\"" + enableClass + "\">" + i + "</div>");
                }
                else
                {
                    if (currentPage == 0 && i == 1)
                    {
                        strBuilder.Append("<div class=\"" + enableClass + "\">" + i + "</div>");
                    }
                    else
                    {
                        strBuilder.Append("<div class=\"" + disableClass + "\"><a href=\"" + redirectPage + "" + redirectSign + "" + pageQuerystringName + "=" + i + "\">" + i + "</a></div>");
                    }
                }
            }
            if (isClearBoth)
                strBuilder.Append("<div style=\"clear:both;\"></div>");
            return strBuilder.ToString();
        }
    }
}