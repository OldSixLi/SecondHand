using System.Data;
using System.Text;
using System.Data.SqlClient;
using SecondHand.Model;
namespace SecondHand.DAL
{
    /// <summary>
    /// 数据访问类:UserInfo
    /// </summary>
    public class UserInfoDAL
    {         /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(UserInfoModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserInfo(");
            strSql.Append("UserID,UserName,RegTime,Sex,ContentNum,Email,PhoneNum,QQ,UserIcon)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@UserName,convert(char,getdate(),120),@Sex,@ContentNum,@Email,@PhoneNum,@QQ,@UserIcon)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.VarChar,50),
					new SqlParameter("@ContentNum", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@PhoneNum", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@UserIcon", SqlDbType.VarChar,50)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.ContentNum;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.PhoneNum;
            parameters[6].Value = model.QQ;
            parameters[7].Value = model.UserIcon;
            int rows = DBHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            return false;
        }         /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int userid)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserInfo ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {	new SqlParameter("@UserID", SqlDbType.Int,10)
			};
            parameters[0].Value = userid;
            int rows = DBHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            return false;
        }         /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserInfoModel DataRowToModel(DataRow row)
        {
            UserInfoModel model = new UserInfoModel();
            if (row != null)
            {
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["RegTime"] != null)
                {
                    model.RegTime = row["RegTime"].ToString();
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["ContentNum"] != null)
                {
                    model.ContentNum = row["ContentNum"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["PhoneNum"] != null)
                {
                    model.PhoneNum = row["PhoneNum"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["UserIcon"] != null)
                {
                    model.UserIcon = row["UserIcon"].ToString();
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
            strSql.Append("select UserID,UserName,RegTime,Sex,ContentNum,Email,PhoneNum,QQ,UserIcon ");
            strSql.Append(" FROM UserInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.GetDS(strSql.ToString());
        }         public bool AdminUpdate(UserInfoModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("ContentNum=@ContentNum,");
            strSql.Append("Email=@Email,");
            strSql.Append("PhoneNum=@PhoneNum,");
            strSql.Append("QQ=@QQ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@ContentNum", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@PhoneNum", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
                    new SqlParameter("@UserID", SqlDbType.Int,4)
			 };
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.ContentNum;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.PhoneNum;
            parameters[4].Value = model.QQ;
            parameters[5].Value = model.UserID;
            int rows = DBHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            return false;
        }         public bool UpdateUserIcon(string userid, string iconfile)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ");
            strSql.Append("UserIcon=@QQ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					 new SqlParameter("@QQ", SqlDbType.VarChar,50),
                    new SqlParameter("@UserID", SqlDbType.Int,4)
			 };             parameters[0].Value = iconfile;
            parameters[1].Value = userid;
            int rows = DBHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            return false;
        }     }
}
