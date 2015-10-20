
using System;
namespace SecondHand.Model
{
	/// <summary>
	/// UserInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserInfoModel
	{
		public UserInfoModel()
		{}
		#region Model
		private int _userid;
		private string _username;
		private string _regtime;
		private string _sex;
		private string _contentnum;
		private string _email;
		private string _phonenum;
		private string _qq;
		private string _usericon;
		/// <summary>
		/// 用户ID
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 网站用户名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public string RegTime
		{
			set{ _regtime=value;}
			get{return _regtime;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 证件号
		/// </summary>
		public string ContentNum
		{
			set{ _contentnum=value;}
			get{return _contentnum;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string PhoneNum
		{
			set{ _phonenum=value;}
			get{return _phonenum;}
		}
		/// <summary>
		/// QQ号
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 用户头像路径
		/// </summary>
		public string UserIcon
		{
			set{ _usericon=value;}
			get{return _usericon;}
		}
		#endregion Model
 	}
}

