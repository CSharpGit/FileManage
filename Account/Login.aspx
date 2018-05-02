<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登录</title>
    <link rel="stylesheet" type="text/css" href="../CSS/Css.css" />
</head>
<body style="background:url(../ima/登录背景.png)no-repeat;background-size:cover;background-attachment:fixed">
    <form id="form1" runat="server" action="login.aspx" method="post">
        <div style="position: absolute; left: 50%; top: 50%; margin-top: -200px; margin-left: -300px; width: 600px; height: auto;">
            <p style="font-family: Constantia; font-size: 36px; text-align: center; width: 300px; margin-left: 150px;">文件管理系统登录</p>
            <span style="margin-left: 150px;">
                <asp:TextBox runat="server" ID="user" Style="height: 40px; width: 300px;" Font-Size="20px" ForeColor="#aaaabc" placeholder="用户名" onfocus=" this.style.color = 'black'; this.style.fontFamily = 'Comic Sans MS';">
                </asp:TextBox>
            </span>
            <div style="margin-left: 150px; margin-top: 20px">
                <input id="password" type="password" runat="server" placeholder="密码" onfocus="this.style.color = 'black'; this.style.fontFamily = 'Comic Sans MS';" style="width: 300px; height: 40px; color: #aaaabc; font-size: 20px;" />
            </div>
            <div style="margin-left: 150px; margin-top: 0px">
                <asp:TextBox ID="checkCode" runat="server" Font-Size="20px" ForeColor="#aaaabc" Width="195px" Height="40px" placeholder="验证码" onfocus=" this.style.color = 'black'; this.style.fontFamily = 'Comic Sans MS';"></asp:TextBox>
                <img runat="server" src="CheckCode.aspx" style="width: 100px; height: 45px; position: relative; top: 15px;" onclick="changeImage()" id="imgCode" />
            </div>
            <br />
            <asp:Button runat="server" CssClass="button" ID="submit" OnClick="submit_Click" Text="登录" onmousemove="changein()" onmouseout="changeout()" /><br />
            <span style="position: relative; top: 20px; left: 200px;">
                <a href="Register.aspx" title="新用户注册" id="register" style="position: relative; left: 90px;">新用户注册</a>
                <a target="_blank" href="FinfPwd.aspx" title="忘记密码" id="forgetPwd" style="position: relative; left: 90px;">| 忘记密码?</a>
            </span>
        </div>
    </form>
    <script>
        function changein() {
            var bt = document.getElementById("submit");
            bt.style.border = '10px double cornflowerblue';
        }
        function changeout() {
            var bt = document.getElementById("submit");
            bt.style.border = '1px solid cornflowerblue';
        }
        function changeImage() {
            var img = document.getElementById("imgCode");
            img.src = "CheckCode.aspx?" + Math.random();
        }
    </script>
</body>
</html>
