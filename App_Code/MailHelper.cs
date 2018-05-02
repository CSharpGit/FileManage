using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

/// <summary>
/// MailHelper 的摘要说明
/// </summary>
public class MailHelper
{
   
        public static void SendMail(string reciver, string subject, string body)
        {
            MailAddress mailer = new MailAddress("1192593576@qq.com");
            MailMessage msg = new MailMessage();
            msg.From = mailer;
            msg.To.Add(reciver);
            msg.Subject = subject;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = body;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            SmtpClient smtp = new SmtpClient("smtp.qq.com", 25);
            smtp.Credentials = new NetworkCredential("1192593576@qq.com", "bywhashihoejheff");
            smtp.EnableSsl = true;
            smtp.Send(msg);
        }
    
}