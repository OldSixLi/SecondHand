
using System;
namespace SecondHand.Model
{
	/// <summary>
	/// SecondClass:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SecondClassModel
	{
		public SecondClassModel()
		{}
		#region Model
		private int _secondclassid;
		private int? _firstclassid;
		private string _classname;
		/// <summary>
		/// 二级分类ID号
		/// </summary>
		public int SecondClassID
		{
			set{ _secondclassid=value;}
			get{return _secondclassid;}
		}
		/// <summary>
		/// 上级分类的ID号
		/// </summary>
		public int? FirstClassID
		{
			set{ _firstclassid=value;}
			get{return _firstclassid;}
		}
		/// <summary>
		/// 二级分类名称
		/// </summary>
		public string ClassName
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		#endregion Model
 	}
}

