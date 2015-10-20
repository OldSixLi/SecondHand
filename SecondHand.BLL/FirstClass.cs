using System.Data;
using SecondHand.DAL;
namespace SecondHand.BLL
{
    /// <summary>
    /// FirstClass
    /// </summary>
    public class FirstClass
    {
        private readonly FirstClassDAL _dal = new FirstClassDAL();
        public DataSet GetList(string strWhere)
        {
            return _dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }     }
}
