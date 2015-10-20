using System.Data;
using System.Collections.Generic;
using SecondHand.Model;
using SecondHand.DAL;
namespace SecondHand.BLL
{
    /// <summary>
    /// GoodsComment
    /// </summary>
    public class GoodsComment
    {
        private readonly GoodsCommentDAL _dal = new GoodsCommentDAL();         /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GoodsCommentModel model)
        {
            return _dal.Add(model);
        }              #region  额外添加
         /// <summary>
        /// 根据物品ID号返回物品
        /// </summary>
        /// <param name="goodsid"></param>
        /// <returns></returns>
         public DataSet GetGoodsComment(string goodsid)
        {
            return _dal.GetComment(goodsid);
         }
         #endregion  额外添加
    }
}
 