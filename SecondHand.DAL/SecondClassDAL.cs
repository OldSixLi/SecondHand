
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SecondHand.Model;
namespace SecondHand.DAL
{
    /// <summary>
    /// 数据访问类:SecondClass
    /// </summary>
    public partial class SecondClassDAL
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SecondClassID,FirstClassID,ClassName ");
            strSql.Append(" FROM SecondClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.GetDS(strSql.ToString());
        }
        public DataSet GetclassName(string classid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ClassName ");
            strSql.Append(" FROM SecondClass ");
            strSql.Append(" where SecondClassID=" + classid);
            return DBHelper.GetDS(strSql.ToString());
        }
     }
}

