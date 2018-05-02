using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class Account_Manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["U_Iden"]==null|| Session["U_Iden"].ToString()!="管理员")
            {
                Response.Write("<Script Language=JavaScript>alert('非法请求！');</Script>");
                return;
            }
        }
    }
}