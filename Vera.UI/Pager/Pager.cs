using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Vera.UI.Pager
{
    public class Pager
    {
        public void GetPager(int totalCount, int pageSize, int currentPage)
        {
            decimal totalPager = Math.Ceiling(Convert.ToDecimal(totalCount / pageSize));
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 1; i <= totalPager; i++)
            {
                if (currentPage == 0)
                {
                    strBuilder.Append("<div class=\"pager - e\">1</div>");

                }
            }
        }
    }
}