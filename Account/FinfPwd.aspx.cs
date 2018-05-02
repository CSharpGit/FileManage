using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Account_FinfPwd : System.Web.UI.Page
{
    static string check1; 
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void getCode_Click(object sender, EventArgs e)
    {
        Random random = new Random();
        check1 = random.Next(1111, 9999).ToString();
        string reciver = mail.Text.Trim();
        string subject = "软件基地注册验证码";
        string body = "您的注册验证码是" + check1;
        DataTable dt = SqlHelper.ExecuteDataTable("select User_Name from T_User where User_Mail='" + mail.Text.ToString().Trim() + "'");
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow rowNew in dt.Rows)
            {
                if (string.Compare(rowNew["User_Name"].ToString().Trim(), user.Text.ToString().Trim()) == 0)
                {
                    try
                    {
                        MailHelper.SendMail(reciver, subject, body);
                    }
                    catch
                    {
                        tip.Style.Add("display", "block"); content.Text = "发送验证码失败！";
                    }
                }
                else { tip.Style.Add("display", "block"); content.Text = "邮箱与用户名不匹配！"; }
            }
        }
        else { tip.Style.Add("display", "block"); content.Text = "该邮箱未注册！"; }
       
    }
    protected void confirm_Click(object sender, EventArgs e)
    {
        if (string.Compare(check1, checkCode.Text.Trim()) == 0)
        {
            
            firstDiv.Style.Add("display", "none");
            secondDiv.Style.Add("display", "block");
        }
        else
        {
            tip.Style.Add("display", "block"); content.Text = "验证码错误！";
        }
    }
    protected void pwdRewrite_Click(object sender, EventArgs e)
    {
        try
        {
            SqlHelper.ExecuteNonQuery("update T_User set User_Password='" + pwd.Value.ToString().Trim() + "'where User_Mail='" + mail.Text.Trim() + "' ");
            secondDiv.Style.Add("display", "none");
            thirdDiv.Style.Add("display", "block");
        }
        catch 
        {
            this.Response.Write("发生未知错误！");
            
        }

    }
    protected void okOrno_Click(object sender, EventArgs e)
    {
        tip.Style.Add("display", "none");
    }
}