
using System;
namespace SecondHand.Model
{
	/// <summary>
	/// AllGoods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AllGoodsModel
	{
		public AllGoodsModel()
		{}
		#region Model
		private int _goodsid;
		private int _userid;
		private string _username;
		private string _goodsname;
		private string _publishtime;
		/// <summary>
		/// 商品ID号
		/// </summary>
		public int GoodsID
		{
			set{ _goodsid=value;}
			get{return _goodsid;}
		}
		/// <summary>
		/// 商品所属用户ID
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 商品名称
		/// </summary>
		public string GoodsName
		{
			set{ _goodsname=value;}
			get{return _goodsname;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public string PublishTime
		{
			set{ _publishtime=value;}
			get{return _publishtime;}
		}
		#endregion Model
 	}
}

