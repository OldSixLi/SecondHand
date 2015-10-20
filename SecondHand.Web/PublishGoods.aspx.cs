using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using SecondHand.BLL;
using SecondHand.Model;
namespace SecondHand.Web
{
    public partial class PublishGoods : System.Web.UI.Page
    {         private static string _filetxt;
        #region 页面加载，后期需要判断是否已登录
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string a = goodsname.Text.Trim();
                //string goodsDetail = goodsdetail.Inne.Text.Trim();
                FirstClassBind();
                SecondClassBind(ddlFristClass.SelectedValue);
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
        #endregion         #region 图片上传
        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            try
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
                string filename = "GoodsImg/" + DateTime.Now.ToString("yyyyMMddHHmmss") + filetype;
                Directory.CreateDirectory(Path.GetDirectoryName(Server.MapPath(filename)));
                this.fileAttachment.SaveAs(Server.MapPath(filename));
                ImgIcon.Src = filename;
                _filetxt = filename;             }
            catch (Exception ex)
            {
                UiHelper.Alert(this, "上传失败，未知错误！");
            }
        }         #endregion         #region 发布按钮功能
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            #region  获取页面信息
            string goodsName = goodsname.Text.Trim();
            string goodsDetail = goodsdetail.InnerText.Trim();
            string chargePlace = chargeplace.Text.Trim();
            string priCe = price.Text.Trim();
            #region //后期添加功能 分类信息，图片地址，点击量
            string chooseClass = ddlFristClass.SelectedValue.ToString();//一级分类信息
            string secondClass = ddlSecondClass.SelectedValue.ToString();
            string downcount = "1";
            string goodsImg;
            goodsImg = _filetxt ?? " ";             #endregion
            string isCharge = "0";
            if (Charge.Checked)//是否可议价
            {
                //可议价
                isCharge = "1";
                //UIHelper.Alert(this.Page, "选中了");
            }
            string phoneNum = txtPhone.Text.Trim();//手机号信息
            string qqNum = QQNumber.Text.Trim();//QQ号信息
            #endregion
            try
            {
                var usercookies = Session["userinfo"] as UsersModel;
                if (usercookies != null)
                {
                    #region 所有物品表中新加数据
                    var allgoodsmodel = new AllGoodsModel
                    {
                        UserID = usercookies.UserID,
                        UserName = usercookies.gg.UserName,
                        GoodsName = goodsName
                    };
                    int goodsId = new AllGoods().Add(allgoodsmodel);
                    #endregion
                    #region 新发布商品操作
                    //根据返回的值GoodID进行判断
                    if (goodsId > 0)
                    {
                        #region 物品model类型
                        var goodsmodel = new GoodsDetailModel
                        {
                            GoodsID = goodsId,
                            GoodsName = goodsName,
                            UserID = usercookies.UserID,
                            Detail = goodsDetail,
                            Price = priCe,
                            DownCount = downcount,
                            FirstClass = chooseClass,
                            SecondClass = secondClass,
                            IsCharge = isCharge,
                            Address = chargePlace,
                            PhoneNum = phoneNum,
                            QQNum = qqNum,
                            GoodsImg = goodsImg
                        };
                        #endregion
                        if (goodsName != "" && goodsDetail != "" && priCe != "" && chargePlace != "" && chooseClass != "")
                        {
                            if (phoneNum == "" && qqNum == "")
                            {
                                // 没写联系方式
                                UiHelper.Alert(this, "请至少填写一项联系方式！");
                            }
                            else
                            {
                                bool isSuccess = new GoodsDetail().Add(goodsmodel);
                                UiHelper.Alert(this.Page, isSuccess ? "物品发布成功，请保持您的联系方式畅通！" : "发布商品失败");
                            }
                        }
                        else
                        {
                            // 相关信息填写不完整
                            UiHelper.Alert(this, "请完善相关必要信息后再进行操作!");
                        }
                    }
                    else
                    {
                        // 插入商品总览AllGoods表失败
                        UiHelper.Alert(this.Page, "发布商品失败");
                    }
                    #endregion
                }
                else
                {
                    //未登录
                    UiHelper.Alert(this.Page, "您还未登录，请登录后再发布商品信息");
                }
            }
            catch (Exception ex)
            {
                UiHelper.Alert(this, "提交出错，请尝试重新提交或联系管理员。");
            }
        }
        #endregion         #region 一级分类改变加载
        protected void ddlFristClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            SecondClassBind(ddlFristClass.SelectedValue);
        }         #endregion     }
}