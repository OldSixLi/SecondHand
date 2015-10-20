using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SecondHand.BLL;
using SecondHand.Model;
 namespace SecondHand.Web
{
    public partial class AdminBack : System.Web.UI.Page
    {
        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var usermodel = Session["userinfo"] as UsersModel;
                if (usermodel != null)
                {
                    string usertype = usermodel.UserType;
                    if (usertype == "2")
                    {
                        AllGoods bll = new AllGoods();
                        lblGoodsCount.Text = bll.GetGoodsCount().ToString();
                        lblUserCount.Text = bll.GetusersCount().ToString();
                        lblCommentCount.Text = bll.GetCommentsCount().ToString();
                    }
                    else
                    {
                        UiHelper.AlertAndRedirect(this, "对不起，您没有权限浏览此页面", "UserLogin.aspx");
                    }
                }
                else
                {
                    UiHelper.AlertAndRedirect(this, "对不起，请登录后在进行操作", "UserLogin.aspx");
                }
            }
        }         #endregion         #region 退出登录
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session["userinfo"] = null;
            Session.Abandon();
            UiHelper.Redirect(this.Page, "UserLogin.aspx");
        }
        #endregion     } 
}