using System;
using SecondHand.BLL;
using SecondHand.Model;
 namespace SecondHand.Web
{
    public partial class PersonChangePass : System.Web.UI.Page
    {
        private static string _logincode;
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
                    _logincode = infomodel.LoginCode;
                    var allgoodsbll = new AllGoods();
                    lblGoodsCount.Text = allgoodsbll.Getgoodscounbyuserid(id.ToString()).ToString();
                    lblName.Text = infomodel.gg.UserName;
                    UserIconImg.Src = infomodel.gg.UserIcon;
                }
                //不存在session
                else
                {
                    UiHelper.AlertAndRedirect(this, "请登录后再进行操作", "UserLogin.aspx");
                }
            }
        }
        #endregion
         #region 修改操作
        protected void btnChange_Click(object sender, EventArgs e)
        {
            string oldpassword = oldpass.Text;
            string newpassword = newpass.Text;
            string repeat = repeatpass.Text;
            var userinfo = Session["userinfo"] as UsersModel;
            if (userinfo != null)
            {
                if (oldpassword == userinfo.PassWord)
                {
                    if (oldpassword != newpassword)
                    {
                        if (newpassword == repeat)
                        {
                            var bll = new Users();
                            var users = new UsersModel
                            {
                                PassWord = newpassword,
                                UserID = userinfo.UserID
                            };
                            bool issuccess = bll.UpdatePass(users);
                            if (issuccess)
                            {
                                Session["userinfo"] = null;
                                Session.Abandon();
                                UiHelper.Alert(this, "密码修改成功，请重新登录");
                                UiHelper.Redirect(this.Page, "UserLogin.aspx");
                             }
                            else
                            {
                                UiHelper.Alert(this, "未知错误，修改失败");
                            }
                        }
                        else
                        {
                            UiHelper.Alert(this, "两次新密码输入不一致，请重新输入！");
                        }
                    }
                    else
                    {
                        UiHelper.Alert(this, "新密码不能与原密码相同");
                    }
                 }
                else
                {
                    UiHelper.Alert(this, "原密码输入错误，请重新输入");
                }
            }
            else
            {
                UiHelper.AlertAndRedirect(this, "请登录后在进行操作", "UserLogin.aspx");
            }
         }
         #endregion
    }
}