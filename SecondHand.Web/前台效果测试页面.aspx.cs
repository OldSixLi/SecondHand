using System;
using System.Data;
using System.Web;
using SecondHand.BLL;
namespace SecondHand.Web
{
    public partial class 前台效果测试页面 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new AllGoods().GetAllList();
            int totalpage = 0;
            int index = 0;
            DataTable dt = new AllGoods().GetAllGoodsByPage("PublishTime", 1, 3, 1, ref totalpage, ref index);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            thumbnaiL.DataSource = dt;
            thumbnaiL.DataBind();
        }
        #region 点击图片后不在网页上打开，而是下载
        protected void Aclick(object sender, EventArgs e)
        {             string a = "aa.aa.aaa.xlsx";
            string sp = a.Substring(a.LastIndexOf(".") + 1);// TODO 获取最后的后缀名
            Response.ContentType = "application/x-msdownload";
            string filename = HttpUtility.UrlEncode("显示" + "." + sp);
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            string filepath = "Images/1.xlsx";
            Response.TransmitFile(Server.MapPath(filepath));
        }
        #endregion     }
}