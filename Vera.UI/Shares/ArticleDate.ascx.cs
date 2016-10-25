using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vera.Interface.BLL;

namespace Vera.UI.Shares
{

    public partial class ArticleDate : System.Web.UI.UserControl
    {
        public IArticleRepository articleRep { get; set; }
        public string ArticleDateHtml = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            var articleList = articleRep.GetIndexArticleDate();
            foreach (var list in articleList)
            {
                ArticleDateHtml += "<div class=\"row bt-margin\">";
                ArticleDateHtml += "<div class=\"l-cate-name\"><a href=\"\">" + DateTime.Parse(list.CrDate).Year.ToString() + "年" + DateTime.Parse(list.CrDate).Month.ToString() + "月" + "</a></div>";
                ArticleDateHtml += "<div class=\"l-cate-name-d\">(" + list.DateCount + ")</div>";
                ArticleDateHtml += "</div>";
            }
        }
    }
}