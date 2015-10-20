
using System;
namespace SecondHand.Model
{
	/// <summary>
	/// GoodsComment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GoodsCommentModel
	{
		public GoodsCommentModel()
		{}
		#region Model
		private int _commentid;
		private int? _goodsid;
		private string _commentcontent;
		private int? _fromuser;
		private int? _touser;
		private DateTime? _publishtime;
		private string _isread;
		/// <summary>
		/// 评论ID号
		/// </summary>
		public int CommentID
		{
			set{ _commentid=value;}
			get{return _commentid;}
		}
		/// <summary>
		/// 商品ID号\
		/// </summary>
		public int? GoodsID
		{
			set{ _goodsid=value;}
			get{return _goodsid;}
		}
		/// <summary>
		/// 评论详细内容
		/// </summary>
		public string CommentContent
		{
			set{ _commentcontent=value;}
			get{return _commentcontent;}
		}
		/// <summary>
		/// 发表评论用户ID
		/// </summary>
		public int? FromUser
		{
			set{ _fromuser=value;}
			get{return _fromuser;}
		}
		/// <summary>
		/// 回复给用户
		/// </summary>
		public int? ToUser
		{
			set{ _touser=value;}
			get{return _touser;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime? PublishTime
		{
			set{ _publishtime=value;}
			get{return _publishtime;}
		}
		/// <summary>
		/// 被评论者是否阅读 
		/// </summary>
		public string IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		#endregion Model
 	}
}

