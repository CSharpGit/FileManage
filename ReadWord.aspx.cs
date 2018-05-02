using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.Words;
using Aspose.Words.Drawing;

public partial class ReadWord : System.Web.UI.Page
{
    protected string Readpdf = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            Readpdf = Server.UrlDecode(Request.QueryString["id"].ToString());
            Response.ContentType = "application/pdf";
            Response.Clear();
            Response.TransmitFile(Readpdf);
            Response.End();
        }
    }
}