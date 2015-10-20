using System;
using SecondHand.BLL;
 namespace SecondHand.Web
{
    public partial class GoodsByClass : System.Web.UI.Page
    {
        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string classid = Request["classid"];
                var secbll = new SecondClass();
                if (classid != "")
                {
                    DatabindGoods(classid);
                    lblClassName.Text = secbll.GetclassName(classid);
                }
                else
                {
                    UiHelper.Redirect(this, "UserLogin.aspx");
                }
            }
        }         #endregion
         #region 数据绑定
        private void DatabindGoods(string classid)
        {
            var bll = new GoodsDetail();
            RepeaterGoods.DataSource = bll.GetGoodsByClassid(classid);
            RepeaterGoods.DataBind();
        }
        #endregion
     }
}