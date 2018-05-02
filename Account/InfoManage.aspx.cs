using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_InfoManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["U_Iden"] != null && Session["U_Iden"].ToString() == "管理员")
            {
                bind();
            }
            else
            {
                Response.Write("<Script Language=JavaScript>alert('非法请求！!');</Script>");
                return;
            }
        }
    }

    public void bind()
    {
        string selectStr= "select * from T_User";
        DataSet myds = SqlHelper.dataSet(selectStr);
        GridView1.DataSource = myds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
    }

    /// <summary>
    /// 在 GridView 控件中的某个行被绑定到一个数据记录时发生。此事件通常用于在某个行被绑定到数据时修改该行的内容。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        //注释了后，序号为数据库里面的ID序号。不注释，序号从1开始排列。
        //if (e.Row.RowIndex != -1)
        //{
        //    int id = GridView1.PageIndex * GridView1.PageSize + e.Row.RowIndex + 1;
        //    e.Row.Cells[0].Text = id.ToString();
        //}
    }
    /// <summary>
    /// 此方法必重写，否则会出错
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int parent_index = e.NewEditIndex;
        GridView1.EditIndex = parent_index;
        bind();
        Session["ID"] = Convert.ToInt32(GridView1.DataKeys[parent_index].Value);
        string sqlStr = "select * from T_User where ID=" + Convert.ToInt32(Session["ID"].ToString());
        DataSet myds = SqlHelper.dataSet(sqlStr);
    }
    protected void ParentGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }
    /// <summary>
    /// 在单击 GridView 控件内某一行的 Update 按钮（其 CommandName 属性设置为"Update"的按钮）时发生，但在 GridView 控件更新记录之前。此事件通常用于取消更新操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string U_Name, U_Sex, U_Num, U_Email, U_Phone, U_Iden;
        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string Name = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString();
        string Sex = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
        string Num = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();
        string Email = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
        string Phone = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim();
        string Identity = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString().Trim();
        try
        {
            U_Name = Name;
            U_Sex = Sex;
            U_Num = Num;
            U_Email = Email;
            U_Phone = Phone;
            U_Iden = Identity;
            string sqlStr = "update T_User set User_Name='" + U_Name + "',User_Sex='" + U_Sex + "',User_Num='" + U_Num + "',User_Mail='" + U_Email + "',User_Phone='" + U_Phone + "',User_Identity='" + U_Iden + "';";
            SqlHelper.ExecuteSql(sqlStr);
            GridView1.EditIndex = -1;
            bind();
        }
        catch (Exception)
        {
            //Response.Write("<script>alert('请重新确认输入！');</script>");
        }
    }
    /// <summary>
    /// 当复选框被点击时发生
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)(GridView1.Rows[i].FindControl("CheckBox1"));
            if (CheckBox2.Checked == true)
            {
                cbox.Checked = true;
            }
            else
            {
                cbox.Checked = false;
            }
        }
    }
    /// <summary>
    /// 删除所选记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (cbox.Checked == true)
            {
                SqlHelper.ExecuteSql("delete from Fangjian where ID=" + Convert.ToUInt32(GridView1.DataKeys[i].Value) + "");
            }
        }
        bind();
    }
    /// <summary>
    /// 恢复选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            cbox.Checked = false;
        }
    }
}