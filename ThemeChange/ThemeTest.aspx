<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThemeTest.aspx.cs" Inherits="ThemeChange.ThemeTest" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<style>
    nav .input-sm, .btn-sm {
        height: 25px;
    }

    nav a {
        color: #333;
        font-size: 14px;
    }

    .navbar {
        min-height: 40px;
        margin: 0;
    }

    .href {
        padding-top: 3px;
        margin-left: -17px;
    }

    .container {
        width: 1180px;
    }

    .widthimg {
        width: 100%;
        height: auto;
    }

    .back {
        background-color: #24C5E2;
    }

    .headsearch {
        margin: 25px 0;
    }

    .btnsearch {
        /*width: 40px;*/
        text-align: center;
    }

    nav ul li {
        margin-left: 35px;
    }

    .bottomborder {
    }
    /*.panel-body li {
        list-style: none;
        border-bottom: 1px solid #e7e7e7;
        line-height: 27px;
        margin-left: -29px;
    }*/
    .panel .list-group-item {
        padding: 5px 15px;
        background: rgba(0, 0, 0, 0) url("Images/icon01.gif") no-repeat scroll left center;
        background-position: 20px;
        padding-left: 40px;
    }

    .container .col-lg-3 {
        padding: 0;
        margin: 0;
    }

    .bottommargin {
        /*大模块之间添加空隙*/
        margin-bottom: 5px;
    }
</style>
<body>
    <form id="form1" runat="server">
        <%--顶部菜单栏--%>
        <nav class="navbar navbar-default ">
            <div class="container">
                <div class="navbar-form navbar-left">
                    用户名    
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    密码
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control  input-sm"></asp:TextBox>
                    <asp:Button ID="btnLogin" runat="server" Text="登陆" CssClass="btn btn-success btn-sm" />
                </div>
                <div class=" navbar-form navbar-left href">
                    <a href="#">找回密码</a>  &nbsp;
                    <a href="#">用户注册</a>
                </div>
                <div class="navbar-form pull-right href">
                    <span class="glyphicon glyphicon-user" aria-hidden="true"></span>&nbsp;
                 <a href="#">用户中心</a>               &nbsp;
                <a href="#">在线咨询</a>             &nbsp;
                <a href="#">关于我们</a>             &nbsp;
                </div>
            </div>
        </nav>
        <%--图片--%>
        <div class="col-lg-12 back ">
            <div class="container-fluid">
                <img src="Images/header.png" class="widthimg" />
            </div>
        </div>
        <%--头部--%>
        <div class="col-lg-12 headsearch ">
            <div class="container">
                <div class="col-lg-2 ">
                    <img src="Images/logo.png" />
                </div>
                <div class="col-lg-6 col-lg-offset-1">
                    <%--     <div>
                        <ul class="nav navbar-nav">
                            <li class="active"><a>服务</a></li>
                            <li><a>需求</a></li>
                            <li><a>机构</a></li>                         </ul>
                    </div>--%>            
                    服务   需求  机构
                    <div class="input-group">
                        <asp:TextBox ID="TextSearch" class="form-control" runat="server" placeholder="搜索"></asp:TextBox>
                        <span class="input-group-btn">
                            <button type="submit" class=" btn btn-default btnsearch" runat="server">
                                &nbsp;&nbsp; 搜&nbsp; 索&nbsp;&nbsp;
                            </button>
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <%--导航栏--%>
        <div class="col-lg-12 bottommargin">
            <div class="container  ">
                <nav class="navbar navbar-default  ">
                    <ul class="nav navbar-nav  ">
                        <li class="active"><a href="#">首页<span class="sr-only">(current)</span></a></li>
                        <li><a href="#">政府服务</a></li>
                        <li><a href="#">科淘</a></li>
                        <li><a href="#">科技金融</a></li>
                        <li><a href="#">创新创业</a></li>
                        <li><a href="#">仪器设备</a></li>
                        <li><a href="#">科技信息</a></li>
                        <li><a href="#">新闻中心</a></li>
                        <li><a href="#">帮助中心</a></li>
                    </ul>
                </nav>
            </div>
        </div>
        <div class="col-lg-12 ">
            <div class=" container">
                <%--左侧插件--%>
                <div class="col-lg-3">
                    <div class=" panel  panel-default">
                        <div class="panel-heading"><span class="glyphicon glyphicon-star"></span>政府服务 <a class="pull-right">更多>></a></div>
                        <ul class="list-group ">
                            <li class="list-group-item "><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item"><a href="#">科技型中小企业认定</a></li>
                        </ul>
                    </div>
                </div>
                <%--轮播插件--%>
                <div class="col-lg-6">
                    <%--  TODO  点击下边的小圆球不能导航的问题 --%>
                    <div id="myCarousel" class="carousel slide" data-ride="carousel">
                        <ol class="carousel-indicators">
                            <li data-target="#myCarousel" data-silde-to="0" class="active"></li>
                            <li data-target="#myCarousel" data-silde-to="1"></li>
                            <li data-target="#myCarousel" data-silde-to="2"></li>
                        </ol>
                        <div class="carousel-inner">
                            <div class="item active">
                                <img src="Images/0.jpg" alt="科服网" class="widthimg" />
                            </div>
                            <div class="item ">
                                <img src="Images/1.jpg" alt="科服网" class="widthimg" />
                            </div>
                            <div class="item ">
                                <img src="Images/2.jpg" alt="科服网" class="widthimg" />
                            </div>
                        </div>
                        <a class="carousel-control left" href="#myCarousel"
                            data-slide="prev"><span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>;</a>
                        <a class="carousel-control right" href="#myCarousel"
                            data-slide="next"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                            <span class="sr-only">Next</span></a>
                    </div>

                </div>
            </div>
        </div>
    </form>
    <script src="App_Themes/Bootstrap/jquery-1.11.1.min.js"></script>
    <script src="App_Themes/Bootstrap/bootstrap.min.js"></script>
</body>
</html>
