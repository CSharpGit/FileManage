<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户注册</title>
    <meta http-equiv="Content-Type" name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no text/html,charset=utf-8" />
    <!-- 新 Bootstrap4 核心 CSS 文件 -->
    <link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" />
    <!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
    <script src="https://cdn.bootcss.com/jquery/3.2.1/jquery.min.js"></script>
    <!-- popper.min.js 用于弹窗、提示、下拉菜单 -->
    <script src="https://cdn.bootcss.com/popper.js/1.12.5/umd/popper.min.js"></script>
    <!-- 最新的 Bootstrap4 核心 JavaScript 文件 -->
    <script src="https://cdn.bootcss.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>

    <link rel="stylesheet" type="text/css" href="../CSS/Css.css" />
    <style type="text/css">
        #getCode {
            position: relative;
            left: 20px;
            top: 2px;
            background-color: cornflowerblue;
            border: 1px solid cornflowerblue;
            border-radius: 5px;
            height: 50px;
            font-size: 20px;
            font-family: 'Bell MT';
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="row">
            <form id="form1" runat="server" autocomplete="off">
                <asp:ScriptManager runat="server" ID="SM1"></asp:ScriptManager>
                <asp:UpdatePanel runat="server" ID="hdivUP" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="display: none; position: absolute; top: 1000px; left: 1000px;" id="hdiv" runat="server"></div>
                        <asp:Label ID="dis" runat="server" Style="position: relative; left: 1000px; top: 1000px;"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="col-6" style="height: 700px; width: 520px;float:left;text-align:center;">
                    <h1 class="font-weight-bold"><mark>用户须知</mark></h1><br /><br />
                    <p class="text-primary text-left">为保证公安部成员信息安全，我们将统一管理每一位用户的详细信息，此信息必须真实有效。</p>
                    <h3 class="text-secondary">注意</h3><br />
                    <p class="text-primary text-left">您必须填写准确个人信息，编号为公安部统一编排的警员编号，这将是您唯一的通行证！</p>
                    <p class="text-primary text-left">注册过程中您必须通过您的邮箱获取验证码，如果忘记密码，邮箱即为您找回密码的依据！</p>
                    <br /><br /><br />
                    <p class="text-info text-right">——————公安部声明</p>
                </div>
                <div class="col-6" style="height: 700px; width: 520px; font-size: 20px; overflow: scroll; position: relative; text-align: center;float:right;">
                    姓名<br />
                    <asp:TextBox ID="name" runat="server" Width="400px" Font-Size="20px" ForeColor="#aaaabc" onfocus="tios('name')" onkeyup="check()"></asp:TextBox>
                    <asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="UP1">
                        <ContentTemplate>
                            <asp:Label runat="server" ID="nameTip" Height="20px" Width="100px" Text="用户名已使用！" Style="display: none; font-size: 12px; color: red;"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    年龄及性别<br />
                    <asp:TextBox ID="age" runat="server" Width="260px"></asp:TextBox>
                    男：
                    <input type="radio" style="display: inline; width: 20px; height: 20px;" runat="server" name="sex" value="男" />女：<input value="女" type="radio" name="sex" runat="server" style="width: 20px; height: 20px;" /><br />
                    <br />
                    编号<br />
                    <asp:TextBox ID="policeNum" runat="server" Width="400px" Font-Size="20px" ForeColor="#aaaabc" TextMode="Number" onfocus="tios('policeNum')" onkeyup="check()"></asp:TextBox><br />
                    <asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="UP2">
                        <ContentTemplate>
                            <asp:Label runat="server" ID="policeNumTip" Height="20px" Width="150px" Text="编号已使用！" Style="display: none; font-size: 12px; color: red;"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    电话号码<br />
                    <asp:TextBox ID="phoneNum" runat="server" Width="400px" Font-Size="20px" ForeColor="#aaaabc" TextMode="Phone" onfocus="tios('phoneNum')"></asp:TextBox><br />
                    <br />
                    身份证号<br />
                    <asp:TextBox ID="idNum" runat="server" Width="400px" Font-Size="20px" ForeColor="#aaaabc" TextMode="Number" MaxLength="18" onfocus="tios('idNum')"></asp:TextBox><br />
                    <br />
                    密码<br />
                    <input runat="server" id="pwd" type="text" enableviewstate="true" style="width: 400px; height: 40px; color: #aaaabc; font-size: 20px;" onfocus="javascript:x=document.getElementById('confPwd');x.value='';this.type='password'; this.style.color = 'black' ;this.style.fontFamily = 'Comic Sans MS';z=document.getElementById('pwdcom');z.style.display='none';" />
                    <br />
                    <br />
                    确认密码<br />
                    <input runat="server" enableviewstate="true" id="confPwd" type="text" style="width: 400px; height: 40px; color: #aaaabc; font-size: 20px;" onblur="compare()" onfocus="javascript:this.type='password'; this.style.color = 'black'; this.style.fontFamily = 'Comic Sans MS';z=document.getElementById('pwdcom');z.style.display='none';" />
                    <asp:Label runat="server" ID="pwdcom" Style="display: none; color: red; font-size: 12px;">密码不一致！</asp:Label>
                    <br />
                    <br />
                    邮箱<br />
                    <asp:TextBox ID="email" runat="server" Width="400px" Font-Size="20px" ForeColor="#aaaabc" TextMode="Email" onfocus="tios('email')" onkeyup="check()"></asp:TextBox><br />
                    <br />
                    <asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="UP3">
                        <ContentTemplate>
                            <asp:Label runat="server" ID="mailTip" Height="20px" Width="150px" Text="邮箱已使用！" Style="display: none; font-size: 12px; color: red;"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <asp:TextBox ID="checkCode" runat="server" Width="190px" Font-Size="20px" ForeColor="#aaaabc" placeholder="验证码" onfocus="tios('checkCode')"></asp:TextBox><asp:Button ID="getCode" OnClick="getCode_Click" runat="server" Text="获取验证码" Width="190px" Height="48px" /><br />
                    <br />
                    <asp:UpdatePanel UpdateMode="Conditional" ID="UPelse" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="confirm" runat="server" EnableViewState="true" OnClick="confirm_Click" Width="400px" CssClass="button" Style="position: relative; left: 0px;" Text="确认" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button Style="display: none" OnClick=" Unnamed_Click" runat="server" ID="hidden" />
            </form>
        </div>
    </div>
    <script>
        function tios(a) {
            x = document.getElementById(a);
            x.style.color = "black";
            x.style.fontFamily = "Comic Sans MS";
        }
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
        function check() {

            document.getElementById("hidden").click();
        }

    </script>
</body>

</html>
