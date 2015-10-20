
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Data.SqlClient;
using SecondHand.Model;
namespace SecondHand.DAL
{
    /// <summary>
    /// 数据访问类:Users
    /// </summary>
    public partial class UsersDAL
    {          /// <summary>
        /// 管理员获得所有用户信息
        /// </summary>         public DataTable GetAllUsers(string orderby, int sort, int page, int pageindex, ref int totalpage, ref int index, ref int totalrecord)
        {
            SqlParameter[] paras =
            {
                new SqlParameter("@TableNames ", SqlDbType.VarChar, 2000),
                new SqlParameter("@FieldStr ",SqlDbType.VarChar,4000), 
                new SqlParameter("@SqlWhere ",SqlDbType.VarChar,4000), 
                new SqlParameter("@OrderBy  ",SqlDbType.VarChar,4000),
                new SqlParameter("@Sort ",SqlDbType.Int,1), 
                new SqlParameter("@PageSize ",SqlDbType.Int,40), 
                new SqlParameter("@PageIndex ",SqlDbType.Int,40), 
                new SqlParameter("@TotalPage ",SqlDbType.Int,40), 
                new SqlParameter("@TotalRecord ",SqlDbType.Int,40)
             };
            //表名(支持多表)
            paras[0].Value = "( select a.UserID,UserName,LoginCode,PassWord,UserType,RegTime,Sex,ContentNum,PhoneNum,QQ,UserIcon from Users a left  join UserInfo b on a.UserID=b.UserID  ) m";
            //字段名(全部字段为*)
            paras[1].Value = "*";
            //条件语句(不用加where)
            paras[2].Value = "无";
            // 排序字段
            paras[3].Value = orderby;
            //排序方法，0为升序，1为降序
            paras[4].Value = sort;
            //  每页多少条记录
            paras[5].Value = page;
            //指定当前为第几页
            paras[6].Value = pageindex;
            //返回总页数 ,固定值
            paras[7].Value = 0;
            // 返回总条数 ，固定值
            paras[8].Value = 0;
            paras[7].Direction = ParameterDirection.Output;
            paras[8].Direction = ParameterDirection.Output;
            DataTable ds = DBHelper.GetDSer("Proc_PAGING", paras).Tables[0];
             if (ds.Rows.Count > 0)
            {
                totalpage = Convert.ToInt32(paras[7].Value);
                totalrecord = Convert.ToInt32(paras[8].Value);
                index = Convert.ToInt32(ds.Rows[0]["PageIndex"].ToString());
                return ds;
            }
            else
            {
                return null;
            }
            //return DBHelper.GetDt(_connectionStr, "Proc_PAGING", paras);
         }          /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(UsersModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Users(");
            strSql.Append("LoginCode,PassWord,UserType)");
            strSql.Append(" values (");
            strSql.Append("@LoginCode,@PassWord,@UserType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginCode", SqlDbType.VarChar,50),
					new SqlParameter("@PassWord", SqlDbType.VarChar,50),
					new SqlParameter("@UserType", SqlDbType.VarChar,50)};
            parameters[0].Value = model.LoginCode;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.UserType;
             object obj = DBHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }          /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {
             StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Users ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,10)
			};
            parameters[0].Value = UserID;
             int rows = DBHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }          /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UsersModel GetModel(int UserID)
        {
             StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,LoginCode,PassWord,UserType from Users ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;
             UsersModel model = new UsersModel();
             DataSet ds = DBHelper.GetDS(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        public UsersModel GetbynameModel(string logincode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from Users ");
            strSql.Append("where LoginCode=@LoginCode");
            SqlParameter[] parameters = { new SqlParameter("@LoginCode", SqlDbType.NVarChar, 50) };
             parameters[0].Value = logincode;
            //UsersModel model = new Model.UsersModel();
            DataSet ds = DBHelper.GetDS(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 返回登陆者的相关信息
        /// </summary>
        /// <param name="logincode"></param>
        /// <returns></returns>
        public DataSet GetUserInfo(string logincode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from(SELECT a.UserID ,a.LoginCode,a.PassWord,a.UserType,b.UserName,b.RegTime,b.Email,b.Sex,b.ContentNum,b.PhoneNum,b.QQ,b.UserIcon FROM Users a left join UserInfo b  on a.UserID=b.UserID) t where logincode=@logincode ");
            SqlParameter[] parameters = { new SqlParameter("@logincode", SqlDbType.NVarChar, 50) };
            parameters[0].Value = logincode;
            //UsersModel model = new Model.UsersModel();
            DataSet ds = DBHelper.GetDS(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
         }
         /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UsersModel DataRowToModel(DataRow row)
        {
            UsersModel model = new UsersModel();
            if (row != null)
            {
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["LoginCode"] != null)
                {
                    model.LoginCode = row["LoginCode"].ToString();
                }
                if (row["PassWord"] != null)
                {
                    model.PassWord = row["PassWord"].ToString();
                }
                if (row["UserType"] != null)
                {
                    model.UserType = row["UserType"].ToString();
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
            strSql.Append("select UserID,LoginCode,PassWord,UserType ");
            strSql.Append(" FROM Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.GetDS(strSql.ToString());
        }         public bool UpdateAdmin(UsersModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
             strSql.Append("UserType=@UserType");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
 					new SqlParameter("@UserType", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4)};
             parameters[0].Value = model.UserType;
            parameters[1].Value = model.UserID;
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
         public bool UpdatePass(UsersModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
             strSql.Append("PassWord=@PassWord");
             strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
 					new SqlParameter("@PassWord", SqlDbType.VarChar,50),
 					new SqlParameter("@UserID", SqlDbType.Int,4)};
             parameters[0].Value = model.PassWord;
            parameters[1].Value = model.UserID;
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
    }
} 