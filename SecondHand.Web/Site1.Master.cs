//****************************模版页后台**************************************//
using System;
using System.Data;
using SecondHand.BLL;
using SecondHand.Model;
namespace SecondHand.Web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        #region 页面加载，判断是否存在SESSION
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AllGoods bll = new AllGoods();
                Allgoodscount.Text = bll.GetGoodsCount().ToString();
                var userinfomodel = Session["userinfo"] as UsersModel;
                if (userinfomodel != null)
                {
                    if (userinfomodel.UserType == "2")
                    {
                        panelregisted.Visible = false;
                        panelunregist.Visible = false;
                        PanelManager.Visible = true;
                    }
                    else
                    {
                        panelregisted.Visible = true;
                        panelunregist.Visible = false;
                    }
                    var usermodel = Session["userinfo"] as UsersModel;
                    {
                        string aaaa = usermodel.gg.UserName;
                    }
                    LabelName.Text = usermodel.UserType == "1" ? usermodel.gg.UserName : "管理员";
                    //判断是否为管理员用户，并为label赋值
                }
            }
        }
        #endregion         #region 登陆按钮功能
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string logincode = TextEmail.Text;
            string password = TextPassWord.Text;
            if (logincode.Trim() == "" || password.Trim() == "")
            {
               UiHelper.Alert(this.Page,"邮箱密码不能为空");
            }
            else
            {
                  var bll = new BLL.Users();
            int check = bll.LoginTest(logincode, password);
            #region //根据情况进行判断
            switch (check)
            {
                //普通用户
                case 0:
                    panelregisted.Visible = true;
                    panelunregist.Visible = false;
                    UsersModel usermodel = bll.GetUserInfo(logincode);
                    Session["userinfo"] = usermodel;
                    UsersModel usermodel3 = Session["userinfo"] as UsersModel;
                    if (usermodel3 != null)
                    {
                        string aaaaaa = usermodel3.gg.UserName;
                    }
                    LabelName.Text = usermodel.gg.UserName;
                    break;
                case 1:
                    panelregisted.Visible = false;
                    panelunregist.Visible = false;
            PanelManager.Visible = true;
                    UsersModel usermode = bll.GetUserInfo(logincode);
                    Session["userinfo"] = usermode;
                    var usermodel4 = Session["userinfo"] as UsersModel;//把session取出来的时候需要转换类型
                    if (usermodel4 != null)
                    {
                        string aaaa = usermodel4.gg.UserName;
                    }
                    LabelName.Text = "管理员";
                    break;
                case 2:
                   UiHelper.Alert(this.Page, "您的密码输入错误，请核实后重新输入");
                    break;
                case 3:
                    UiHelper.AlertAndRedirect(this.Page, "登录失败，不存在此用户", "UserLogin.aspx");
                    break;
            }
            #endregion
            }         }
        #endregion         #region 注册按钮
        protected void btnRegist_Click(object sender, EventArgs e)
        {
            var usermodel = new UsersModel();
            var userinfomodel = new UserInfoModel();
            //用户信息
            #region 插入users和userinfo表相关信息
            string name = username.Text;
            int length = System.Text.Encoding.Default.GetByteCount(name);
            if (length <= 12)
            {
                usermodel.LoginCode = useremail.Text;//登录名
                if (registpassword.Text == repeatpassword.Text)
                {
                    usermodel.PassWord = registpassword.Text;//密码
                }
                else
                {
                    UiHelper.Alert(this.Page, "两次密码输入不一致，请核实后再进行注册");
                    return;
                }
            }
            else
            {
                UiHelper.Alert(this.Page, "您的用户名过长，请修改");
                return;
            }
            usermodel.UserType = "1";//用户类别，默认为普通用户
            //插入users表
            var userbll = new Users();
            int isRegist = userbll.Add(usermodel);
            //获得用户ID并存入详细信息
            userinfomodel.UserID = userbll.GetbynameModel(useremail.Text).UserID;
            userinfomodel.UserName = username.Text;
            userinfomodel.Email = useremail.Text;
            userinfomodel.Sex = !sex.Checked ? "女" : "男";//性别选择
            userinfomodel.PhoneNum = txtPhoneNum.Text ?? "";
            userinfomodel.QQ = txtQQ.Text ?? "";
            #region 用户注册其他信息功能建设中，默认为空
            //功能建设中，默认为空
            userinfomodel.ContentNum = "";
            userinfomodel.UserIcon = "UserIcon/usericon.png";
            #endregion
            var userinfobll = new UserInfo();
            var issuccess=  userinfobll.Add(userinfomodel);
            #endregion
          UiHelper.Alert(this.Page, issuccess ==true ? "恭喜你！注册成功，可以浏览更多网站信息。" : "对不起，此邮箱已被注册，请重新编辑登录邮箱");         }
        #endregion         #region 个人中心按钮功能
        protected void btnSelf_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonalEidt.aspx");
        }
        #endregion         #region 搜索按钮功能
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var usermodel = Session["userinfo"] as UsersModel;
            if (usermodel != null)
            {
                string keywords = TextSearch.Text;
                if (keywords.Trim() != "")
                {
                    UiHelper.Redirect(this.Page, "SearchGoods.aspx?key=" + keywords);
                }
                else
                {
                    UiHelper.Alert(this.Page, "搜索关键字不能为空！");
                }             }
            else
            {
                UiHelper.Alert(this.Page, "登陆后才能搜索哦");
            }
        }
        #endregion         #region 信息提醒 （待写）
        //TODO   代写
        protected void btnRemind_Click(object sender, EventArgs e)
        {
            UiHelper.Alert(this.Page, "该功能建设中，敬请期待！");
        }
        #endregion         #region 管理员入口
        protected void btnmanager_Click(object sender, EventArgs e)
        {
            UiHelper.Redirect(this.Page, "AdminBack.aspx");
        }
        #endregion         #region 退出登录
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session["userinfo"] = null;
            Session.Abandon();
            UiHelper.Redirect(this.Page, "UserLogin.aspx");
        }
        #endregion         #region 管理员退出登录
        protected void btnExit1_Click(object sender, EventArgs e)
        {
            Session["userinfo"] = null;
            Session.Abandon();
            UiHelper.Redirect(this.Page, "UserLogin.aspx");
        }
        #endregion
    }
}