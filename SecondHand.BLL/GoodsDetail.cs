using System.Data;
using System.Collections.Generic;
using SecondHand.DAL;
using SecondHand.Model;
namespace SecondHand.BLL
{
    public class GoodsDetail
    {
        private readonly GoodsDetailDAL _dal = new GoodsDetailDAL();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(GoodsDetailModel model)
        {
            return _dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GoodsDetailModel model)
        {
            return _dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string a)
        {
            return _dal.Delete(a);
        }
        /// <summary>
        /// 根据用户删除物品
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool DeletebyUserId(int a)
        {
            return _dal.DeletebyUserId(a);
        }
        /// <summary>
        /// 数据库翻页获得数据
        /// </summary>
        /// <param name="orderby">排序字段</param>
        /// <param name="sort">排序方式，0为升序，1为降序</param>
        /// <param name="page">每页多少条记录</param>
        /// <param name="pageindex">指定当前为第几页</param>
        /// <param name="totalpage">返回总页数</param>
        /// <param name="index">返回页数</param>
        /// <param name="totalrecord">总记录数</param>
        /// <returns></returns>
        public DataTable GetAllGoodsByPage(string orderby, int sort, int page, int pageindex, ref int totalpage, ref int index, ref int totalrecord)
        {
            return _dal.GetAllGoods(orderby, sort, page, pageindex, ref totalpage, ref index, ref  totalrecord);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return _dal.GetList(strWhere);
        }
        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="goodsid">物品ID号</param>
        /// <returns></returns>
        public DataTable Getdetailbyid(string goodsid)
        {
            DataSet ds = _dal.Getlistbyid(goodsid);
            return ds.Tables[0];
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GoodsDetailModel> DataTableToList(DataTable dt)
        {
            var modelList = new List<GoodsDetailModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GoodsDetailModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = _dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        /// <summary>
        /// 根据物品分类查询
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public DataSet GetGoodsByClassid(string classid)
        {
            return _dal.GetGoodsByClassid(classid);
        }
        /// <summary>
        /// 根据关键字模糊搜索
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public DataSet GetGoodsByKeyWords(string keywords)
        {
            return _dal.GetGoodsByKeyWords(keywords);
        }
        }
}
