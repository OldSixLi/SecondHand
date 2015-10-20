using System.Data;
using System.Collections.Generic;
using SecondHand.DAL;
using SecondHand.Model;
namespace SecondHand.BLL
{
    /// <summary>
    /// UserInfo
    /// </summary>
    public class UserInfo
    {
        private readonly UserInfoDAL _dal = new UserInfoDAL();
         /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(UserInfoModel model)
        {
            return _dal.Add(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int userid)
        {
            //该表无主键信息，请自定义主键/条件字段
            return _dal.Delete(userid);
        }
         /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string userid)
        {
            string strWhere = "UserName";
            return _dal.GetList(strWhere);
        }
         /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<UserInfoModel> GetModelList(string strWhere)
        {
            DataSet ds = _dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<UserInfoModel> DataTableToList(DataTable dt)
        {
            var modelList = new List<UserInfoModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                UserInfoModel model;
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
         public bool AdminUpdateInfo(UserInfoModel model)
        {
            return _dal.AdminUpdate(model);
        }
         public bool UpdateUserIcon(string userid, string iconfile)
        {
            return _dal.UpdateUserIcon(userid, iconfile);
        }
    }
}
