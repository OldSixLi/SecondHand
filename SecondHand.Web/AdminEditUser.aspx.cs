using System;
using System.Collections.Generic;
using SecondHand.BLL;
using SecondHand.Model;
namespace SecondHand.Web
{
    #region 页面加载
    public partial class AdminEditUser : System.Web.UI.Page
    {
        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var usermodel1 = Session["userinfo"] as UsersModel;
                if (usermodel1 != null)
                {
                    string usertype = usermodel1.UserType;
                    if (usertype == "2")
                    {
                        string id = Request["iiid"].ToString();
                        try
                        {
                            var bll = new BLL.Users();
                            var infobll = new BLL.UserInfo();
                            var usermodel = new UsersModel();
                            usermodel = bll.GetModel(Convert.ToInt32(id));
                            var userinfo = new UserInfoModel();
                            List<Model.UserInfoModel> list = infobll.GetModelList("UserID=" + id);
                            string isadmin = usermodel.UserType;
                            int num = list.Count;
                            if (num > 0)
                            {
                                TextBoxu.Text = list[0].UserName;
                                TextBoxp.Text = list[0].PhoneNum;
                                TextBoxe.Text = list[0].Email;
                                TextBoxQ.Text = list[0].QQ;
                                TextBoxc.Text = list[0].ContentNum;
                            }
                            CheckBox1.Checked = isadmin == "2";
                        }
                        catch (Exception)
                        {
                            UiHelper.AlertAndRedirect(this, "未知错误，请返回重试", "AdminUsers.aspx");
                        }
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
        }
        #endregion         #region 删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(Request["iiid"].ToString());
            try
            {
                bool delete = new UserInfo().Delete(userid);
                bool isdelete = new Users().Delete(userid);
                if (isdelete && delete)
                {
                    UiHelper.AlertAndRedirect(this, "删除成功", "AdminUsers.aspx");
                    new AllGoods().DeletebyUserId(userid);
                    new GoodsDetail().DeletebyUserId(userid);
                }
                else
                {
                    UiHelper.Alert(this, "删除失败，请刷新数据后重试");
                }
            }
            catch (Exception)
            {
                UiHelper.Alert(this, "未知错误，请刷新数据重试");
            }
        }
        #endregion         #region 修改资料
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(Request["iiid"].ToString());
            var model = new UserInfoModel
            {
                ContentNum = TextBoxc.Text,
                PhoneNum = TextBoxp.Text,
                Email = TextBoxe.Text,
                QQ = TextBoxQ.Text,
                UserName = TextBoxu.Text,
                UserID = userid
            };
            bool issuccess = new UserInfo().AdminUpdateInfo(model);
            if (issuccess)
            {
                UiHelper.AlertAndRedirect(this, "用户资料修改成功", "AdminEditUser.aspx?iiid=" + userid.ToString());
                if (CheckBox1.Checked)
                {
                    var user = new Model.UsersModel();
                    user.UserType = "2";
                    user.UserID = userid;
                    bool success = new Users().UpdateAdmin(user);
                    if (!success)
                    {
                        UiHelper.Alert(this, "设置管理员失败！");
                    }
                }
                else
                {
                    var user = new Model.UsersModel();
                    user.UserType = "1";
                    user.UserID = userid;
                    bool success = new Users().UpdateAdmin(user);
                    if (!success)
                    {
                        UiHelper.Alert(this, "修改管理员权限失败！");
                    }
                }
            }
        }
        #endregion         #region 修改密码
        protected void btnPassChange_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(Request["iiid"].ToString());
            var users = new UsersModel
            {
                PassWord = newPassWord.Text,
                UserID = userid
            };
            bool issuccess = new Users().UpdatePass(users);
            UiHelper.Alert(this, issuccess ? "修改成功" : "修改失败");
        }
        #endregion         #region 退出登录
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session["userinfo"] = null;
            Session.Abandon();
            UiHelper.Redirect(this.Page, "UserLogin.aspx");
        }
        #endregion     }     #endregion }
