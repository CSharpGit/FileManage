using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class Account_Register : System.Web.UI.Page
{
    static string checkCode1 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        SM1.RegisterAsyncPostBackControl(this.hidden);
        SM1.RegisterAsyncPostBackControl(this.getCode);
        SM1.RegisterAsyncPostBackControl(this.confirm);
    }
    protected void confirm_Click(object sender, EventArgs e)
    {
        if (name.Text==""||idNum.Text==""||phoneNum.Text==""||policeNum.Text==""||pwd.Value.ToString().Trim()==""||confPwd.Value.ToString().Trim()=="")
        {
            this.Response.Write("<Script Language=JavaScript>alert('请填写完整信息！');</Script>");
        }
        else
        {
            string sex = "";
            if (this.Request.Form["sex"]!=null)
            {
                sex = this.Request.Form["sex"].ToString().Trim();
            }
            int i = 0; string password = "";
            if (string.Compare(checkCode1.Trim(), checkCode.Text.ToString().Trim()) == 0)
            {
                if (pwd != null) password = pwd.Value.ToString().Trim();
                try
                {
                    int[] checkNum = Check.InfCheck(name.Text.ToString().Trim(), email.Text.ToString().Trim(), policeNum.Text.ToString().Trim());
                    foreach (int number in checkNum)
                    {
                        if (number == 1)
                            i = 1;
                    }
                    if (pwd.Value.ToString().Trim() != confPwd.Value.ToString().Trim())
                        i = 1;
                }
                    
                catch (Exception ex)
                {
                    this.Response.Write("<Script Language=JavaScript>alert('" + ex.Message.ToString() + "');</Script>");
                }
                if (i != 1 && name != null && password != null)
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery("insert into T_User (User_Name,User_Password,User_mail,User_Idi,User_Num,User_Phone,User_Age,User_Sex) values ('" + name.Text.Trim() + "','" + password + "','" + email.Text.Trim() + "','" + idNum.Text.ToString().Trim() + "','" + policeNum.Text.ToString().Trim() + "','" + phoneNum.Text.ToString().Trim() + "','"+age.Text.ToString().Trim()+"','"+sex+"')");
                        hdiv.Style.Add("display", "normal");
                        dis.Text = "注册成功！";
                        hdivUP.Update();
                        Response.Redirect("Login.aspx");
                    }
                    catch
                    {
                    }
                }
                else
                {
                    this.Response.Write("<Script Language=JavaScript>alert('注册失败！');</Script>");
                }
            }
            else
            {
                this.Response.Write("<Script Language=JavaScript>alert('验证码错误！');</Script>");
            }
        }
    }

    protected void getCode_Click(object sender, EventArgs e)
    {
        if (email.Text.ToString().Trim() == null || string.Compare(mailTip.Style["display"].ToString(),"inline")==0)
        {
            hdiv.Style.Add("display", "normal");
            dis.Text = "注册失败！";
            hdivUP.Update();
        }
        else
        {
            try
            {
                Random random = new Random();
                checkCode1 = random.Next(1111, 9999).ToString();
                string reciver = email.Text.Trim();
                string subject = "软件研发中心注册验证码";
                string body = "您的注册验证码是" + checkCode1;
                MailHelper.SendMail(reciver, subject, body);
                this.checkCode.Focus();
            }
            catch 
            {

                this.Response.Write("<Script Language=JavaScript>alert('邮箱错误！');</Script>");
            }
        }
        UP1.Update();
    }



    int []error;
    protected void Unnamed_Click(object sender, EventArgs e)
    {
         error = Check.InfCheck(name.Text.ToString().Trim(), email.Text.ToString().Trim(), policeNum.Text.ToString().Trim());
         if (error[0] == 1) { nameTip.Style.Add("display", "inline"); UP1.Update(); } else { nameTip.Style.Add("display", "none"); UP1.Update(); }
         if (error[1] == 1) { mailTip.Style.Add("display", "inline"); UP3.Update(); } else { mailTip.Style.Add("display", "none"); UP3.Update(); }
         if (error[2] == 1) { policeNumTip.Style.Add("display", "inline"); UP2.Update(); } else {policeNumTip.Style.Add("display", "none");UP2.Update();}
         if (error[0]==1||error[1]==1||error[2]==1)
         {
             confirm.Style.Add("display", "none"); UPelse.Update();
         }
         else
         {
             confirm.Style.Add("display", "normal"); UPelse.Update();
         }
        
    }
}
