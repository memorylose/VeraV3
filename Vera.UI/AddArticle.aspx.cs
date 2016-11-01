using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vera.Interface.BLL;
using Vera.UI.Base;
using Vera.UI.Constant;

namespace Vera.UI
{
    public partial class AddArticle : BasePage
    {
        public IArticleRepository articleRep { get; set; }
        public string errMsg;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindType();
            }
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            Vera.Model.Articles model = new Vera.Model.Articles();
            model.Title = txtTitle.Value;
            model.Summary = "";
            model.Contents = Request["content"].ToString();
            model.CreateDate = DateTime.Now;
            model.CreateUserId = Convert.ToInt32(Session[SessionContainer.Login]);
            model.TypeId = Convert.ToInt32(DropDownList1.SelectedValue);

            string validation = articleRep.AddArticleValidation(model);
            if (validation == string.Empty)
            {
                if (articleRep.AddArticle(model))
                {
                    Response.Redirect("/home");
                }
                else
                {
                    errMsg = "添加文章失败，具体原因不明";
                }
            }
            else
            {
                errMsg = validation;
            }
        }

        private void BindType()
        {
            DropDownList1.DataSource = articleRep.GetArticleType();
            DropDownList1.DataTextField = "TypeName";
            DropDownList1.DataValueField = "TypeId";
            DropDownList1.DataBind();
        }
    }
}