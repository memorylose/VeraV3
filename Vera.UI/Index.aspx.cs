using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vera.Interface.BLL;
using Vera.UI.Constant;
using Vera.Utility;

namespace Vera.UI
{
    public partial class Index : System.Web.UI.Page
    {
        public IArticleRepository articleRep { get; set; }
        public StringBuilder ArticleListhtml = new StringBuilder();
        public string strPager;
        public string addHtml;

        protected void Page_Load(object sender, EventArgs e)
        {
            int curPage = 0;
            int typeid = 0;

            if (Page.RouteData.Values["pageid"] != null && RegexOperator.ValidationIndexQUeryString(Page.RouteData.Values["pageid"]))
            {
                curPage = Convert.ToInt32(Page.RouteData.Values["pageid"]);
            }

            if (Page.RouteData.Values["typeid"] != null && RegexOperator.ValidationIndexQUeryString(Page.RouteData.Values["typeid"]))
            {
                typeid = Convert.ToInt32(Page.RouteData.Values["typeid"]);
            }

            if (Page.RouteData.Values["curTypePage"] != null && RegexOperator.ValidationIndexQUeryString(Page.RouteData.Values["curTypePage"]))
            {
                curPage = Convert.ToInt32(Page.RouteData.Values["curTypePage"]);
            }


            int startPage = 0;
            int endPage = 0;
            int totalCount = articleRep.GetArticlesCountWithType(typeid);
            int pageSize = 10;


            string redirectPage = "/home/";
            if (Page.RouteData.Values["typeid"] != null)
            {
                redirectPage = "/home/type/" + typeid + "/";
            }

            string enableClass = "pager-e";
            string disableClass = "pager-d";
            bool isClearBoth = true;

            Pager.Pager pager = new Pager.Pager();
            strPager = pager.GetPager(totalCount, pageSize, curPage, redirectPage, enableClass, disableClass, isClearBoth, ref startPage, ref endPage);

            var articleList = articleRep.GetIndexArticleWithType(startPage, endPage, typeid);
            int userId = 0;
            bool isSign = false;

            if (Session[SessionContainer.Login] != null)
            {
                userId = Convert.ToInt32(Session[SessionContainer.Login]);
                isSign = true;
            }

            foreach (var list in articleList)
            {
                ArticleListhtml.Append("<div class=\"r-content-d\">");
                ArticleListhtml.Append("<div class=\"row row-marginb\">");
                ArticleListhtml.Append("<div class=\"col-md-1 bt-padding r-time-d\">");
                ArticleListhtml.Append("<div class=\"r-date-t\">");
                ArticleListhtml.Append("<div class=\"r-date-year\">" + DateTime.Parse(list.CreateDate.ToString()).Year.ToString() + "</div>");
                ArticleListhtml.Append("<div class=\"r-date-month\">" + DateOperator.ShowMonth(DateTime.Parse(list.CreateDate.ToString()).Month.ToString()) + "</div>");
                ArticleListhtml.Append("</div>");
                ArticleListhtml.Append("<div class=\"r-date-b\">");
                ArticleListhtml.Append(DateTime.Parse(list.CreateDate.ToString()).Day.ToString());
                ArticleListhtml.Append("</div>");
                ArticleListhtml.Append("</div>");
                ArticleListhtml.Append("<div class=\"col-md-10 bt-padding\">");
                ArticleListhtml.Append("<div class=\"r-title\"><a href=\"/article/" + list.ArticleId + "\">" + list.Title + "</a></div>");
                ArticleListhtml.Append("<div class=\"r-time-1\"><a href=\"Index.aspx?id=" + list.TypeId + "\">" + list.TypeName + "</a></div>");
                if (isSign)
                {
                    if (userId == list.CreateUserId)
                    {
                        ArticleListhtml.Append("<div class=\"r-time-1\"><a href=\"Article/ArticleModify.aspx?id=" + list.ArticleId + "\">" + "编辑" + "</a></div>");
                        ArticleListhtml.Append("<div class=\"r-time-1\"><a href=\"Article/ArticleModify.aspx?id=" + list.ArticleId + "\">" + "删除" + "</a></div>");
                    }
                }
                ArticleListhtml.Append("<div style=\"clear: both\"></div>");
                ArticleListhtml.Append("<div class=\"r-subject\">" + list.Summary + "</div>");
                ArticleListhtml.Append("</div>");
                ArticleListhtml.Append("</div>");
                ArticleListhtml.Append("</div>");
            }

            if (isSign)
            {
                addHtml = "<div class=\"l-personal-name-r\"><a href=\"/add\">添加新文章</a></div>";
            }
        }
    }
}