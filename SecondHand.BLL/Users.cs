
using System;
using System.Data;
using SecondHand.DAL;
using SecondHand.Model;
namespace SecondHand.BLL
{
    /// <summary>
    /// Users
    /// </summary>
    public class Users
    {
        private readonly UsersDAL _dal = new UsersDAL();
         public DataTable GetAllUserssByPage(string orderby, int sort, int page, int pageindex, ref int totalpage, ref int index, ref int totalrecord)
        {
            return _dal.GetAllUsers(orderby, sort, page, pageindex, ref totalpage, ref index, ref  totalrecord);
        }
         /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(UsersModel model)
        {
            return _dal.Add(model);
        }
          /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int userId)
        {
             return _dal.Delete(userId);
        }
          /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UsersModel GetModel(int userId)
        {
            return _dal.GetModel(userId);
        }
         /// <summary>
        /// 根据用户名返回相关数据列表
        /// </summary>
        public UsersModel GetbynameModel(string logincode)
        {
            return _dal.GetbynameModel(logincode);
        }
         /// <summary>
        /// 
        /// 密码验证
        /// </summary>
        public int LoginTest(string logincode, string password)
        {
            string strWhere = "LoginCode='" + logincode + "'";
            DataSet ds = _dal.GetList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string passWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
                if (passWord == password)
                {
                    //登陆成功
                    if (ds.Tables[0].Rows[0]["UserType"].ToString() == "1")
                    {
                        //普通用户
                        return 0;
                    }
                    //管理员用户
                    return 1;
                }
                //密码不正确
                return 2;
            }
             //不存在此用户
             return 3;
        }
          /// <summary>
        /// 返回List
        /// </summary>
        /// <param name="logincode"></param>
        /// <returns></returns>
        public UsersModel GetUserInfo(string logincode)
        {
            //DataSet ds = new DataSet();
            DataTable dt = _dal.GetUserInfo(logincode).Tables[0];
            if (dt.Rows.Count > 0)
            {
                var usermodeModel = new UsersModel();
                var userinfo = new UserInfoModel();
                usermodeModel.LoginCode = dt.Rows[0]["LoginCode"].ToString();
                usermodeModel.UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
                usermodeModel.UserType = dt.Rows[0]["UserType"].ToString();
                usermodeModel.PassWord = dt.Rows[0]["PassWord"].ToString();
                userinfo.UserName = dt.Rows[0]["UserName"].ToString();
                userinfo.RegTime = dt.Rows[0]["RegTime"].ToString();
                userinfo.Email = dt.Rows[0]["Email"].ToString();
                userinfo.Sex = dt.Rows[0]["Sex"].ToString();
                userinfo.ContentNum = dt.Rows[0]["ContentNum"].ToString();
                userinfo.PhoneNum = dt.Rows[0]["PhoneNum"].ToString();
                userinfo.QQ = dt.Rows[0]["QQ"].ToString();
                userinfo.UserIcon = dt.Rows[0]["UserIcon"].ToString();
                usermodeModel.gg = userinfo;
                return usermodeModel;
            }
             return null;
        }
          public bool UpdateAdmin(UsersModel model)
        {
            return _dal.UpdateAdmin(model);
        }
         public bool UpdatePass(UsersModel model)
        {
            return _dal.UpdatePass(model);
        }
     }
 }
  