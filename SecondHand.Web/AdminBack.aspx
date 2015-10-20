<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminBack.aspx.cs" Inherits="SecondHand.Web.AdminBack" %> <!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>网站管理员后台</title>
    <link href="style/bootstrap.css" rel="stylesheet" />
    <link href="style/admin.css" rel="stylesheet" />
    <%-- <link href="style/styles-mu.css" rel="stylesheet" />
    <link href="style/datepicker3.css" rel="stylesheet" />--%>
    <script src="Scripts/jquery-1.11.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
   <script>
       $(document).ready(function() {  
           $("#managerexit").click(function() {
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
        <ul class="nav menu">
            <li class="divider"></li>
            <li class="" style="background-color: #0000ff;"><a href="#" style="color: white"><span class="glyphicon glyphicon-dashboard"></span>网站事项</a></li>
            <%--  <li><a href="#"><span class="glyphicon glyphicon-th"></span>公告管理</a></li>--%>
            <li><a href="AdminUsers.aspx"><span class="glyphicon glyphicon-stats"></span>用户管理</a></li>
            <li><a href="AdminGoods.aspx"><span class="glyphicon glyphicon-list-alt"></span>物品管理</a></li>
            <%--  <li><a href="#"><span class="glyphicon glyphicon-pencil"></span>编辑邮箱</a></li>
            <li><a href="#"><span class="glyphicon glyphicon-info-sign"></span>网站提醒</a></li>--%>
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
    <div class="col-lg-offset-2 col-lg-10">
        <div class="row">
            <div class="col-lg-12">
                <div class="page-header">
                    <h1>Administrator</h1>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-md-6 col-lg-3">
                <div class="panel panel-teal panel-widget">
                    <div class="row no-padding">
                        <div class="col-sm-3 col-lg-5 widget-left">
                            <em class="glyphicon glyphicon-user glyphicon-l"></em>
                        </div>
                        <div class="col-sm-9 col-lg-7 widget-right">
                            <div class="large">
                                <a href="AdminUsers.aspx">
                                    <asp:Label ID="lblUserCount" runat="server" Text="Label"></asp:Label></a>
                            </div>
                            <div class="text-muted">Members</div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-md-6 col-lg-3">
                <div class="panel panel-blue panel-widget ">
                    <div class="row no-padding">
                        <div class="col-sm-3 col-lg-5 widget-left">
                            <em class="glyphicon glyphicon-shopping-cart glyphicon-l"></em>
                        </div>
                        <div class="col-sm-9 col-lg-7 widget-right">
                            <div class="large">
                                <a href="AdminGoods.aspx">
                                    <asp:Label ID="lblGoodsCount" runat="server" Text="Label"></asp:Label></a>
                            </div>
                            <div class="text-muted">Goods</div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-md-6 col-lg-3">
                <div class="panel panel-orange panel-widget">
                    <div class="row no-padding">
                        <div class="col-sm-3 col-lg-5 widget-left">
                            <em class="glyphicon glyphicon-comment glyphicon-l"></em>
                        </div>
                        <div class="col-sm-9 col-lg-7 widget-right">
                            <div class="large">
                                <asp:Label ID="lblCommentCount" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div class="text-muted">Comments</div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-md-6 col-lg-3">
                <div class="panel panel-red panel-widget">
                    <div class="row no-padding">
                        <div class="col-sm-3 col-lg-5 widget-left">
                            <em class="glyphicon glyphicon-stats glyphicon-l"></em>
                        </div>
                        <div class="col-sm-9 col-lg-7 widget-right">
                            <div class="large">25.2k</div>
                            <div class="text-muted">Visitors</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel">
                    选择
                </div>
            </div>
        </div>
    </div>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
