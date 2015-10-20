using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
 namespace SecondHand.Web
{
    public class UiHelper
    {
        public static void Alert(Page page, string msg)//弹出提示框
        {
            string randomstr = Guid.NewGuid().ToString().Substring(0, 8);
            page.RegisterStartupScript(randomstr, "<script language='javascript'>alert('" + msg + "');</script>");
        }
         public static void confirmAlert(System.Web.UI.Page page, string msg)//弹出提示框
        {
            string randomstr = Guid.NewGuid().ToString().Substring(0, 8);
            page.RegisterStartupScript(randomstr, "<script language='javascript'>confirm('" + msg + "');</script>");
        }
        public static void Alert(System.Web.UI.Page page, UpdatePanel panel, string msg)//弹出提示框
        {
            string randomstr = Guid.NewGuid().ToString().Substring(0, 8);
            ScriptManager.RegisterStartupScript(panel, page.GetType(), randomstr, "<script language='javascript'>alert('" + msg + "');</script>", false);
        }
        public static void WindowOpenFull(System.Web.UI.Page page, string url)//弹出提示框
        {
            string randomstr = Guid.NewGuid().ToString().Substring(0, 8);
            page.ClientScript.RegisterStartupScript(page.GetType(), randomstr, "<script language='javascript'>window.open('" + url + "')</script>");
        }
        public static void Alerts(System.Web.UI.Page page, string msg)//弹出提示框
        {
            string randomstr = Guid.NewGuid().ToString().Substring(0, 8);
            page.ClientScript.RegisterStartupScript(page.GetType(), randomstr, "<script language='javascript'>alert('" + msg + "');</script>");
        }
        /// <summary>
        /// 跳转父页面
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        public static void AlertAndParentPageRedirect(System.Web.UI.Page page, string msg, string url)//弹出提示框
        {
             string randomstr = Guid.NewGuid().ToString().Substring(0, 8);
            page.ClientScript.RegisterStartupScript(page.GetType(), randomstr, "<script language='javascript' >alert('" + msg + "');window.parent.location.href = '" + url + "'</script>");
        }
         /// <summary>
        /// 弹出对话框，并跳转到指定页面
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="msg">提示消息</param>
        /// <param name="url">跳转页面</param>
        public static void AlertAndRedirect(System.Web.UI.Page page, string msg, string url)//弹出提示框
        {
             string randomstr = Guid.NewGuid().ToString().Substring(0, 8);
            page.RegisterStartupScript(randomstr, "<script language='javascript' >alert('" + msg + "');location.href = '" + url + "'</script>");
        }
         public static void ReturnAndCloseScript(System.Web.UI.Page page, string returnValue)//弹出提示框
        {
            string randomstr = Guid.NewGuid().ToString().Substring(0, 8);
            page.RegisterStartupScript(randomstr, "<script language='javascript'>window.returnValue='" + returnValue + "';if(window.opener && window.opener != null)window.opener.ReturnValue='" + returnValue + "';window.close();</script>");
        }
        /// <summary>
        /// 仅跳转
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="url">跳转页面</param>
        public static void Redirect(System.Web.UI.Page page, string url)//弹出提示框
        {
             string randomstr = Guid.NewGuid().ToString().Substring(0, 8);
            page.RegisterStartupScript(randomstr, "<script language='javascript' >location.href = '" + url + "'</script>");
        }
         public string GetUniqueCode()
        {
            string date = DateTime.Now.ToString("yyyyMMddHHmmss");
            string uniqueCode = date + getNumRandom(5);
            return uniqueCode;
        }
        public string getNumRandom(int count)
        {
            Random rd = new Random();
            string str = string.Empty;
            for (int i = 0; i < count; i++)
            {
                str += rd.Next(0, 9).ToString();
            }
            return str;
        }
     }
}