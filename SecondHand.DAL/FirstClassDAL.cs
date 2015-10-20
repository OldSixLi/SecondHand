
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SecondHand.Model;
namespace SecondHand.DAL
{
	/// <summary>
	/// 数据访问类:FirstClass
	/// </summary>
	public partial class FirstClassDAL
	{
		public FirstClassDAL()
		{}
		#region  基础类
 		/// <summary>
		/// 得到最大ID
		/// </summary>
 		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FirstClassID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FirstClass");
			strSql.Append(" where FirstClassID=@FirstClassID");
			SqlParameter[] parameters = {
					new SqlParameter("@FirstClassID", SqlDbType.Int,4)
			};
			parameters[0].Value = FirstClassID;
 			return DBHelper.IsExists (strSql.ToString(),parameters);
		}
 		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FirstClassModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FirstClass(");
			strSql.Append("ClassName,FirstClassIcon)");
			strSql.Append(" values (");
			strSql.Append("@ClassName,@FirstClassIcon)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassName", SqlDbType.VarChar,50),
					new SqlParameter("@FirstClassIcon", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ClassName;
			parameters[1].Value = model.FirstClassIcon;
 			object obj = DBHelper.ExecuteNonQuery(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FirstClassModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FirstClass set ");
			strSql.Append("ClassName=@ClassName,");
			strSql.Append("FirstClassIcon=@FirstClassIcon");
			strSql.Append(" where FirstClassID=@FirstClassID");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassName", SqlDbType.VarChar,50),
					new SqlParameter("@FirstClassIcon", SqlDbType.VarChar,50),
					new SqlParameter("@FirstClassID", SqlDbType.Int,4)};
			parameters[0].Value = model.ClassName;
			parameters[1].Value = model.FirstClassIcon;
			parameters[2].Value = model.FirstClassID;
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
		public bool Delete(int FirstClassID)
		{
 			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FirstClass ");
			strSql.Append(" where FirstClassID=@FirstClassID");
			SqlParameter[] parameters = {
					new SqlParameter("@FirstClassID", SqlDbType.Int,4)
			};
			parameters[0].Value = FirstClassID;
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string FirstClassIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FirstClass ");
			strSql.Append(" where FirstClassID in ("+FirstClassIDlist + ")  ");
            int rows = DBHelper.ExecuteNonQuery(strSql.ToString());
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
		public FirstClassModel GetModel(int FirstClassID)
		{
 			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FirstClassID,ClassName,FirstClassIcon from FirstClass ");
			strSql.Append(" where FirstClassID=@FirstClassID");
			SqlParameter[] parameters = {
					new SqlParameter("@FirstClassID", SqlDbType.Int,4)
			};
			parameters[0].Value = FirstClassID;
 			FirstClassModel model=new FirstClassModel();
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
		public FirstClassModel DataRowToModel(DataRow row)
		{
			FirstClassModel model=new FirstClassModel();
			if (row != null)
			{
				if(row["FirstClassID"]!=null && row["FirstClassID"].ToString()!="")
				{
					model.FirstClassID=int.Parse(row["FirstClassID"].ToString());
				}
				if(row["ClassName"]!=null)
				{
					model.ClassName=row["ClassName"].ToString();
				}
				if(row["FirstClassIcon"]!=null)
				{
					model.FirstClassIcon=row["FirstClassIcon"].ToString();
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
			strSql.Append("select FirstClassID,ClassName,FirstClassIcon ");
			strSql.Append(" FROM FirstClass ");
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
			strSql.Append(" FirstClassID,ClassName,FirstClassIcon ");
			strSql.Append(" FROM FirstClass ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelper.GetDS(strSql.ToString());
		}
 		/// <summary>
		/// 获取记录总数
		/// </summary>
 		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.FirstClassID desc");
			}
			strSql.Append(")AS Row, T.*  from FirstClass T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
			parameters[0].Value = "FirstClass";
			parameters[1].Value = "FirstClassID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/
 		#endregion  基础类
		#region  额外添加
 		#endregion  额外添加
	}
}

