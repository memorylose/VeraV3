using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vera.Interface.BLL;

namespace Vera.UI.Shares
{
    public partial class HotArticles : System.Web.UI.UserControl
    {
        public string RankListhtml = "";
        public IArticleRepository articleRep { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var articleList = articleRep.GetHotArticles();
            foreach (var list in articleList)
            {
                string title = list.Title;
                if (title.Length >= 15)
                    title = title.Substring(0, 15) + "...";
                RankListhtml += "<div class=\"row bt-margin\">";
                RankListhtml += "<div class=\"l-read-name\"><a href=\"article/" + Convert.ToInt32(list.ArticleId) + "\">" + list.Title + "</a></div>";
                RankListhtml += "<div class=\"l-read-name-d\"></div>";
                RankListhtml += "</div>";
            }
        }
    }
}