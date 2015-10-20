using System.Data;
using System.Collections.Generic;
using SecondHand.DAL;
using SecondHand.Model;
namespace SecondHand.BLL
{
    /// <summary>
    /// SecondClass
    /// </summary>
    public class SecondClass
    {
        private readonly SecondClassDAL _dal = new SecondClassDAL();
        public DataSet GetList(string strWhere)
        {
            return _dal.GetList(strWhere);
        }
        /// <summary>
       /// 根据二级分类ID号返回分类名称，根据分类查询时使用
       /// </summary>
       /// <param name="classid"></param>
       /// <returns></returns>
        public string GetclassName(string classid)
        {
            DataSet ds = _dal.GetclassName(classid);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["ClassName"].ToString();
            }
            return null;
        }
     }
}
