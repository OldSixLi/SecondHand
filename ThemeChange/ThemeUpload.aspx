<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThemeUpload.aspx.cs" Inherits="ThemeChange.ThemeUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%--<link href="App_Themes/Admin/admin.css" rel="stylesheet" />--%>
    <%--<link href="App_Themes/Bootstrap/bootstrap.css" rel="stylesheet" />--%>
    <link id="css1" type="text/css" rel="stylesheet" />

    <script src="http://localhost:45372/Scripts/jquery-1.11.1.min.js"></script>
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-6">

            <h2>上传样式文件</h2>
            <div class="well">
                <div class="form-group form-horizontal">

                    <label for="fileAttachment">请上传样式文件： </label>
                    <asp:FileUpload ID="fileAttachment" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group form-horizontal">
                    <label for="ShowItemName">请输入主题名称 ：   </label>
                    <asp:TextBox ID="ShowItemName" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:Button CssClass="btn  btn-success pull-right" ID="Button1" runat="server" Text="上传" OnClick="Button1_Click" />
                </div>
                <br />
            </div>
        </div>

        <div class="col-lg-6">
            <h2>更换主题</h2>
            <div class="well">

                <div class="col-lg-12">
                    <div class="col-lg-6 form-group ">
                        <asp:DropDownList ID="dropTheme" runat="server" CssClass="form-control">
                        </asp:DropDownList>


                    </div>
                </div>

                <div class="col-lg-12  ">
                    <div class=" col-lg-6 form-group">
                        <asp:Button ID="btnChange" runat="server" Text="选取主题" class="btn btn-primary " OnClick="btnChange_Click" />
                        <asp:Button ID="Button2" runat="server" Text="查看主题" class="btn btn-primary" OnClick="Button2_Click" />


                    </div>
                </div>
                <p><b>选取样式后请点击查看按钮查看效果</b></p>
            </div>
        </div>

        <% = HerfTheme %>
        <div class="col-lg-12"><a href="ThemeTest.aspx" class="btn btn-success pull-right">主页入口→</a></div>
    </form>
</body>
</html>
