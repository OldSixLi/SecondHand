/**  版本信息模板在安装目录下，可自行修改。
* Saves.cs
*
* 功 能： N/A
* 类 名： Saves
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/4/30 15:37:15   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace SecondHand.Model
{
	/// <summary>
	/// Saves:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Saves
	{
		public Saves()
		{}
		#region Model
		private string _userid;
		private string _goodsid;
		private string _savetime;
		/// <summary>
		/// 
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GoodsID
		{
			set{ _goodsid=value;}
			get{return _goodsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SaveTime
		{
			set{ _savetime=value;}
			get{return _savetime;}
		}
		#endregion Model
 	}
}

