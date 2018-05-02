<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoManage.aspx.cs" MasterPageFile="~/Account/site1.master" Inherits="Account_InfoManage" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
    <meta http-equiv="Content-Type" name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no text/html,charset=utf-8" />
    <!-- 新 Bootstrap4 核心 CSS 文件 -->
    <link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" />
    <!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
    <script src="https://cdn.bootcss.com/jquery/3.2.1/jquery.min.js"></script>
    <!-- popper.min.js 用于弹窗、提示、下拉菜单 -->
    <script src="https://cdn.bootcss.com/popper.js/1.12.5/umd/popper.min.js"></script>
    <!-- 最新的 Bootstrap4 核心 JavaScript 文件 -->
    <script src="https://cdn.bootcss.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="ct1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" BorderColor="Black" Font-Size="12px" 
        OnRowDataBound="GridView1_RowDataBound" Width="100%" OnRowUpdating="GridView1_RowUpdating"
         OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="ParentGridView_RowCancelingEdit">
        <Columns>
            <asp:TemplateField HeaderText="选择" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="User_Name" HeaderText="姓名" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"/>
            <asp:BoundField DataField="User_Sex" HeaderText="性别" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"/>
            <asp:BoundField DataField="User_Num" HeaderText="编号" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"/>
            <asp:BoundField DataField="User_Mail" HeaderText="邮箱" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"/>
            <asp:BoundField DataField="User_Phone" HeaderText="电话" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"/>
            <asp:BoundField DataField="User_Identity" HeaderText="身份" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"/>
            <asp:CommandField HeaderText="编辑" ShowEditButton="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"/>
        </Columns>
        <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle"/>
        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
        <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
    </asp:GridView>
    <br />
    <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="CheckBox2_CheckedChanged"
        Text="全选" AutoPostBack="True" />
    <asp:Button ID="Button1" runat="server" Height="25px" Text="删　除" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Height="25px" Text="取　消" OnClick="Button2_Click" />
</asp:Content>
