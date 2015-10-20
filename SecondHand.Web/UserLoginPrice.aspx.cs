using System;
using System.Data;
using System.Web.UI.WebControls;
using SecondHand.BLL;
namespace SecondHand.Web
{
    public partial class UserLoginPrice : System.Web.UI.Page
    {
        readonly AllGoods _bll = new AllGoods();
        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Webpageindex1 == 0)
                {
                    Webpageindex1 = 1;
                }
                PageIndex1();
            }
        }
        #endregion         #region 私有属性
        public long Webpageindex1
        {
            get
            {
                if (ViewState["Webpageindex1"] != null)
                {
                    try
                    {
                        return Convert.ToInt32(ViewState["Webpageindex1"]);
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
                ViewState["Webpageindex1"] = value;
            }
        }
        public long WebPageCount1
        {
            get
            {
                if (ViewState["WebPageCount1"] != null)
                {
                    try
                    {
                        return Convert.ToInt32(ViewState["WebPageCount1"]);
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
                ViewState["WebPageCount1"] = value;
            }
        }
        #endregion         #region 根据价格绑定
        /// <summary>
        /// 根据价格绑定
        /// </summary>
        private void PageIndex1()
        {
            int totalpage = 0;
            int index = 0;
            DataTable dt = _bll.GetAllGoodsByPage("convert(int,cast(Price  as float))", 1, 16, Convert.ToInt32(Webpageindex1), ref totalpage, ref  index);
            Webpageindex1 = index;
            WebPageCount1 = totalpage;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["GoodsImg"].ToString().Trim().Length == 0)
                {
                    dr["GoodsImg"] = "Images/GoodsImg/2.png";
                }
            }
            Repeat1.DataSource = dt;
            Repeat1.DataBind();
        }
        #endregion         #region 价格翻页事件
        //回到上一页
        protected void Goup1(object sender, CommandEventArgs e)
        {
            Webpageindex1 = Webpageindex1 - 1;
            PageIndex1();
        }
        //下一页
        protected void Gonp1(object sender, CommandEventArgs e)
        {
            Webpageindex1 = Webpageindex1 + 1;
            PageIndex1();
        }
        //前边2页
        protected void GOjian21(object sender, CommandEventArgs e)
        {
            Webpageindex1 = Webpageindex1 - 2;
            PageIndex1();
        }
        //前边1页
        protected void GOjian11(object sender, CommandEventArgs e)
        {
            Webpageindex1 = Webpageindex1 - 1;
            PageIndex1();
        }
        //后边1页
        protected void GOjia11(object sender, CommandEventArgs e)
        {
            Webpageindex1 = Webpageindex1 + 1;
            PageIndex1();
        }
        //后边2页
        protected void GOjia21(object sender, CommandEventArgs e)
        {
            Webpageindex1 = Webpageindex1 + 2;
            PageIndex1();
        }
        #endregion
    }
}