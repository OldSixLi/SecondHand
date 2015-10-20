using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography; namespace SecondHand.Web
{
    public partial class SendEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {         }
        public  bool SendMail(string toemail)
        {
            try
            {
                //MailConfigModel mail = new MailConfigModel();
                //MailInfoLogic mil = new MailInfoLogic();
                //mail = mil.getMail(emailConfigId);
                //TODO 发件人邮箱地址，名称，编码UTF8   
                MailAddress mailfrom = new MailAddress("tjkwswyyc@163.com", "李老六", System.Text.Encoding.UTF8);
                //TODO 收件人邮箱地址，名称，编码UTF8  
                MailAddress mailto = new MailAddress(toemail, "", System.Text.Encoding.UTF8);
                //TODO 声明一个新的变量，邮箱
                System.Net.Mail.MailMessage mailMsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
                //TODO 主题
                mailMsg.Subject ="邮件主题";
                //TODO 编码规格
                mailMsg.BodyEncoding = Encoding.UTF8;
                //TODO 是否是网页
                mailMsg.IsBodyHtml = true;//是否为网页
                //TODO 指定邮件的优先级
                mailMsg.Priority = System.Net.Mail.MailPriority.Normal;
                //TODO 简单的传输协议
                SmtpClient smtp = new SmtpClient();
                //TODO 获取或设置用于验证发件人身份的凭据。
                smtp.Credentials = new NetworkCredential("tjkwswyyc@163.com", "64634808");
                //TODO 获取或设置用于 SMTP 事务的端口。
                smtp.Port =25; // Gmail 使用 465 和 587 端口 
                //TODO 获取或设置用于 SMTP 事务的主机的名称或 IP 地址。
                smtp.Host = "smtp.163.com"; // 如 smtp.163.com, smtp.gmail.com 
                //TODO 指定 SmtpClient 是否使用安全套接字层 (SSL) 加密连接。
                smtp.EnableSsl = false; // 如果使用GMail，则需要设置为true 
                //TODO 组合主体
                string body = string.Empty;
                string strBody = string.Empty;
                //body = mail.MailContent.Replace("$(emailVerificationCode)", emailVerificationCode);
                body = "你们的人们的人数的是你们的热";
                //body = body.Replace("\r\n", "<br/>");
                //strBody = "<html>{0}</html>";
                //TODO 邮件主体
                //mailMsg.Body = string.Format(strBody, body);
                mailMsg.Body = body;
                //TODO 发送
                try
                {
                    smtp.Send(mailMsg);
                    return true;
                }
                catch (Exception ex)
                {
                    //错误处理
                    throw;
                }
            }
            catch
            {
                throw;
            }
        }         protected void Button1_Click(object sender, EventArgs e)
        {
       bool issuccess= SendMail("1136191854@qq.com");
            if (issuccess)
            {
                UiHelper.Alert(this,"成功！");
            }
        }
    }
}