<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
    <!-- 新 Bootstrap4 核心 CSS 文件 -->
    <link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" />
    <!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
    <script src="https://cdn.bootcss.com/jquery/3.2.1/jquery.min.js"></script>
    <!-- popper.min.js 用于弹窗、提示、下拉菜单 -->
    <script src="https://cdn.bootcss.com/popper.js/1.12.5/umd/popper.min.js"></script>
    <!-- 最新的 Bootstrap4 核心 JavaScript 文件 -->
    <script src="https://cdn.bootcss.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="row">
        <div class="col-2" style="height:600px;overflow:auto">
            <%for (int i = 0; i < FolderName.Length; i++)
                {%>
            <nav class="navbar bg-light">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="../Default.aspx?filePath=<%=FolderName[i]%>">
                            <img src="Account/images/folder.gif" /><%=FolderName[i]%>
                        </a>
                    </li>
                </ul>
            </nav>
            <%}%>
        </div>

        <div class="col-10" style="height:600px;overflow:auto">
            <%for (int i = 0; i < fileName.Length; i++)
                {
                    string[] displayName = fileName[i].Split('.');%>
            <div class="col-3" style="background-color:antiquewhite;height:320px;width:230px;float:left;margin-left:60px;margin-top:20px;">
                <h5><a href="ReadWord.aspx?id=<%="MasterFile/"+initFile+fileName[i]%>"><%=displayName[0]%></a></h5>
            </div>
            <%}%>
        </div>
    </div>
</asp:Content>