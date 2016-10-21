<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vera.UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/flat-ui.css" rel="stylesheet" />
    <link href="Styles/demo.css" rel="stylesheet" />
    <link href="Styles/index.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script>
        $(function () { $("[data-toggle='tooltip']").tooltip(); });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" style="margin-top: 100px;">
            <div class="row">
                <div class="col-lg-5"></div>
                <div class="col-lg-2" style="padding: 30px; background-color: white; border: 1px solid #DDDDDD">
                    <div class="login-form">
                        <div class="form-group">
                            <input type="text" class="form-control" value="" placeholder="用户名" id="txtUsername" runat="server" />
                            <label class="login-field-icon fui-user" for="login-name"></label>
                        </div>
                        <div class="form-group">
                            <input type="password" class="form-control" value="" placeholder="密码" id="txtPassword" runat="server" />
                            <label class="login-field-icon fui-lock" for="login-pass"></label>
                        </div>
            <%--            <div class="form-group">
                            <input type="text" class="form-control login-code-input" id="txtVerify" runat="server" placeholder="验证码" />
                            <img id="imgVerify" src="/Verification/VerifyCode.aspx?" alt="看不清？点击更换" onclick="this.src=this.src+'?'" class="login-code-img" />
                            <div style="clear: both;"></div>
                        </div>--%>
                        <asp:Button ID="Button1" CssClass="btn btn-primary btn-lg btn-block" runat="server" Text="登录" OnClick="Button1_Click" />
                    </div>
                    <a class="login-link" href="#">忘记密码？</a>
                </div>
                <div class="col-lg-5"></div>
            </div>
            <div class="row">
                <div class="reg_err">
                    <%=LoginErrorMessageshtml%>
                </div>
            </div>
        </div>
    </form>
</body>
</html>