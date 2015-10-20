
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SecondHand.Model;
 namespace SecondHand.DAL
{
    /// <summary>
    /// 数据访问类:GoodsDetail
    /// </summary>
    public partial class GoodsDetailDAL
    {
         /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(GoodsDetailModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GoodsDetail(");
            strSql.Append("GoodsID,GoodsName,UserID,Detail,Price,DownCount,FirstClass,SecondClass,IsCharge,Address,PhoneNum,QQNum,GoodsImg)");
            strSql.Append(" values (");
            strSql.Append("@GoodsID,@GoodsName,@UserID,@Detail,@Price,@DownCount,@FirstClass,@SecondClass,@IsCharge,@Address,@PhoneNum,@QQNum,@GoodsImg)");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsID", SqlDbType.Int,4),
					new SqlParameter("@GoodsName", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Detail", SqlDbType.VarChar,500),
					new SqlParameter("@Price", SqlDbType.VarChar,50),
					new SqlParameter("@DownCount", SqlDbType.VarChar,50),
					new SqlParameter("@FirstClass", SqlDbType.VarChar,50),
					new SqlParameter("@SecondClass", SqlDbType.VarChar,50),
					new SqlParameter("@IsCharge", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@PhoneNum", SqlDbType.VarChar,50),
					new SqlParameter("@QQNum", SqlDbType.VarChar,50),
		            new SqlParameter("@GoodsImg", SqlDbType.VarChar, 500)};
            parameters[0].Value = model.GoodsID;
            parameters[1].Value = model.GoodsName;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.Detail;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.DownCount;
            parameters[6].Value = model.FirstClass;
            parameters[7].Value = model.SecondClass;
            parameters[8].Value = model.IsCharge;
            parameters[9].Value = model.Address;
            parameters[10].Value = model.PhoneNum;
            parameters[11].Value = model.QQNum;
            parameters[12].Value = model.GoodsImg;
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
        public bool Update(GoodsDetailModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GoodsDetail set ");
            strSql.Append("GoodsName=@GoodsName,");
            strSql.Append("Detail=@Detail,");
            strSql.Append("Price=@Price,");
            strSql.Append("FirstClass=@FirstClass,");
            strSql.Append("SecondClass=@SecondClass,");
            strSql.Append("IsCharge=@IsCharge,");
            strSql.Append("Address=@Address,");
            strSql.Append("PhoneNum=@PhoneNum,");
            strSql.Append("QQNum=@QQNum");
            strSql.Append(" where GoodsID=@GoodsID");
            SqlParameter[] parameters = {
				new SqlParameter("@GoodsName", SqlDbType.VarChar,50),
				new SqlParameter("@Detail", SqlDbType.VarChar,500),
				new SqlParameter("@Price", SqlDbType.VarChar,50),
				new SqlParameter("@FirstClass", SqlDbType.VarChar,50),
				new SqlParameter("@SecondClass", SqlDbType.VarChar,50),
			    new SqlParameter("@IsCharge", SqlDbType.VarChar,50),
				new SqlParameter("@Address", SqlDbType.VarChar,50),
				new SqlParameter("@PhoneNum", SqlDbType.VarChar,50),
				new SqlParameter("@QQNum", SqlDbType.VarChar,50),
                new SqlParameter("@GoodsID", SqlDbType.Int,8)
                                        };
             parameters[0].Value = model.GoodsName;
            parameters[1].Value = model.Detail;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.FirstClass;
            parameters[4].Value = model.SecondClass;
            parameters[5].Value = model.IsCharge;
            parameters[6].Value = model.Address;
            parameters[7].Value = model.PhoneNum;
            parameters[8].Value = model.QQNum;
            parameters[9].Value = model.GoodsID;
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
        public bool Delete(string GoodsID)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GoodsDetail ");
            strSql.Append(" where GoodsID=@GoodsID");
            SqlParameter[] parameters = {new SqlParameter("@GoodsID",SqlDbType.VarChar,50)
			};
            parameters[0].Value = GoodsID;
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
         public bool DeletebyUserId(int userid)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GoodsDetail ");
            strSql.Append(" where UserID=@userid");
            SqlParameter[] parameters = {new SqlParameter("@userid",SqlDbType.Int,10)
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
        /// 得到一个对象实体
        /// </summary>
        public GoodsDetailModel DataRowToModel(DataRow row)
        {
            GoodsDetailModel model = new GoodsDetailModel();
            if (row != null)
            {
                if (row["GoodsID"] != null && row["GoodsID"].ToString() != "")
                {
                    model.GoodsID = int.Parse(row["GoodsID"].ToString());
                }
                if (row["GoodsName"] != null)
                {
                    model.GoodsName = row["GoodsName"].ToString();
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["Detail"] != null)
                {
                    model.Detail = row["Detail"].ToString();
                }
                if (row["Price"] != null)
                {
                    model.Price = row["Price"].ToString();
                }
                if (row["DownCount"] != null)
                {
                    model.DownCount = row["DownCount"].ToString();
                }
                if (row["FirstClass"] != null)
                {
                    model.FirstClass = row["FirstClass"].ToString();
                }
                if (row["SecondClass"] != null)
                {
                    model.SecondClass = row["SecondClass"].ToString();
                }
                if (row["IsCharge"] != null)
                {
                    model.IsCharge = row["IsCharge"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["PhoneNum"] != null)
                {
                    model.PhoneNum = row["PhoneNum"].ToString();
                }
                if (row["QQNum"] != null)
                {
                    model.QQNum = row["QQNum"].ToString();
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
            strSql.Append("select GoodsID,GoodsName,UserID,Detail,Price,DownCount,FirstClass,SecondClass,IsCharge,Address,PhoneNum,QQNum ");
            strSql.Append(" FROM GoodsDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.GetDS(strSql.ToString());
        }
          public DataSet Getlistbyid(string goodsid)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(" select GoodsID,GoodsName,a.UserID,b.UserName,Detail,Price,DownCount,FirstClass,SecondClass,IsCharge,Address,a.PhoneNum,a.QQNum,a.GoodsImg FROM GoodsDetail a join UserInfo b on  a.UserID=b.UserID  where  GoodsID=");
            strsql.Append(goodsid);
            return DBHelper.GetDS(strsql.ToString());
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
        /// <param name="totalrecord">总记录数</param>
        /// <returns></returns>
        // TODO  修改用户名称不同步的BUG
        public DataTable GetAllGoods(string orderby, int sort, int page, int pageindex, ref int totalpage, ref int index, ref int totalrecord)
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
            paras[0].Value = "(select a.GoodsID ,a.UserName,b.Detail,b.PhoneNum,b.QQNum,b.Address,b.FirstClass,b.SecondClass, a.UserID,a.GoodsName,a.PublishTime,b.Price,b.DownCount,b.GoodsImg from AllGoods a left join GoodsDetail b on a.GoodsID=b.GoodsID) m";
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
            //return DBHelper.GetDt(_connectionStr, "Proc_PAGING", paras);
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
        }
         #region  额外添加
         public DataSet GetGoodsByClassid(string classid)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select c.goodsid,c.userid,d.UserName, c.GoodsName,c.GoodsImg,c.GoodsID,c.Price,c.PublishTime,c.Detail,c.FirstClass,c.SecondClass from (select   a.GoodsId,a.UserID,a.GoodsName,a.PublishTime,b.Detail,b.Price,b.GoodsImg,b.FirstClass,b.SecondClass from AllGoods a left join GoodsDetail b on a.GoodsID=b.GoodsID where b.SecondClass= ");
            str.Append(classid);
            str.Append(") c left join  UserInfo d  on c.UserID=d.UserID");
             DataSet ds = DBHelper.GetDS(str.ToString());
            return ds;
        }
         public DataSet GetGoodsByKeyWords(string keywords)
        {
            StringBuilder str = new StringBuilder();
            str.Append(
                "select c.GoodsID,c.GoodsName,c.UserID,c.UserName, c.Detail, c.GoodsImg,c.Price,d.PublishTime from  (select a.GoodsID,a.GoodsName,a.UserID,b.UserName, a.Detail, a.GoodsImg,a.Price FROM  GoodsDetail a left join UserInfo b on a.UserID=b.UserID  where GoodsName like '%");
            str.Append(keywords);
            str.Append("%' or Detail like '%");
            str.Append(keywords + "%') c left join AllGoods d on c.GoodsID=d.GoodsID ");
             DataSet ds = DBHelper.GetDS(str.ToString());
            return ds;
        }
         #endregion  额外添加
    }
}

