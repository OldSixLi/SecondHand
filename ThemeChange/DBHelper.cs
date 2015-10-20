/********************************************************************************
 * 描述：
 *     “操作数据库帮助类“
 *     
 * 变更历史：
 *     作者：马少博  时间：2015年03月17日   
 *******************************************************************************/
 using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
 namespace SecondHand.DAL
{
    public class DBHelper
    {
        public static string ConnectionStr = ConfigurationManager.ConnectionStrings["SecondHandConnectionString"].ConnectionString;
         //        public static string ConnectionStr = @"Data Source=192.168.3.85;Initial Catalog=BSTJBSTWO;
        //     User ID=sa ;PassWord = CST123456; Persist Security Info=True;";
         public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }
         public static SqlConnection GetConnection(string connstr)
        {
            SqlConnection conn = new SqlConnection(connstr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }
         /// <summary>
        /// 准备command
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">连接语句</param>
        /// <param name="tran">事务</param>
        /// <param name="cmdType">command类型</param>
        /// <param name="cmd">command密令</param>
        /// <param name="cmdParams">command参数</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction tran, CommandType cmdType, string cmdText, SqlParameter[] cmdParams)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            cmd.Connection = conn;
            if (tran != null)
                cmd.Transaction = tran;
            if (cmdParams != null)
            {
                foreach (SqlParameter para in cmdParams)
                {
                    cmd.Parameters.Add(para);
                }
             }
        }
        /// <summary>
        /// 返回一个dataset
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public static DataSet GetDS(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParas)
        {
            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 240;
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParas);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }
        public static DataSet GetDS(string cmd, CommandType cmdType, params SqlParameter[] cmdParas)
        {
            SqlConnection conn = GetConnection();
            return GetDS(conn, cmdType, cmd, cmdParas);
        }
        public static DataSet GetDS(string cmdText, params SqlParameter[] cmdParas)//必须有参数
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            //CommandType cmdType = CommandType.Text;
            return GetDS(conn, CommandType.Text, cmdText, cmdParas);
        }
        public static DataSet GetDSer(string cmdText, params SqlParameter[] cmdParas)//必须有参数
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            //CommandType cmdType = CommandType.Text;
            return GetDS(conn, CommandType.StoredProcedure, cmdText, cmdParas);
        }
         /// <summary>
        /// 执行sql查询语句返回int类型的执行结果
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SqlConnection conn, string cmdText, CommandType cmdType, params SqlParameter[] cmdParas)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (conn)
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParas);
                    int val = cmd.ExecuteNonQuery();
                    return val;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return 0;
            }
        }
        public static int ExecuteNonQuery(string cmdText, CommandType cmdType, params SqlParameter[] cmdParas)
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            return ExecuteNonQuery(conn, cmdText, cmdType, cmdParas);
        }
        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] cmdParas)
        {
            //CommandType cmdType = CommandType.Text;
            return ExecuteNonQuery(cmdText, CommandType.Text, cmdParas);
        }
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
             SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
         }
        /// <summary>
        /// 得到对象sqldatareader，用时注意关闭dr
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public static SqlDataReader GetDR(string cmdText, CommandType cmdType, params SqlParameter[] cmdParas)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConnectionStr);
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParas);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return dr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        public static SqlDataReader GetDR(string cmdText, params SqlParameter[] cmdParas)
        {
            //CommandType cmdType = CommandType.Text;
            return GetDR(cmdText, CommandType.Text, cmdParas);
        }
        /// <summary>
        /// 根据cmdText判断数据是否存在存在返回true
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="cmdParas">参数</param>
        /// <returns>True或false</returns>
        public static bool IsExists(string cmdText, params SqlParameter[] cmdParas)
        {
            bool isExists = false;
            SqlDataReader dr = GetDR(cmdText, cmdParas);
            if (dr.Read())
                isExists = true;
            else isExists = false;
            dr.Dispose();
            return isExists;
         }
         public static bool IsExists(string cmdText, CommandType cmdType, params SqlParameter[] cmdParas)
        {
            SqlDataReader dr = GetDR(cmdText, cmdType, cmdParas);
            bool isExists = false;
            while (dr.Read())
                isExists = true;
            dr.Dispose();
            return isExists;
        }
         /// <summary>
        /// 返回datatable
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public static DataTable GetDt(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParas)
        {
            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParas);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.Parameters.Clear();
                return dt;
            }
        }
        public static DataTable GetDt(string cmd, CommandType cmdType, params SqlParameter[] cmdParas)
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            return GetDt(conn, cmdType, cmd, cmdParas);
        }
        public static DataTable GetDt(string cmdText, params SqlParameter[] cmdParas)//必须有参数
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            //CommandType cmdType = CommandType.Text;
            return GetDt(conn, CommandType.Text, cmdText, cmdParas);
        }
        /// <summary>
        /// 返回IndexFiledInfo表中数据
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static DataTable Get_IndexFiled(string cmdText)
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            //CommandType cmdType = CommandType.Text;
            return GetDt(conn, CommandType.Text, cmdText);
        }
     }
}
