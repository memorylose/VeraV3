<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Vera.UI.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/NewIndex.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" style="margin-top: 100px;">
            <div class="row">
                <div class="col-lg-5"></div>
                <div class="col-lg-2" style="padding: 30px; background-color: white; border: 1px solid #DDDDDD">
                    <input type="text" class="form-control" value="" placeholder="用户名" id="txtUsername" runat="server" style="margin-bottom: 20px;" />
                    <input type="text" class="form-control" value="" placeholder="昵称" id="txtNickname" runat="server" style="margin-bottom: 20px;" />
                    <input type="password" class="form-control" value="" placeholder="密码" id="txtPassword" runat="server" style="margin-bottom: 20px;" />
                    <input type="password" class="form-control" value="" placeholder="再次输入密码" id="txtConfirmPassword" runat="server" style="margin-bottom: 20px;" />
                    <input type="text" class="form-control" value="" placeholder="邮箱" id="txtMail" runat="server" style="margin-bottom: 20px;" />
                    <input type="text" class="form-control" value="" placeholder="性别" id="txtGender" runat="server" style="margin-bottom: 20px;" />
                    <input type="text" class="form-control" value="" placeholder="职业" id="txtPro" runat="server" style="margin-bottom: 20px;" />
                    <input type="text" class="form-control" value="" placeholder="领域" id="txtMajor" runat="server" style="margin-bottom: 20px;" />
                    <input type="text" class="form-control" value="" placeholder="签名" id="txtSig" runat="server" style="margin-bottom: 20px;" />
                    <asp:Button ID="Button1" CssClass="btn btn-primary btn-lg btn-block" runat="server" Text="注册" OnClick="Button1_Click1" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
