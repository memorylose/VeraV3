using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vera.Interface.BLL;
using Vera.UI.Constant;
using Vera.Utility;

namespace Vera.UI
{
    public partial class Articles : System.Web.UI.Page
    {
        public IArticleRepository articleRep { get; set; }
        public string Title;
        public string CrDate;
        public string TypeName;
        public string Contents;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.RouteData.Values["id"] != null && RegexOperator.ValidationQueryString(Page.RouteData.Values["id"]))
            {
                GetArticleDetail(Convert.ToInt32(Page.RouteData.Values["id"]));
            }
            else
            {
                Response.Redirect(RedirectUrl.Home);
            }
        }

        private void GetArticleDetail(int articleId)
        {
            var articleDetail = articleRep.GetArticleDetail(articleId);
            if (articleDetail != null)
            {
                Title = articleDetail.Title;
                CrDate = articleDetail.CreateDate.ToString(); ;
                TypeName = articleDetail.TypeName;
                Contents = articleDetail.Contents;
            }
            else
            {
                Response.Redirect(RedirectUrl.Home);
            }
        }
    }
}