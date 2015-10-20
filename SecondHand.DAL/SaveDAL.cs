/**  版本信息模板在安装目录下，可自行修改。
* Save.cs
*
* 功 能： N/A
* 类 名： Save
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
using System.Data;
using System.Text;
using System.Data.SqlClient;
 
namespace SecondHand.DAL
{
	/// <summary>
	/// 数据访问类:Save
	/// </summary>
	public partial class Save
	{
		public Save()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(SecondHand.Model.Save model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Save(");
			strSql.Append("UserID,GoodsID,SaveTime)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@GoodsID,@SaveTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsID", SqlDbType.NVarChar,50),
					new SqlParameter("@SaveTime", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.GoodsID;
			parameters[2].Value = model.SaveTime;

            int rows = DBHelper.ExecuteNonQuery(strSql.ToString(), parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SecondHand.Model.Save model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Save set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("GoodsID=@GoodsID,");
			strSql.Append("SaveTime=@SaveTime");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsID", SqlDbType.NVarChar,50),
					new SqlParameter("@SaveTime", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.GoodsID;
			parameters[2].Value = model.SaveTime;

            int rows = DBHelper.ExecuteNonQuery(strSql.ToString(), parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Save ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			int rows=DBHelper.ExecuteNonQuery(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SecondHand.Model.Save GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserID,GoodsID,SaveTime from Save ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			SecondHand.Model.Save model=new SecondHand.Model.Save();
			DataSet ds=DBHelper.GetDS(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SecondHand.Model.Save DataRowToModel(DataRow row)
		{
			SecondHand.Model.Save model=new SecondHand.Model.Save();
			if (row != null)
			{
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["GoodsID"]!=null)
				{
					model.GoodsID=row["GoodsID"].ToString();
				}
				if(row["SaveTime"]!=null)
				{
					model.SaveTime=row["SaveTime"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserID,GoodsID,SaveTime ");
			strSql.Append(" FROM Save ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelper.GetDS(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" UserID,GoodsID,SaveTime ");
			strSql.Append(" FROM Save ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelper.GetDS(strSql.ToString());
		}

 
		 
		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Save";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

