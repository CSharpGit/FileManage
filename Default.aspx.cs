using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    public string[] FolderName;
    public string filePath;
    public string[] fileName;
    public string initFile;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["User_Name"] != null)
        {
            string FolderPath = Server.MapPath("MasterFile/");
            DirectoryInfo[] FolderList = GetFolderByDir(FolderPath);
            FolderName = new string[FolderList.Length];
            for (int i = 0; i < FolderList.Length; i++)
            {
                FolderName[i] = FolderList[i].ToString();
            }
            if (Request.QueryString["filePath"] != null)
            {
                initFile = Request.QueryString["filePath"].ToString() + "/";
                filePath = FolderPath + Request.QueryString["filePath"].ToString() + "/";
            }
            else
            {
                initFile = FolderName[0].ToString() + "/";
                filePath = FolderPath + FolderName[0].ToString() + "/";
            }
            FileInfo[] Filelist = GetFilesByDir(filePath);
            fileName = new string[Filelist.Length];
            for (int i = 0; i < Filelist.Length; i++)
            {
                fileName[i] = Filelist[i].ToString();
            }
        }
        else
        {
            Response.Redirect("Account/Login.aspx");
        }
    }

    public FileInfo[] GetFilesByDir(string path)
    {
        DirectoryInfo di = new DirectoryInfo(path);
        FileInfo[] fi = di.GetFiles();
        return fi;
    }

    public DirectoryInfo[] GetFolderByDir(string path)
    {
        DirectoryInfo di = new DirectoryInfo(path);
        DirectoryInfo[] DirInfo = di.GetDirectories();
        return DirInfo;
    }
}