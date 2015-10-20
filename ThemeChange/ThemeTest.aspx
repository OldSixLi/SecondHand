<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThemeTest.aspx.cs" Inherits="ThemeChange.ThemeTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <nav class="navbar navbar-default ">
            <div class="container-fluid">
                <div class="navbar-left">
                    <div class="form-group">
                        用户名    
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        密码
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Button ID="btnLogin" runat="server" Text="登陆" CssClass="btn btn-success" />
                        <div></div>
                    </div>
                </div>
            </div>
        </nav>
        <div class="jumbotron">
            <h1>测试主题页面

            </h1>
        </div>


    </form>
</body>
</html>
