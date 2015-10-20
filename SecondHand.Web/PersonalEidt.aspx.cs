//个人信息资料页并且进行信息修改
using System;
using SecondHand.BLL;
using SecondHand.Model;
namespace SecondHand.Web
{
    public partial class PersonalEidt : System.Web.UI.Page
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
                    var allgoodsbll = new AllGoods();
                    UsersModel userinfomodel = bll.GetUserInfo(logincode);
                    #region 相关项赋值
                    lblGoodsCount.Text = allgoodsbll.Getgoodscounbyuserid(id.ToString()).ToString();
                    lblUserName1.Text = userinfomodel.gg.UserName;
                    lblName.Text = userinfomodel.gg.UserName;
                    lblQQNum.Text = userinfomodel.gg.QQ;
                    lblPhoneNum.Text = userinfomodel.gg.PhoneNum;
                    lblUserEmail.Text = userinfomodel.LoginCode;
                    txtuserName.Text = userinfomodel.gg.UserName;
                    txtPhoneNum.Text = userinfomodel.gg.PhoneNum;
                    txtQQNum.Text = userinfomodel.gg.QQ;
                    lblinfoEmai.Text = userinfomodel.gg.Email;
                    //lblContent.Text = userinfomodel.gg.ContentNum;
                    txtInfoEmail.Text = userinfomodel.gg.Email;
                    //txtContent.Text = userinfomodel.gg.ContentNum;
                    //UserIconImg.Src = "http://placehold.it/200x200";
                    //TODO  后期修改头像
                    UserIconImg.Src = userinfomodel.gg.UserIcon;
                    #endregion
                    //TODO 总数量后期读取，如果不行就修改为性别与注册时间
                }
                else
                {
                    //不存在session
                    UiHelper.AlertAndRedirect(this, "请登录后再进行操作", "UserLogin.aspx");
                }
            }
        }
        #endregion         #region 修改按钮，相关项隐藏与显示
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            lblUserName1.Visible = false;
            txtuserName.Visible = true;
            lblPhoneNum.Visible = false;
            txtPhoneNum.Visible = true;
            lblQQNum.Visible = false;
            txtQQNum.Visible = true;
            btnSave.Visible = true;
            btnEdit.Visible = false;
            //lblContent.Visible = false;
            //txtContent.Visible = true;
            lblinfoEmai.Visible = false;
            txtInfoEmail.Visible = true;
        }
        #endregion         #region 保存修改按钮，数据库修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 相关项隐藏与显示
            btnEdit.Visible = true;
            btnSave.Visible = false;
            lblUserName1.Visible = true;
            txtuserName.Visible = false;
            lblPhoneNum.Visible = true;
            txtPhoneNum.Visible = false;
            lblQQNum.Visible = true;
            txtQQNum.Visible = false;
            //lblContent.Visible = true;
            //txtContent.Visible = false;
            lblinfoEmai.Visible = true;
            txtInfoEmail.Visible = false;
            #endregion
            #region 修改model并且进行修改
            UserInfoModel userinfomodel = new UserInfoModel();
            userinfomodel.QQ = txtQQNum.Text;
            userinfomodel.PhoneNum = txtPhoneNum.Text;
            userinfomodel.UserName = txtuserName.Text;
            userinfomodel.ContentNum = " ";
            userinfomodel.Email = txtInfoEmail.Text;
            #endregion
            #region 修改的操作
            var sessionmodel = Session["userinfo"] as UsersModel;
            if (sessionmodel != null)
            {
                string logincode = sessionmodel.LoginCode;
                userinfomodel.UserID = sessionmodel.UserID;
                bool issuccess = new UserInfo().AdminUpdateInfo(userinfomodel);
                if (issuccess)
                {
                    Users bll = new BLL.Users();
                    UsersModel usermodel = bll.GetUserInfo(logincode);
                    Session["userinfo"] = usermodel;
                    //如果成功，刷新当前页面
                    UiHelper.AlertAndRedirect(this, "修改信息成功！", "PersonalEidt.aspx");
                }
                else
                {
                    UiHelper.Alert(this, "编辑失败！");
                }
            }
            else
            {
                UiHelper.Alert(this, "请登陆后在进行操作");
            }
            #endregion
        }
        #endregion
    }
}