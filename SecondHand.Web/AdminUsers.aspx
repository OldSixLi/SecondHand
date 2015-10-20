<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUsers.aspx.cs" Inherits="SecondHand.Web.AdminUsers" %> <!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>注册人员管理</title>
    <link href="style/bootstrap.css" rel="stylesheet" />
    <link href="style/admin.css" rel="stylesheet" />
    <link href="style/admingoods.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.11.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script>
        $(function () { $("[data-toggle='tooltip']").tooltip(); });
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
    <style type="text/css">
    </style>
</head>
<body>
    <%--侧边栏--%>
    <div class="col-sm-3 col-lg-2 sidebar" id="sidebar">
        <h3 class="text-center">网站管理员</h3>
        <ul class="nav ">
            <li class="divider"></li>
            <li><a href="AdminBack.aspx"><span class="glyphicon glyphicon-dashboard"></span>网站事项</a></li>
            <%--    <li class="disabled"><a href="#"><span class="glyphicon glyphicon-th"></span>物品管理</a></li>--%>
            <li class=""><a href="AdminUsers.aspx" style="background-color: #0000ff; color: white;"><span class="glyphicon glyphicon-stats"></span>用户管理</a></li>
            <li><a href="AdminGoods.aspx"><span class="glyphicon glyphicon-list-alt"></span>物品管理</a></li>
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
                    </li>                 </ul>
            </li>
            <li class="divider" role="presentation"></li>
            <li><a href="UserLogin.aspx"><span class="glyphicon glyphicon-user"></span>网站主页</a></li>
            <li><a id="managerexit" style="cursor: pointer" runat="server" onserverclick="btnExit_Click"><span class="glyphicon glyphicon-user"></span>退出登录</a></li>
        </ul>
    </div>
    <%--表--%>
    <form id="form1" runat="server">
        <div class="col-lg-offset-2 col-lg-10">
            <%--标题--%>
            <div class="row">
                <div class="col-lg-12">
                    <div class="page-header">
                        <h1>注册用户信息管理</h1>
                    </div>
                </div>
            </div>
            <%--表主体--%>
            <div class="row">
                <div class="col-lg-12 ">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            User Management
                        </div>
                        <div id="biao" class="panel-body">
                            <%--右边提示框--%>
                            <div class="fixed-table-toolbar">
                                <%--autopostback属性设置为true，才会返回服务器端--%>
                                <div class="pull-left search">
                                    当前每页显示<asp:DropDownList CssClass="ddl" ID="countDDL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="countDDL_SelectedIndexChanged">
                                        <asp:ListItem Selected="True"> 10</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>100</asp:ListItem>
                                    </asp:DropDownList>条记录
                                </div>
                                <div class="columns btn-group  pull-right">
                                    <a title="刷新" name="refresh" runat="server" onserverclick="btnF5_Click" class="btn btn-default"><i class="glyphicon glyphicon-refresh icon-refresh"></i></a>
                                </div>
                            </div>
                            <div class=" fixed-table-container">
                                <div class="fixed-table-header">
                                    <table></table>
                                </div>
                                <div class="fixed-table-body">
                                    <table class="table table-hover  ">
                                        <thead>
                                            <tr>
                                                <th class=" text-center goodsname">编号</th>
                                                <%-- <th class=".goodsid"  >GoodsID</th>--%>
                                                <th class="text-center username">用户名</th>
                                                <th class=" text-center email">邮箱</th>
                                                <th class="text-center usertype">用户类型</th>                                                 <th class="text-center phnum">手机号</th>
                                                <th class="text-center QQnum">QQ号</th>
                                                <%--           <th class="content text-center">证件号</th>--%>
                                                <th class="usericon text-center hidden">头像</th>
                                                <th class="text-center time">注册时间</th>
                                                <th class="text-center">操作</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="Repeaterusers" runat="server">
                                                <HeaderTemplate></HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center"><%#Eval("rowId") %></td>
                                                        <td class="text-center goodsname"><a href="#?wpad=<%#Eval("UserID") %>"><%#   Eval("UserName").ToString().Length>10?Eval("UserName").ToString().Substring(0,10)+"..":Eval("UserName").ToString()%></a>
                                                        </td>
                                                        <td class="text-center username"><%#Eval("LoginCode ") %></td>
                                                        <td class="text-center price"><%#Eval("UserType ") %></td>                                                         <td class="text-center phnum"><%#Eval(" PhoneNum") %></td>
                                                        <td class="text-center QQnum"><%#Eval("QQ ") %></td>
                                                        <%--  <td class="text-center content"><%#Eval("ContentNum ") %></td>--%>
                                                        <td class="text-center usericon hidden"><%#Eval("UserIcon ") %></td>
                                                        <td class="text-center time"><%#Eval(" RegTime") %></td>
                                                        <td class="text-center "><a class="no-padding" href="AdminEditUser.aspx?iiid=<%#Eval("UserID") %>" title="编辑"><span class="glyphicon glyphicon-pencil"></span></a>
                                                            <asp:LinkButton ID="LinkButtonDelete" title="删除" runat="server" CommandArgument='<%#Eval("UserID") %>'
                                                                OnCommand="Delete" OnClientClick='<%#  "if (!confirm(\"你确定要删除用户：" + Eval("UserName").ToString() + "  吗?\")) return false;"%>'>
                                                        <span class="glyphicon glyphicon-trash"></span>
                                                            </asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tr>
                                                        <td colspan="100" style="padding-bottom: 0">共有<b><%#Webpagerecord %> </b>条用户信息        
                                                                 <div class="pager pagination-sm pull-right" style="margin: 0">
                                                                     <nav>
                                                                         <ul class="pagination pagination-sm" style="margin-left: auto; margin-right: auto; padding: 0; margin: 0;">
                                                                             <li>
                                                                                 <asp:LinkButton ID="lnkUpPage" runat="server" Enabled="<%# Webpageindex>1%>" OnCommand="Goup"><span aria-hidden="true">&laquo;</span></asp:LinkButton>
                                                                             </li>
                                                                             <li>
                                                                                 <asp:LinkButton ID="pagejian2" runat="server" Text='<%# Webpageindex -2%>' Visible='<%# Webpageindex -2 > 0%>'
                                                                                     OnCommand="GOjian2"></asp:LinkButton>
                                                                             </li>
                                                                             <li>
                                                                                 <asp:LinkButton ID="pagejian1" runat="server" Text='<%# Webpageindex -1%>' Visible='<%# Webpageindex -1 > 0%>'
                                                                                     OnCommand="GOjian1"></asp:LinkButton>
                                                                             </li>
                                                                             <li class=" active"><a href="#"><%# Webpageindex%></a>
                                                                                 <li>
                                                                                     <asp:LinkButton ID="lnkjia1" runat="server" Text='<%# Webpageindex +1%>' Visible='<%# Webpageindex +1 <=WebPageCount%>'
                                                                                         OnCommand="GOjia1"></asp:LinkButton>
                                                                                 </li>
                                                                                 <li>
                                                                                     <asp:LinkButton ID="lnkjia2" runat="server" Text='<%# Webpageindex+2%>' Visible='<%# Webpageindex +2<=WebPageCount%>'
                                                                                         OnCommand="GOjia2"></asp:LinkButton>
                                                                                 </li>
                                                                                 <li>
                                                                                     <asp:LinkButton ID="lnkNextPage" runat="server" Enabled="<%# WebPageCount-Webpageindex>0%>"
                                                                                         OnCommand="Gonp"><span aria-hidden="true">&raquo;</span></asp:LinkButton>
                                                                                 </li>
                                                                         </ul>
                                                                     </nav>
                                                                 </div>
                                                        </td>
                                                    </tr>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer"></div>
                    </div>
                </div>
            </div>
            <%-- <div class="row">
                <div class="col-lg-12">
                    <div class="panel">
                        待添加
                    </div>
                </div>
            </div>--%>
        </div>
        <div>
        </div>
    </form>
</body>
</html>
