using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Check 的摘要说明
/// </summary>
public class Check
{
	public static int[] InfCheck(string name,string email,string policeNum)
	{
        int[] result = new int[] { 0,0,0};
        DataTable dt = SqlHelper.ExecuteDataTable("select * from T_User");
        foreach (DataRow rowNew in dt.Rows)
        {
            if (string.Compare(rowNew["User_Name"].ToString().Trim(), name) == 0)
            {
                result[0] = 1;
            }
            if (string.Compare(rowNew["User_Mail"].ToString().Trim(), email) == 0)
            {
                result[1]=1;
            }
            if (string.Compare(rowNew["User_Num"].ToString().Trim(), policeNum) == 0)
            {
                result[2]=1;
            }
        }
        return result;
	}
    public void MailCheck()
    {

    }
}