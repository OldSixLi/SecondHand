using System;
using System.Web.UI.WebControls;
using SecondHand.BLL;
using System.Data;
using SecondHand.Model;
namespace SecondHand.Web
{
    public partial class IntroduceGoods : System.Web.UI.Page
    {
        #region 定义变量
        readonly GoodsDetail _bll = new GoodsDetail();
        private static string _id;
        public String Goodsid
        {
            get { return _id; }
            set { _id = value; }
        }
        private static string _goodsuserid;
        public string GoodsUserId
        {
            get { return _goodsuserid; }
            set { _goodsuserid = value; }
        }
        private static string _replytowho;
        public string ReplyToWho
        {
            get { return _replytowho; }
            set { _replytowho = value; }
        }
        private static string _replyfromwho;
        public string ReplyFromWho
        {
            get { return _replyfromwho; }
            set { _replyfromwho = value; }
        }
        #endregion         #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Goodsid = Request.QueryString["wpad"];
                var model = Session["userinfo"] as UsersModel;
                if (model != null) ReplyFromWho = model.UserID.ToString();
                string a = Goodsid;
                if (a != null)
                {
                    #region 绑定到各个项
                    DataTable dt = _bll.Getdetailbyid(a);
                    if (dt.Rows.Count > 0)
                    {
                        goodsname.Text = dt.Rows[0]["GoodsName"].ToString();
                        username.Text = dt.Rows[0]["UserName"].ToString();
                        detail.Text = dt.Rows[0]["Detail"].ToString() + "<br/>（联系我的时候，请说明是在校园二手网看到的哦）";
                        price.Text = dt.Rows[0]["Price"].ToString();
                        Goodsimg.Src = dt.Rows[0]["GoodsImg"].ToString();
                        ischage.Text = dt.Rows[0]["IsCharge"].ToString() == "1" ? "可议价" : "不可议价";
                        address.Text = dt.Rows[0]["Address"].ToString();
                        content.Text = dt.Rows[0]["PhoneNum"].ToString();
                        QQnum.Text = dt.Rows[0]["QQNum"].ToString();
                        GoodsUserId = dt.Rows[0]["UserID"].ToString();
                        //默认评论给卖家，后期点击回复按钮时改变
                        ReplyToWho = GoodsUserId;
                    }
                    else
                    {
                        //读取失败
                        UiHelper.AlertAndRedirect(this, "暂时没有物品详细信息，请浏览其他商品", "UserLogin.aspx");
                    }
                    #endregion
                    CommentBind();//评论绑定
                }
                else
                {
                    //不存在ID号
                    UiHelper.Alert(this.Page, "暂时没有物品详细信息，请浏览其他商品");
                }
            }
        }
        #endregion         #region 评论按钮
        protected void Chat_Click(object sender, EventArgs e)
        {
            //获取缓存
            var usermodel = Session["userinfo"] as UsersModel;
            #region 添加操作
            if (usermodel != null)
            {
                #region 评论model赋值
                string comment = txtComment.Text;
                var commentmodel = new GoodsCommentModel();
                commentmodel.FromUser = usermodel.UserID;
                #region 判断评论内容是否为空
                if (comment.Trim() != "")
                {
                    commentmodel.CommentContent = comment;
                }
                else
                {
                    UiHelper.Alert(this, "评论不能为空");
                }
                #endregion
                commentmodel.GoodsID = Convert.ToInt32(Goodsid);
                commentmodel.IsRead = "0";
                commentmodel.ToUser = Convert.ToInt32(ReplyToWho);
                #endregion
                var commbll = new GoodsComment();
                //添加操作
                int addnum = commbll.Add(commentmodel);
                if (addnum > 0)
                {
                    //提交成功并刷新一次
                    UiHelper.AlertAndRedirect(this, "提交成功", "IntroduceGoods.aspx?wpad=" + Goodsid);
                }
            }
            else
            {
                UiHelper.Alert(this, "登陆后再评论吧");
            }
            #endregion
        }
        #endregion         #region 评论绑定
        public void CommentBind()
        {
            var bll = new GoodsComment();
            DataSet ds = bll.GetGoodsComment(Goodsid);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["ToUser"].ToString() == GoodsUserId)
                    {
                        dr["ToWho"] += "（卖家）";
                    }
                    if (dr["FromUser"].ToString() == GoodsUserId)
                    {
                        dr["FromWho"] += "（卖家）";
                    }
                }
            }
            RepeatComment.DataSource = ds;
            RepeatComment.DataBind();
        }
        #endregion         #region 回复某人按钮，获取其userid
        protected void Reply(object sender, CommandEventArgs e)
        {
            ReplyToWho = e.CommandArgument.ToString();
        }
        #endregion         #region 物品收藏页面
        protected void btnsavegoods_Click(object sender, EventArgs e)
        {
            var model = Session["userinfo"] as UsersModel;
            if (model != null)
            {
                string userid = model.UserID.ToString();
                string goodsid = Goodsid;
                SecondHand.Model.Saves sa = new Model.Saves();
                sa.GoodsID = Goodsid;
                sa.UserID = userid;
                sa.SaveTime = DateTime.Now.ToString();
                BLL.Saves bll = new BLL.Saves();
                bool issucess = bll.Add(sa);
                if (issucess)
                {
                    UiHelper.Alert(this, "收藏成功");
                }
                else
                {
                    UiHelper.Alert(this, "失败！");
                }
            }
            else
            {
                UiHelper.Alert(this, "登陆后才可以收藏物品");
            }
        }
        #endregion     }
}