using System;
using System.IO;
using SecondHand.BLL;
using SecondHand.Model; namespace SecondHand.Web
{
    public partial class PersonIconEdit : System.Web.UI.Page
    {
        private static string _filetxt;
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
                    //TODO 总数量后期读取，如果不行就修改为性别与注册时间
                    lblName.Text = infomodel.gg.UserName;
                    UserIconImg.Src = infomodel.gg.UserIcon;
                    ImgIcon.Src = infomodel.gg.UserIcon;                 }
                //不存在session
                else
                {
                    UiHelper.AlertAndRedirect(this, "请登录后再进行操作", "UserLogin.aspx");
                }
            }
        }         #endregion         #region 上传图片
        protected void btnFileUpload_Click(object sender, EventArgs e)
        {             try
            {
                //存储图片到服务器
                string errorMessage = string.Empty;
                if (!this.fileAttachment.HasFile)
                {
                    UiHelper.Alert(this.Page, "请上传附件");
                    return;
                }
                string showItemPicName = this.fileAttachment.FileName;
                string filetype = showItemPicName.Substring(showItemPicName.LastIndexOf('.'));
                if (filetype.ToLower() != ".png" && filetype.ToLower() != ".gif" && filetype.ToLower() != ".jpg")
                {
                    UiHelper.Alert(this.Page, "请上传符合格式的附件");
                    return;
                }
                if (this.fileAttachment.FileBytes.Length > 2097152)
                {
                    UiHelper.Alert(this.Page, "附件大小不超过2M");
                    return;
                }
                string filename = "UserIcon/" + DateTime.Now.ToString("yyyyMMddHHmmss") + filetype;
                Directory.CreateDirectory(Path.GetDirectoryName(Server.MapPath(filename)));
                this.fileAttachment.SaveAs(Server.MapPath(filename));
                ImgIcon.Src = filename;
                _filetxt = filename;
            }
            catch (Exception ex)
            {
                UiHelper.Alert(this, "上传失败，未知错误！");
            }
        }         #endregion         #region 修改操作
        protected void Button1_Click(object sender, EventArgs e)
        {
            string usericonfiletxt = _filetxt;
            var infomodel = Session["userinfo"] as UsersModel;
            if (infomodel != null)
            {
                var userinfomodel = new UsersModel();
                string userid = infomodel.UserID.ToString();
                var bll = new UserInfo();
                bool issuccess = bll.UpdateUserIcon(userid, usericonfiletxt);
                if (issuccess)
                {
                    var userbll = new BLL.Users();
                    UsersModel usermodel = userbll.GetUserInfo(_logincode);
                    Session["userinfo"] = usermodel;
                    UiHelper.AlertAndRedirect(this, "修改成功", "PersonIconEdit.aspx");
                }
                else
                {
                    UiHelper.Alert(this, "修改成功");
                }             }
        }         #endregion
    }
}