using System.Data;
using System.Collections.Generic;
using SecondHand.Model;
using SecondHand.DAL;
namespace SecondHand.BLL
{
    /// <summary>
    /// AllGoods
    /// </summary>
    public class AllGoods
    {
        private readonly AllGoodsDAL _dal = new AllGoodsDAL();         /// <summary>
        /// 数据库翻页获得数据
        /// </summary>
        /// <param name="orderby">排序字段</param>
        /// <param name="sort">排序方式，0为升序，1为降序</param>
        /// <param name="page">每页多少条记录</param>
        /// <param name="pageindex">指定当前为第几页</param>
        /// <param name="totalpage">返回总页数</param>
        /// <param name="index">返回页数</param>
        /// <returns></returns>
        public DataTable GetAllGoodsByPage(string orderby, int sort, int page, int pageindex, ref int totalpage, ref int index)
        {
            return _dal.GetAllGoods(orderby, sort, page, pageindex, ref totalpage, ref index);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(AllGoodsModel model)
        {
            return _dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AllGoodsModel model)
        {
            return _dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int goodsId)
        {
            return _dal.Delete(goodsId);
        }
        public bool DeletebyUserId(int goodsId)
        {
            return _dal.DeletebyUserId(goodsId);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return _dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AllGoodsModel> DataTableToList(DataTable dt)
        {
            var modelList = new List<AllGoodsModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    AllGoodsModel model = _dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        public DataSet GetPersonPublishGoods(string userid)
        {
            return _dal.GetPersonPublishGoods(userid);
        }
        public int Getgoodscounbyuserid(string userid)
        {
            return _dal.Getgoodscounbyuserid(userid);
        }
        public int GetGoodsCount()
        {
            return _dal.GetGoodsCount();
        }
        public int GetusersCount()
        {
            return _dal.GetUsersCount();
        }
        public int GetCommentsCount()
        {
            return _dal.GetCommentsCount();
        }
    }
}
