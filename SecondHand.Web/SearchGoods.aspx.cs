using System;
using System.Data;
using SecondHand.BLL;
 namespace SecondHand.Web
{
    public partial class SearchGoods : System.Web.UI.Page
    {
        readonly AllGoods _bll = new AllGoods();
        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string keywords = Request["key"].ToString();
                PageIndex(keywords);
                lblClassName.Text = keywords;
            }
        }         #endregion          #region 数据绑定
        /// <summary>
        /// 返回总页数
        /// </summary>
        /// <returns></returns>
        private void PageIndex(string keywords)
        {
            GoodsDetail bll = new GoodsDetail();
            DataSet ds = bll.GetGoodsByKeyWords(keywords);
            RepeaterGoods.DataSource = ds;
            RepeaterGoods.DataBind();
         }
        #endregion
     }
}