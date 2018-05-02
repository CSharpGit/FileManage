<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="ReadWord.aspx.cs" Inherits="ReadWord" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">

</asp:Content>
<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="width: 1246px; height: 800px;margin-left: 0px;">
        <iframe src="<%=Readpdf%>" style="width:1246px;background-color:darkgray;height:800px;border:0"></iframe>
    </div>
</asp:Content>