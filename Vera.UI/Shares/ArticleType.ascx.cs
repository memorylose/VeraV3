using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vera.Interface.BLL;

namespace Vera.UI.Shares
{
    public partial class ArticleType : System.Web.UI.UserControl
    {
        public string ArticleTypeHtml = "";
        public IArticleRepository articleRep { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var articleList = articleRep.GetIndexArticleType();
            foreach (var list in articleList)
            {
                ArticleTypeHtml += "<div class=\"row bt-margin\">";
                ArticleTypeHtml += "<div class=\"l-cate-name\"><a href=\"/home/type/" + list.TypeId + "\">" + list.TypeName + "</a></div>";
                ArticleTypeHtml += "<div class=\"l-cate-name-d\">(" + list.TypeCount + ")</div>";
                ArticleTypeHtml += "</div>";
            }
        }
    }
}