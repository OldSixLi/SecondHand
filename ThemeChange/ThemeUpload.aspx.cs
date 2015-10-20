using System;
using System.Data;
using System.IO;
using CST.InnovationVolumeSystem.UI;
using SecondHand.DAL;
using ThemeChange.Extension;

namespace ThemeChange
{
    public partial class ThemeUpload : System.Web.UI.Page
    {
        public static string HerfTheme;
        protected void page_PreInit(object sender, EventArgs e)
        {
            //Page.Theme = ThemeStatic.Theme;
            Page.Theme = ThemeStatic.Theme;
        }

        protected System.Web.UI.HtmlControls.HtmlLink css1;

        protected void Page_Load(object sender, EventArgs e)
        {
            css1.Attributes.Add("href", "App_Themes/Bootstrap/bootstrap.css");//添加样式引用
            if (!IsPostBack)
            {
                DropDataBind();

                ThemeHref();
            }
        }

        #region 上传按钮        
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region 存储图片到服务器
                string errorMessage = string.Empty;
                if (!this.fileAttachment.HasFile && this.fileAttachment.FileName == "")
                {
                    UIHelper.Alert(this.Page, "请上传附件");
                    return;
                }
                string showItemPicName = this.fileAttachment.FileName;
                if (this.fileAttachment.FileBytes.Length > 100048576)
                {
                    UIHelper.Alert(this.Page, "附件大小不超过100M");
                    return;
                }
                string filename = "~/App_Themes/" + this.ShowItemName.Text.Trim() + "/" + showItemPicName;
                Directory.CreateDirectory(Path.GetDirectoryName(Server.MapPath(filename)));
                this.fileAttachment.SaveAs(Server.MapPath(filename));
                //服务合同
                string newUrl = "../" + filename.Substring(2);
                #endregion
                #region 数据库操作插入相应的主题名字
                //用户
                //主题名字
                int n = Add(this.ShowItemName.Text.Trim());
                if (n > 0)
                {
                    UIHelper.Alert(this, "上传成功");
                    DropDataBind();
                }
                #endregion
            }
            catch (Exception ex)
            {
                UIHelper.Alert(this, "上传失败，未知错误！");
            }
        }
        #endregion

        #region 更换主题
        protected void btnChange_Click(object sender, EventArgs e)
        {
            ChangeTheme(dropTheme.SelectedItem.Value, 1006);
            UIHelper.Alert(this, "保存成功");

        }
        #endregion

        #region 数据库操作更换、添加主题的方法
        public void ChangeTheme(string theme, int userid)
        {
            string sql = @"update Users set UUU='" + theme + "' where userid=" + userid;
            DBHelper.ExecuteNonQuery(sql);
        }
        public int Add(string name)
        {
            string sql = @"insert into AdminUser (UserID ,ThemeName) values(100,'" + name + "')";
            int n = DBHelper.ExecuteNonQuery(sql);
            return n;
        }
        #endregion


        public void ThemeHref()
        {
            var path2 = this.Server.MapPath("/App_Themes/Admin/");
            HerfTheme = ThemeStatic.GetHerf(path2, "*.css");
        }

        /// <summary>
        /// 下拉菜单绑定
        /// </summary>
        public void DropDataBind()
        {
            string sql = @"select  *  from AdminUser";
            DataSet ds = DBHelper.GetDS(sql);
            dropTheme.DataSource = ds;
            dropTheme.DataTextField = "ThemeName";
            dropTheme.DataValueField = "ThemeName";
            dropTheme.DataBind();   
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
        }
    }
}