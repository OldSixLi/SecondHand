
using System;
namespace SecondHand.Model
{
	/// <summary>
	/// FirstClass:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FirstClassModel
	{
		public FirstClassModel()
		{}
		#region Model
		private int _firstclassid;
		private string _classname;
		private string _firstclassicon;
		/// <summary>
		/// 一级分类ID号
		/// </summary>
		public int FirstClassID
		{
			set{ _firstclassid=value;}
			get{return _firstclassid;}
		}
		/// <summary>
		/// 一级分类名称
		/// </summary>
		public string ClassName
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 一级分类图标
		/// </summary>
		public string FirstClassIcon
		{
			set{ _firstclassicon=value;}
			get{return _firstclassicon;}
		}
		#endregion Model
 	}
}

