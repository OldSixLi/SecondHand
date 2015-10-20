
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace SecondHand.DAL
{
    public class SaveDall
    {
        public bool Add(Model.Saves model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Saves(");
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
            return false;
        }         /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Saves DataRowToModel(DataRow row)
        {
            var model = new Model.Saves();
            if (row != null)
            {
                if (row["UserID"] != null)
                {
                    model.UserID = row["UserID"].ToString();
                }
                if (row["GoodsID"] != null)
                {
                    model.GoodsID = row["GoodsID"].ToString();
                }
                if (row["SaveTime"] != null)
                {
                    model.SaveTime = row["SaveTime"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,GoodsID,SaveTime ");
            strSql.Append(" FROM Saves ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.GetDS(strSql.ToString());
        }     }
}
