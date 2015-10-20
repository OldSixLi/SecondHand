<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEditUser.aspx.cs" Inherits="SecondHand.Web.AdminEditUser" %> <!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑用户资料</title>
    <link href="style/bootstrap.css" rel="stylesheet" />
    <link href="style/admin.css" rel="stylesheet" />
    <link href="style/admingoods.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.11.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#btnDelete").click(function () {
                var a = confirm("确认删除此用户吗？");
                if (!a) {
                    return false;
                }
            });
        });
        $(document).ready(function () { 
        $("#managerexit").click(function () {
            var a = confirm("确认退出系统吗？");
            if (a) {
                return true;
            } else {
                return false;
            }
        });
        });
    </script>
</head>
<body>
    <div class="col-sm-3 col-lg-2 sidebar" id="sidebar">
        <%--  <form role="search">
            <div class="form-group">
                <input type="text" placeholder="Search" class="form-control">
            </div>
        </form>--%>
        <h3 class="text-center">网站管理员</h3>
        <ul class="nav ">
            <li class="divider"></li>
            <li><a href="AdminBack.aspx"><span class="glyphicon glyphicon-dashboard"></span>网站事项</a></li>
            <%-- <li class="disabled"><a href="#"><span class="glyphicon glyphicon-th"></span>公告管理</a></li>--%>
            <li class=""><a href="AdminUsers.aspx" style="background-color: #0000ff; color: white;"><span class="glyphicon glyphicon-stats"></span>用户管理</a></li>
            <li><a href="AdminGoods.aspx"><span class="glyphicon glyphicon-list-alt"></span>物品管理</a></li>
            <%--   <li class="disabled"><a href="#"><span class="glyphicon glyphicon-pencil"></span>编辑邮箱</a></li>
            <li class="disabled"><a href="#" class="disabled"><span class="glyphicon glyphicon-info-sign"></span>网站提醒</a></li>--%>
                 <li class="parent ">
                <a href="#sub-item-1" data-toggle="collapse" aria-expanded="false" aria-controls="sub-item-1">
                    <span class="glyphicon glyphicon-list"></span>网站声明 <span class="icon pull-right" href="#sub-item-1" data-toggle="collapse"><em class="glyphicon glyphicon-s glyphicon-plus"></em></span>
                </a>
                <ul id="sub-item-1" class="childrenul collapse" style="background-color: #f9f9f9;">
                    <li>
                        <a href="WZNotice/RegistNotice.html" class="">
                            <span class="glyphicon glyphicon-share-alt"></span>用户注册
                        </a>
                    </li>
                    <li>
                        <a href="WZNotice/GoodsNotice.html" class="">
                            <span class="glyphicon glyphicon-share-alt"></span>物品发布
                        </a>
                    </li>
                    <%--  <li>
                        <a href="#" class="">
                            <span class="glyphicon glyphicon-share-alt"></span>Sub Item 3
                        </a>
                    </li>--%>
                </ul>
            </li>
            <li class="divider" role="presentation"></li>
            <li><a href="UserLogin.aspx"><span class="glyphicon glyphicon-user"></span>网站主页</a></li>
            <li><a  id="managerexit" style="cursor: pointer" runat="server" onserverclick="btnExit_Click"><span class="glyphicon glyphicon-user"></span>退出登录</a></li>
        </ul>
    </div>
    <form id="form1" runat="server">
        <div class="col-lg-offset-2 col-lg-10">
            <div class="row">
                <div class="col-lg-12">
                    <div class="page-header">
                        <h1>编辑用户信息</h1>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 ">
                    <div class=" well">
                        <ul class="nav nav-tabs">
                            <li role="presentation" class="active"><a href="#tab1" data-toggle="tab">个人信息</a></li>
                            <li role="presentation"><a href="#tab2" data-toggle="tab">修改密码</a></li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane  active" style="margin-top: 20px;" id="tab1">
                                <label class="col-lg-1 control-label text-right" style="margin-top: 5px;">用户名</label>
                                <div class="col-lg-3">
                                    <%--    <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>--%>
                                    <asp:TextBox class="form-control" ID="TextBoxu" runat="server"></asp:TextBox>
                                </div>
                                <br />
                                <br />
                                <label class="col-lg-1 control-label text-right" style="margin-top: 5px;">邮箱</label>
                                <div class="col-lg-3">
                                    <%--    <asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>--%>
                                    <asp:TextBox class="form-control" ID="TextBoxe" runat="server"></asp:TextBox>
                                </div>
                                <br />
                                <br />
                                <label class="col-lg-1 control-label text-right" style="margin-top: 5px;">手机号</label>
                                <div class="col-lg-3">
                                    <%--     <asp:TextBox ID="txtphonenum" runat="server" class="form-control"></asp:TextBox>--%>
                                    <asp:TextBox class="form-control" ID="TextBoxp" runat="server"></asp:TextBox>
                                </div>
                                <br />
                                <br />
                                <label class="col-lg-1 control-label text-right" style="margin-top: 5px;">QQ号</label>
                                <div class="col-lg-3">
                                    <%--   <asp:TextBox ID="txtQQnum" runat="server" class="form-control"></asp:TextBox>--%>
                                    <asp:TextBox class="form-control" ID="TextBoxQ" runat="server"></asp:TextBox>
                                </div>
                                <br />
                                <br />
                                <%--            <label class="col-lg-1 control-label text-right" style="margin-top: 5px;">证件号</label>--%>
                                <div class="col-lg-3">
                                    <%--  <asp:TextBox ID="txtcontentnum" runat="server" class="form-control"></asp:TextBox>--%>
                                    <asp:TextBox class="form-control hidden" ID="TextBoxc" runat="server"></asp:TextBox>
                                </div>
                                <br />
                                <br />
                                <div class="col-lg-3 col-lg-offset-1">
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                    <asp:Label ID="Label1" runat="server" Text="设为管理员"></asp:Label>
                                </div>
                                <br />
                                <br />
                                <div class="col-lg-3 col-lg-offset-1">
                                    <asp:Button ID="btnDelete" CssClass="btn btn-danger" runat="server" Text="删除" OnClick="btnDelete_Click" />
                                    <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" Text="修改" OnClick="btnEdit_Click" />
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                            <div class="tab-pane " id="tab2" style="margin-top: 20px;">
                                <label class="col-lg-1 control-label" style="margin-top: 5px;">新密码</label>
                                <div class="col-lg-3">
                                    <asp:TextBox ID="newPassWord" runat="server" class="form-control" placeholder=" "></asp:TextBox>
                                </div>
                                <br />
                                <br />
                                <br />
                                <div class="col-lg-3 col-lg-offset-1">
                                    <asp:Button ID="btnPassChange" runat="server" CssClass="btn btn-primary" Text="修改密码" OnClick="btnPassChange_Click" />
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
