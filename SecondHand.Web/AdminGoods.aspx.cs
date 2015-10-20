using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using SecondHand.BLL;
using SecondHand.Model;
 namespace SecondHand.Web
{
    public partial class AdminGoods : System.Web.UI.Page
    {
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
        #endregion          #region 物品列表绑定
        public void NewDatabind(int count)
        {
            int totalpage = 0;
            int index = 0;
            int totalrecord = 0;
            DataTable dt = new GoodsDetail().GetAllGoodsByPage("PublishTime", 1, count, Convert.ToInt32(Webpageindex), ref totalpage, ref  index, ref totalrecord);
            Webpageindex = index;
            WebPageCount = totalpage;
            Webpagerecord = totalrecord;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    if (dr["GoodsImg"].ToString().Trim().Length == 0)
            //    {
            //        dr["GoodsImg"] = "Images/GoodsImg/2.png";
            //    }
            //}
            Repeatergoods.DataSource = dt;
            Repeatergoods.DataBind();
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
        /// <summary>
        /// 总页数
        /// </summary>
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
        /// <summary>
        /// 总记录数
        /// </summary>
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
        #endregion          #region 删除功能
        protected void Delete(object sender, CommandEventArgs e)
        {
            //后边2页
            try
            {
                int count = Convert.ToInt32(countDDL.SelectedValue);
                string goodsid = e.CommandArgument.ToString();
                bool isdelete = new GoodsDetail().Delete(goodsid);
                bool isdelete1 = new AllGoods().Delete(Convert.ToInt32(goodsid));
                if (isdelete1)
                {
                    UiHelper.Alert(this, "删除成功");
                    NewDatabind(count);
                }
                else
                {
                    UiHelper.Alert(this, "删除失败");
                    NewDatabind(count);
                }
            }
            catch (Exception)
            {
                UiHelper.Alert(this, "未知错误");
            }
        }
        #endregion          #region 翻页事件
        //回到上一页
        protected void Goup(object sender, CommandEventArgs e)
        {
            int count = Convert.ToInt32(countDDL.SelectedValue);
            Webpageindex = Webpageindex - 1;
            NewDatabind(count); ;
        }
        //下一页
        protected void Gonp(object sender, CommandEventArgs e)
        {
            int count = Convert.ToInt32(countDDL.SelectedValue);
            Webpageindex = Webpageindex + 1;
            NewDatabind(count); ;
        }
        //前边2页
        protected void GOjian2(object sender, CommandEventArgs e)
        {
            int count = Convert.ToInt32(countDDL.SelectedValue);
            Webpageindex = Webpageindex - 2;
            NewDatabind(count); ;
        }
        //前边1页
        protected void GOjian1(object sender, CommandEventArgs e)
        {
            int count = Convert.ToInt32(countDDL.SelectedValue);
            Webpageindex = Webpageindex - 1;
            NewDatabind(count); ;
        }
        //后边1页
        protected void GOjia1(object sender, CommandEventArgs e)
        {
            int count = Convert.ToInt32(countDDL.SelectedValue);
            Webpageindex = Webpageindex + 1;
            NewDatabind(count); ;
        }
        //后边2页
        protected void GOjia2(object sender, CommandEventArgs e)
        {
            int count = Convert.ToInt32(countDDL.SelectedValue);
            Webpageindex = Webpageindex + 2;
            NewDatabind(count); ;
        }
        #endregion          #region 选择每页显示数据
        protected void countDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(countDDL.SelectedValue);
            NewDatabind(count);
        }
        #endregion          #region 刷新数据
        protected void btnF5_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(countDDL.SelectedValue);
            NewDatabind(count); ;
        }
        #endregion         #region 退出登录
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session["userinfo"] = null;
            Session.Abandon();
            UiHelper.Redirect(this.Page, "UserLogin.aspx");
        }
        #endregion     }
}