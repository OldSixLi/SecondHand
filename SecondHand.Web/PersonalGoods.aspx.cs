using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SecondHand.BLL;
using SecondHand.Model;
namespace SecondHand.Web
{
    public partial class PersonalGoods : System.Web.UI.Page
    {
        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var infomodel = Session["userinfo"] as UsersModel;
                if (infomodel != null)
                {
                    //获取当前的用户ID
                    int id = infomodel.UserID;
                    string logincode = infomodel.LoginCode;
                    var bll = new Users();
                    UsersModel userinfomodel = bll.GetUserInfo(logincode);
                    AllGoods allgoodsbll = new AllGoods();
                    lblGoodsCount.Text = allgoodsbll.Getgoodscounbyuserid(id.ToString()).ToString();
                    //TODO 总数量后期读取，如果不行就修改为性别与注册时间                     UserIconImg.Src = infomodel.gg.UserIcon;
                    lblName.Text = infomodel.gg.UserName;
                    //UserIconImg.Src = "http://placehold.it/200x200";
                    //数据绑定
                    DatabindGoods(id.ToString());
                }
                //不存在session
                else
                {
                    UiHelper.AlertAndRedirect(this, "请登录后再进行操作", "UserLogin.aspx");
                }
            }
        }
        #endregion         #region 数据绑定
        private void DatabindGoods(string userid)
        {
            AllGoods bll = new AllGoods();
            RepeaterGoods.DataSource = bll.GetPersonPublishGoods(userid);
            RepeaterGoods.DataBind();
        }
        #endregion         #region 删除物品
        protected void Deleter(object sender, CommandEventArgs e)
        {
            try
            {
                var infomodel = Session["userinfo"] as UsersModel;
                if (infomodel != null)
                {
                    //获取当前的用户ID
                    string userid = infomodel.UserID.ToString();
                    string goodsid = e.CommandArgument.ToString();
                    bool isdelete = new GoodsDetail().Delete(goodsid);
                    bool isdelete1 = new AllGoods().Delete(Convert.ToInt32(goodsid));
                    if (isdelete && isdelete1)
                    {
                        UiHelper.Alert(this, "删除成功");
                        DatabindGoods(userid);
                    }
                    else
                    {
                        UiHelper.Alert(this, "删除失败，请尝试重新操作");
                        DatabindGoods(userid);
                    }
                }
            }
            catch (Exception)
            {
                UiHelper.Alert(this, "未知错误");
            }
        }
        #endregion
    }
}