using System.Data;
using SecondHand.DAL;
namespace SecondHand.BLL
{
    /// <summary>
    /// Saves
    /// </summary>
    public class Saves
    {
        private readonly SaveDall _dal = new SaveDall();
         /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.Saves model)
        {
            return _dal.Add(model);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return _dal.GetList(strWhere);
        }
    }
}
