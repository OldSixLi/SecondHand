
using System;
namespace SecondHand.Model
{
    /// <summary>
    /// GoodsDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class GoodsDetailModel
    {
        public GoodsDetailModel()
        { }
        #region Model
        private int _goodsid;
        private string _goodsname;
        private int? _userid;
        private string _detail;
        private string _price;
        private string _downcount;
        private string _firstclass;
        private string _secondclass;
        private string _ischarge;
        private string _address;
        private string _phonenum;
        private string _qqnum;
        private string _goodsimg;
        /// <summary>
        /// 物品ID
        /// </summary>
        public int GoodsID
        {
            set { _goodsid = value; }
            get { return _goodsid; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName
        {
            set { _goodsname = value; }
            get { return _goodsname; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string Detail
        {
            set { _detail = value; }
            get { return _detail; }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public string Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        public string DownCount
        {
            set { _downcount = value; }
            get { return _downcount; }
        }
        /// <summary>
        /// 商品一级分类
        /// </summary>
        public string FirstClass
        {
            set { _firstclass = value; }
            get { return _firstclass; }
        }
        /// <summary>
        /// 商品二级分类
        /// </summary>
        public string SecondClass
        {
            set { _secondclass = value; }
            get { return _secondclass; }
        }
        /// <summary>
        /// 是否可议价
        /// </summary>
        public string IsCharge
        {
            set { _ischarge = value; }
            get { return _ischarge; }
        }
        /// <summary>
        /// 商品交易地点
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 商品联系电话号码
        /// </summary>
        public string PhoneNum
        {
            set { _phonenum = value; }
            get { return _phonenum; }
        }
        /// <summary>
        /// 商品联系QQ
        /// </summary>
        public string QQNum
        {
            set { _qqnum = value; }
            get { return _qqnum; }
        }
        /// <summary>
        /// 上传图片地址
        /// </summary>
        public string GoodsImg
        {
            set { _goodsimg = value; }
            get { return _goodsimg; }
        }
        #endregion Model
     }
}

