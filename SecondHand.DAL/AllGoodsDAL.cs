using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SecondHand.Model;
namespace SecondHand.DAL
{
    public partial class AllGoodsDAL
    {         /// <summary>
        /// 增加一条数据，增加后返回GoodID
        /// </summary>
        public int Add(AllGoodsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AllGoods(");
            strSql.Append("UserID,UserName,GoodsName,PublishTime)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@UserName,@GoodsName,convert(char,getdate(),120))");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@GoodsName", SqlDbType.VarChar,50)
			};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.GoodsName;
            //object obj = DBHelper.ExecuteNonQuery(strSql.ToString(),parameters);
            DataTable obj = DBHelper.GetDt(strSql.ToString(), parameters);
            // SqlDataReader obj = DBHelper.GetDR(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj.Rows[0][0].ToString());
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        //TODO 修改后的方法，只修改物品名称，其他信息不修改
        public bool Update(AllGoodsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AllGoods set ");
            strSql.Append("GoodsName=@GoodsName");
            strSql.Append(" where GoodsID=@GoodsID");
            SqlParameter[] parameters = {
			new SqlParameter("@GoodsName", SqlDbType.VarChar,50),
		    new SqlParameter("@GoodsID", SqlDbType.Int,4)};
            parameters[0].Value = model.GoodsName;
            parameters[1].Value = model.GoodsID;
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
        /// 数据库翻页获得数据
        /// </summary>
        /// <param name="orderby">排序字段</param>
        /// <param name="sort">排序方式，0为升序，1为降序</param>
        /// <param name="page">每页多少条记录</param>
        /// <param name="pageindex">指定当前为第几页</param>
        /// <param name="totalpage">返回总页数</param>
        /// <param name="index">返回当前页数</param>
        /// <returns></returns>
        public DataTable GetAllGoods(string orderby, int sort, int page, int pageindex, ref int totalpage, ref int index)
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
            paras[0].Value = "(select m.GoodsID,m.UserID,m.GoodsName,m.PublishTime,m.Price,m.GoodsImg,u.UserName from (select a.GoodsID ,a.UserID,a.GoodsName,a.PublishTime,b.Price,b.GoodsImg from AllGoods a left join GoodsDetail b on a.GoodsID=b.GoodsID )m left join UserInfo u on m.UserID=u.UserID) p";
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
            DataTable ds = DBHelper.GetDSer("Proc_PAGING", paras).Tables[0];
            totalpage = Convert.ToInt32(paras[7].Value);
            index = Convert.ToInt32(ds.Rows[0]["PageIndex"].ToString());
            return ds;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int goodsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AllGoods ");
            strSql.Append(" where GoodsID=@GoodsID");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsID", SqlDbType.Int,4)
			};
            parameters[0].Value = goodsId;
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
        /// 根据userid删除信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool DeletebyUserId(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AllGoods ");
            strSql.Append(" where UserID=@userid");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,10)
			};
            parameters[0].Value = userid;
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string GoodsIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AllGoods ");
            strSql.Append(" where GoodsID in (" + GoodsIDlist + ")  ");
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
        public AllGoodsModel DataRowToModel(DataRow row)
        {
            AllGoodsModel model = new AllGoodsModel();
            if (row != null)
            {
                if (row["GoodsID"] != null && row["GoodsID"].ToString() != "")
                {
                    model.GoodsID = int.Parse(row["GoodsID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["GoodsName"] != null)
                {
                    model.GoodsName = row["GoodsName"].ToString();
                }
                if (row["PublishTime"] != null)
                {
                    model.PublishTime = row["PublishTime"].ToString();
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
            strSql.Append("select GoodsID,UserID,UserName,GoodsName,PublishTime ");
            strSql.Append(" FROM AllGoods ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.GetDS(strSql.ToString());
        }
        public DataSet GetPersonPublishGoods(string userid)
        {
            var strsql = new StringBuilder();
            strsql.Append("select a.GoodsId,a.UserID,a.GoodsName,a.PublishTime,b.Detail,b.Price,b.GoodsImg from AllGoods a left join GoodsDetail b on a.GoodsID=b.GoodsID where a.UserID=");
            strsql.Append(userid);
            DataSet ds = DBHelper.GetDS(strsql.ToString());
            return ds;
        }
        public int Getgoodscounbyuserid(string userid)
        {
            string sql = @" select COUNT(goodsid)  as goodsid  from ( select Goodsid from AllGoods where UserID=" + userid + ") a";
            DataSet ds = DBHelper.GetDS(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["goodsid"].ToString());
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 获取网站总的物品数
        /// </summary>
        /// <returns></returns>
        public int GetGoodsCount()
        {
            string sql = @"select COUNT(GoodsID) as Num from  AllGoods";
            DataSet ds = DBHelper.GetDS(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["Num"].ToString());
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 获取网站总注册人数
        /// </summary>
        /// <returns></returns>
        public int GetUsersCount()
        {
            string sql = @"select COUNT(UserID) as Num from  Users";
            DataSet ds = DBHelper.GetDS(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["Num"].ToString());
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 评论总数
        /// </summary>
        /// <returns></returns>
        public int GetCommentsCount()
        {
            string sql = @"  select COUNT(CommentID) as Num from    GoodsComment";
            DataSet ds = DBHelper.GetDS(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["Num"].ToString());
            }
            else
            {
                return 0;
            }
        }     }
}
