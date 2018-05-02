using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SqlHelper.OpenConnection())
        {
            Response.Write("<Script Language=JavaScript>alert('服务器连接失败，请稍后重试！');</Script>");
            return;
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_User where User_Num='" + user.Text.ToString().Trim() + "'");

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow rowNew in dt.Rows)
                {
                    if (string.Compare(rowNew["User_Password"].ToString(), password.Value.ToString().Trim()) == 0)
                    {
                        if (Session["CheckCode"].ToString() == checkCode.Text.Trim())
                        {
                            switch (rowNew["User_Identity"].ToString())
                            {
                                case "普通用户":
                                    Session["User_Name"] = rowNew["User_Name"].ToString();
                                    Response.Redirect("../Default.aspx");
                                    break;
                                case "管理员":
                                    Session["User_Name"] = rowNew["User_Name"].ToString();
                                    Session["U_Iden"] = rowNew["User_Identity"].ToString();
                                    Response.Redirect("Manage.aspx");
                                    break;
                            }
                        }
                        else
                        {
                            this.Response.Write("<Script Language=JavaScript>alert('验证码错误！');</Script>");
                        }

                    }
                    else
                    {
                        this.Response.Write("<Script Language=JavaScript>alert('密码错误');</Script>");
                    }
                }
            }
            else
            {
                this.Response.Write("<Script Language=JavaScript>alert('该用户不存在!');</Script>");
            }
        }
        catch (Exception)
        {

            //throw;
        }
    }
   
}