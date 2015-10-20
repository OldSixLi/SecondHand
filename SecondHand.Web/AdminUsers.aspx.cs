using System;
using System.Web.UI.WebControls;
using System.Data;
using SecondHand.BLL;
using SecondHand.Model;
 namespace SecondHand.Web
{
    public partial class AdminUsers : System.Web.UI.Page
    {
        readonly Users _bll = new Users();
        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(countDDL.SelectedValue);
            if (!IsPostBack)
            {
                 var usermodel = Session["userinfo"] as UsersModel;
                if (usermodel != null)
                {
                    string usertype = usermodel.UserType;
                    if (usertype == "2")
                    {
                        if (Webpageindex == 0)
                        {
                            Webpageindex = 1;
                        }
                        NewDatabind(count);
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
             }//绑定列表
        }
        #endregion          #region 刷新按钮
        protected void btnF5_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(countDDL.SelectedValue);
            NewDatabind(count);
        }
        #endregion          #region NewDatabind绑定方法
        public void NewDatabind(int count)
        {
            int totalpage = 0;
            int index = 0;
            int totalrecord = 0;
            DataTable dt = _bll.GetAllUserssByPage("RegTime", 1, count, Convert.ToInt32(Webpageindex), ref totalpage, ref  index, ref totalrecord);
            Webpageindex = index;
            WebPageCount = totalpage;
            Webpagerecord = totalrecord;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["RegTime"].ToString().Trim().Length != 0)
                {
                    DateTime a = DateTime.Now;
                    DateTime b = Convert.ToDateTime(dr["RegTime"]);
                    TimeSpan ts = a - b;
                    if (Convert.ToInt32(ts.Days) == 0)
                    {
                        dr["RegTime"] = "今天";
                    }
                    else
                    {
                        dr["RegTime"] = ts.Days.ToString() + "天前";
                    }
                }
                if (dr["UserType"].ToString() == "1")
                {
                    dr["UserType"] = "用户";
                }
                if (dr["UserType"].ToString() == "2")
                {
                    dr["UserType"] = "管理员";
                }
            }
            Repeaterusers.DataSource = dt;
            Repeaterusers.DataBind();
        }
        #endregion          #region 私有属性
        /// <summary>
        /// 当前页
        /// </summary>
        public long Webpageindex
        {
            get
            {
                if (ViewState["Webpageindex"] != null)
                {
                    try
                    {
                        return Convert.ToInt32(ViewState["Webpageindex"]);
                    }
                    catch
                    {
                        return 1;
                    }
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                ViewState["Webpageindex"] = value;
            }
        }
        public long WebPageCount
        {
            get
            {
                if (ViewState["WebPageCount"] != null)
                {
                    try
                    {
                        return Convert.ToInt32(ViewState["WebPageCount"]);
                    }
                    catch
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["WebPageCount"] = value;
            }
        }
        public long Webpagerecord
        {
            get
            {
                if (ViewState["Webpagerecord"] != null)
                {
                    try
                    {
                        return Convert.ToInt32(ViewState["Webpagerecord"]);
                    }
                    catch
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["Webpagerecord"] = value;
            }
        }
        #endregion          #region 翻页事件
        protected void Goup(object sender, CommandEventArgs e)
        {//回到上一页
            int count = Convert.ToInt32(countDDL.SelectedValue);
            Webpageindex = Webpageindex - 1;
            NewDatabind(count);
        }
        protected void Gonp(object sender, CommandEventArgs e)
        {//下一页
            int count = Convert.ToInt32(countDDL.SelectedValue);
            Webpageindex = Webpageindex + 1;
            NewDatabind(count);
        }
        protected void GOjian2(object sender, CommandEventArgs e)
        {//前边2页
            int count = Convert.ToInt32(countDDL.SelectedValue);
            Webpageindex = Webpageindex - 2;
            NewDatabind(count);
        }
        protected void GOjian1(object sender, CommandEventArgs e)
        {//前边1页
            int count = Convert.ToInt32(countDDL.SelectedValue);
            Webpageindex = Webpageindex - 1;
            NewDatabind(count);
        }
        protected void GOjia1(object sender, CommandEventArgs e)
        {//后边1页
            int count = Convert.ToInt32(countDDL.SelectedValue);
            Webpageindex = Webpageindex + 1;
            NewDatabind(count);
        }
        protected void GOjia2(object sender, CommandEventArgs e)
        {//后边2页
            int count = Convert.ToInt32(countDDL.SelectedValue);
            Webpageindex = Webpageindex + 2;
            NewDatabind(count);
        }
        #endregion          #region 删除功能
        protected void Delete(object sender, CommandEventArgs e)
        {//后边2页
            try
            {
                int count = Convert.ToInt32(countDDL.SelectedValue);
                int userid = Convert.ToInt32(e.CommandArgument.ToString());
                new UserInfo().Delete(userid);
                bool isdelete = new Users().Delete(userid);
                if (isdelete)
                {
                    UiHelper.Alert(this, "删除成功");
                    new AllGoods().DeletebyUserId(userid);
                    new GoodsDetail().DeletebyUserId(userid);
                    NewDatabind(count);
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
        #endregion          #region 下拉菜单每页显示条数
        protected void countDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(countDDL.SelectedValue);
            NewDatabind(count);
        }
        #endregion         #region 退出登录
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session["userinfo"] = null;
            Session.Abandon();
            UiHelper.Redirect(this.Page, "UserLogin.aspx");
        }
        #endregion      }
}