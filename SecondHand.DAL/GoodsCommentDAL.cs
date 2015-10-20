
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SecondHand.Model;
namespace SecondHand.DAL
{
    /// <summary>
    /// 数据访问类:GoodsComment
    /// </summary>
    public partial class GoodsCommentDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GoodsCommentModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GoodsComment(");
            strSql.Append("GoodsID,CommentContent,FromUser,ToUser,PublishTime,IsRead)");
            strSql.Append(" values (");
            strSql.Append("@GoodsID,@CommentContent,@FromUser,@ToUser, convert(char,getdate(),120),@IsRead)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsID", SqlDbType.Int,4),
					new SqlParameter("@CommentContent", SqlDbType.VarChar,50),
					new SqlParameter("@FromUser", SqlDbType.Int,4),
					new SqlParameter("@ToUser", SqlDbType.Int,4),
 					new SqlParameter("@IsRead", SqlDbType.VarChar,50)};
            parameters[0].Value = model.GoodsID;
            parameters[1].Value = model.CommentContent;
            parameters[2].Value = model.FromUser;
            parameters[3].Value = model.ToUser;
            parameters[4].Value = model.IsRead;
            object obj = DBHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CommentID,GoodsID,CommentContent,FromUser,ToUser,PublishTime,IsRead ");
            strSql.Append(" FROM GoodsComment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.GetDS(strSql.ToString());
        }
        /// <summary>
        /// 根据物品获得数据列表
        /// </summary>
        /// <param name="goodsid"></param>
        /// <returns></returns>
        public DataSet GetComment(string goodsid)
        {
            string sql = "select c.GoodsID ,c.CommentID,c.PublishTime,c.CommentContent,c.FromUser,c.ToUser,c.FromWho ,d.UserName as ToWho ,c.UserIcon from (select a.GoodsID ,a.CommentID,a.PublishTime,a.CommentContent,a.FromUser,a.ToUser,b.UserName as FromWho ,b.UserIcon from GoodsComment a left join UserInfo b on a.FromUser=b.UserID ) c left join UserInfo d on c.ToUser=d.UserID where GoodsID=" + goodsid + " order by PublishTime";
            DataSet ds = DBHelper.GetDS(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }
     }
}

