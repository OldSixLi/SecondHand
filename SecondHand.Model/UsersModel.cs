
using System;
namespace SecondHand.Model
{
    /// <summary>
    /// Users:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class UsersModel
    {
        public UsersModel()
        { }
        #region Model
        private int _userid;
        private string _logincode;
        private string _password;
        private string _usertype;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 登陆帐号
        /// </summary>
        public string LoginCode
        {
            set { _logincode = value; }
            get { return _logincode; }
        }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string PassWord
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        #endregion Model
         public UserInfoModel gg { get; set; }
     }
}

