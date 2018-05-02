<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FinfPwd.aspx.cs" Inherits="Account_FinfPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <title></title>
    <link rel="stylesheet" href="../CSS/Css.css" type="text/css" />
    <style type="text/css">
        .centerDiv {
            position: absolute;
            top: 50%;
            left: 50%;
            width: 600px;
            height: 600px;
            margin-left:-300px;
            margin-top:-200px;
            text-align:center;
        }
    </style>
</head>
<body style="background:url(../ima/登录背景.png) no-repeat;background-size:cover;background-attachment:fixed" >
    <form id="form1" runat="server">
        <div class="centerDiv" runat="server" id="firstDiv" style="">
            <asp:TextBox ID="user" runat="server" Width="400px" placeholder="用户名"></asp:TextBox><br /><br />
            <asp:TextBox ID="mail" runat="server"  Width="400px" placeholder="邮箱"></asp:TextBox><br /><br />
            <asp:TextBox ID="checkCode" runat="server" Width="190px"  Style="position:relative;left:-8px;"  placeholder="验证码"></asp:TextBox>
            <asp:Button ID="getCode" runat="server" Width="190px" CssClass="button" Text="获取验证码" Style="position:relative;left:10px;" OnClick="getCode_Click" /><br /><br />
            <asp:Button ID="confirm" runat="server" Width="400px" CssClass="button" style="position:relative;left:0px;" Text="确认" OnClick="confirm_Click" />
        </div>
        <div style="display: none;" class="centerDiv" runat="server" id="secondDiv">
            密码<br />
            <input runat="server" id="pwd" type="text" enableviewstate="true" style="width: 400px; height: 40px; color: #aaaabc; font-size: 20px;" onfocus="javascript:x=document.getElementById('confPwd');x.value='';this.type='password'; this.style.color = 'black' ;this.style.fontFamily = 'Comic Sans MS';z=document.getElementById('pwdcom');z.style.display='none';" />
            <br />
            <br />
            确认密码<br />
            <input runat="server" enableviewstate="true" id="confPwd" type="text" style="width: 400px; height: 40px; color: #aaaabc; font-size: 20px;" onblur="compare()" onfocus="javascript:this.type='password'; this.style.color = 'black'; this.style.fontFamily = 'Comic Sans MS';z=document.getElementById('pwdcom');z.style.display='none';" />
            <asp:Label runat="server" ID="pwdcom" Style="display: none; color: red; font-size: 12px;">密码不一致！</asp:Label>
            <br /><br />
            <asp:Button runat="server" ID="pwdRewrite" Text="确认修改" CssClass="button" Style="float: left;" OnClick="pwdRewrite_Click" />
        </div>
        <div runat="server" class="centerDiv" id="thirdDiv" style="display: none;">
            <h1 style="color:cornflowerblue;font-family:'楷体';font-size:50px;">修改完成！</h1>
        </div>
        <div runat="server" class="centerDiv" id="tip" style="display: none; z-index: 9999; border:solid;background-color: white; width: 250px;position:absolute;left:50%;top:50%;margin-left:-150px;height:150px;margin-top:-100px; ">
           <asp:Label runat="server" ID="content"  style="position:relative;left:30%;top:30%; text-align:center"></asp:Label>
            <asp:Button ID="okOrno" runat="server"  Height="20px" Width="50px" style="position:relative;top:120px;float:right;margin-right:20px;" Text="确认" OnClick="okOrno_Click" />
        </div>
    </form>
    <script>
        function compare() {
            x = document.getElementById('pwd');
            y = document.getElementById('confPwd');
            z = document.getElementById('pwdcom');
            confButton = document.getElementById('confirm');
            if (x.value != y.value) {
                z.style.display = 'block';
                confButton.style.display = 'none';
            }
            else {
                z.style.display = 'none';
                confButton.style.display = 'block';
            }
        }
    </script>
</body>
</html>
