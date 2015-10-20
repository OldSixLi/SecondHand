using System;
using System.Data;
using System.Web.UI.WebControls;
using SecondHand.BLL;
namespace SecondHand.Web
{
    public partial class UserLogin : System.Web.UI.Page
    {
        readonly AllGoods _bll = new AllGoods();
         #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Webpageindex == 0)
                {
                    Webpageindex = 1;
                }
                PageIndex();
            }
        }
        #endregion
         #region 私有属性
        /// <summary>
        /// 当前页  根据发布时间分类
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
        #endregion
         #region 数据绑定
        /// <summary>
        /// 最新发布商品的绑定
        /// </summary>
        /// <returns></returns>
        private void PageIndex()
        {
            int totalpage = 0;
            int index = 0;
            DataTable dt = _bll.GetAllGoodsByPage("PublishTime", 1, 16, Convert.ToInt32(Webpageindex), ref totalpage, ref  index);
            Webpageindex = index;
            WebPageCount = totalpage;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["GoodsImg"].ToString().Trim().Length == 0)
                {
                    dr["GoodsImg"] = "Images/GoodsImg/2.png";
                }
            }
            GoodsByTime.DataSource = dt;
            GoodsByTime.DataBind();
            string src = "";
        }
        #endregion
         #region 翻页事件
        //回到上一页
        protected void Goup(object sender, CommandEventArgs e)
        {
            Webpageindex = Webpageindex - 1;
            PageIndex();
        }
        //下一页
        protected void Gonp(object sender, CommandEventArgs e)
        {
            Webpageindex = Webpageindex + 1;
            PageIndex();
        }
        //前边2页
        protected void GOjian2(object sender, CommandEventArgs e)
        {
            Webpageindex = Webpageindex - 2;
            PageIndex();
        }
        //前边1页
        protected void GOjian1(object sender, CommandEventArgs e)
        {
            Webpageindex = Webpageindex - 1;
            PageIndex();
        }
        //后边1页
        protected void GOjia1(object sender, CommandEventArgs e)
        {
            Webpageindex = Webpageindex + 1;
            PageIndex();
        }
        //后边2页
        protected void GOjia2(object sender, CommandEventArgs e)
        {
            Webpageindex = Webpageindex + 2;
            PageIndex();
        }
        #endregion
    }
}