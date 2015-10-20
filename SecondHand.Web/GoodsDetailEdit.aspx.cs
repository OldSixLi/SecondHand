using System;
using System.Data;
using System.Web.UI.WebControls;
using SecondHand.BLL;
using SecondHand.Model;
namespace SecondHand.Web
{
    public partial class GoodsDetailEdit : System.Web.UI.Page
    {
        private readonly GoodsDetail _bll = new GoodsDetail();
        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string goodsid = Request["wpad"].ToString();
                var model = Session["userinfo"] as UsersModel;
                if (model != null)
                {
                    #region 判断是否存在goodsid
                    string a = goodsid;
                    if (a != "")
                    {
                        #region 绑定到各个项
                        DataTable dt = _bll.Getdetailbyid(a);
                        if (dt.Rows.Count > 0)
                        {
                            #region 判断当前物品主人与当前用户ID是否一致，或者是否是管理员，如果不一致则不允许修改
                            if (dt.Rows[0]["UserID"].ToString() == model.UserID.ToString() || model.UserType == "2")
                            {
                                FirstClassBind();
                                goodsname.Text = dt.Rows[0]["GoodsName"].ToString();
                                goodsdetail.InnerText = dt.Rows[0]["Detail"].ToString();
                                price.Text = dt.Rows[0]["Price"].ToString();
                                chargeplace.Text = dt.Rows[0]["Address"].ToString();
                                Charge.Checked = dt.Rows[0]["IsCharge"].ToString() == "1";
                                txtPhone.Text = dt.Rows[0]["PhoneNum"].ToString();
                                QQNumber.Text = dt.Rows[0]["QQNum"].ToString();
                                ddlFristClass.SelectedValue = dt.Rows[0]["FirstClass"].ToString();
                                SecondClassBind(ddlFristClass.SelectedValue);
                                ddlSecondClass.SelectedValue = dt.Rows[0]["SecondClass"].ToString();
                            }
                            else
                            {
                                UiHelper.AlertAndRedirect(this, "对不起，您没有编辑此物品的权限", "UserLogin.aspx");
                            }
                            #endregion
                        }
                        else
                        {
                            UiHelper.AlertAndRedirect(this, " 读取物品信息失败，请返回重试", "UserLogin.aspx");
                        }
                        #endregion
                    }
                    else
                    {
                        UiHelper.AlertAndRedirect(this, "物品不存在", "UserLogin.aspx");
                    }
                    #endregion
                }
                else
                {
                    UiHelper.AlertAndRedirect(this, "请登录后在进行操作", "UserLogin.aspx");
                }
            }
        }
        #endregion         #region 分类绑定
        private void FirstClassBind()
        {
            var bll = new FirstClass();
            DataSet ds = bll.GetAllList();
            ddlFristClass.DataSource = ds.Tables[0];
            ddlFristClass.DataTextField = "ClassName";
            ddlFristClass.DataValueField = "FirstClassID";
            ddlFristClass.DataBind();
            var li = new ListItem("请选择一级分类", "0");
            this.ddlFristClass.Items.Insert(0, li);
        }
        private void SecondClassBind(string firstclassid)
        {
            var bll = new SecondClass();
            DataSet ds = bll.GetList("FirstClassID=" + firstclassid);
            ddlSecondClass.DataSource = ds;
            ddlSecondClass.DataTextField = "ClassName";
            ddlSecondClass.DataValueField = "SecondClassID";
            ddlSecondClass.DataBind();
            var li = new ListItem("请选择二级分类", "0");
            this.ddlSecondClass.Items.Insert(0, li);
        }
        #endregion         #region 提交按钮
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            #region 赋值
            string goodsid = Request["wpad"];
            string goodsName = goodsname.Text.Trim();
            string goodsDetail = goodsdetail.InnerText.Trim();
            string chargePlace = chargeplace.Text.Trim();
            string priCe = price.Text.Trim();
            string isCharge = "0";
            string chooseClass = ddlFristClass.SelectedValue;//一级分类信息
            string secondclass = ddlSecondClass.SelectedValue;//一级分类信息
            if (Charge.Checked)//是否可议价
            {
                //可议价
                isCharge = "1";
            }
            string phoneNum = txtPhone.Text.Trim();//手机号信息
            string qqNum = QQNumber.Text.Trim();//QQ号信息
            #endregion
            #region 编辑操作
            try
            {
                var usercookies = Session["userinfo"] as UsersModel;
                if (usercookies != null)
                {
                    #region 所有物品表中新加数据
                    var allgoodsmodel = new AllGoodsModel
                    {
                        GoodsID = Convert.ToInt32(goodsid),
                        GoodsName = goodsName
                    };
                    var allgoodsbll = new AllGoods();
                    bool isAllGoodsSuccess = allgoodsbll.Update(allgoodsmodel);
                    if (isAllGoodsSuccess)
                    {
                        #region 物品model类型
                        var goodsmodel = new GoodsDetailModel
                        {
                            GoodsID = Convert.ToInt32(goodsid),
                            GoodsName = goodsName,
                            Detail = goodsDetail,
                            Price = priCe,
                            IsCharge = isCharge,
                            Address = chargePlace,
                            PhoneNum = phoneNum,
                            QQNum = qqNum,
                            //TODO  后期修改分类信息
                            FirstClass = chooseClass,
                            SecondClass = secondclass
                        };
                        #endregion
                        if (secondclass != "0" && chooseClass != "0")
                        {
                            if (goodsName != "" && goodsDetail != "" && priCe != "" && chargePlace != "")
                            {
                                if (phoneNum == "" && qqNum == "")
                                {
                                    // 没写联系方式
                                    UiHelper.Alert(this, "请至少填写一项联系方式！");
                                }
                                else
                                {
                                    var goodsdetailbll = new GoodsDetail();
                                    bool isSuccesse = goodsdetailbll.Update(goodsmodel);
                                    UiHelper.Alert(Page, isSuccesse ? "修改信息成功！" : "修改商品信息失败");
                                }
                            }
                            else
                            {
                                // 相关信息填写不完整
                                UiHelper.Alert(this, "请完善相关必要信息后再进行修改!");
                            }
                        }
                        else
                        {
                            UiHelper.Alert(this, "请选择相关分类信息");
                        }
                    }
                    else
                    {
                        // 插入商品总览AllGoods表失败
                        UiHelper.Alert(Page, "修改商品信息失败");
                    }
                    #endregion
                }
                else
                {
                    //未登录
                    UiHelper.Alert(this.Page, "您还未登录，请登录后再修改商品信息");
                }
            }
            catch (Exception ex)
            {
                UiHelper.Alert(this, "提交出错，请尝试重新提交或联系管理员。");
            }
            #endregion
        }
        #endregion         #region 显示条数
        protected void ddlFristClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            SecondClassBind(ddlFristClass.SelectedValue);
        }         #endregion
    }
}