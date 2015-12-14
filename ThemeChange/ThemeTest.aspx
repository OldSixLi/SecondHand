<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThemeTest.aspx.cs" Inherits="ThemeChange.ThemeTest" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>科服网首页</title>
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
        width: 1080px;
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
    .panel .sanjiao {
        list-style: none;
        padding: 5px 15px;
        background: rgba(0, 0, 0, 0) url("Images/icon01.gif") no-repeat scroll left center;
        background-position: 20px;
        padding-left: 40px;
        margin: -right: 20px;
    }

    .container .col-lg-3 {
        /*设置边上的col-3边缘为0*/
        padding: 0;
        margin: 0;
    }

    .bottommargin {
        /*大模块之间添加空隙*/
        margin-bottom: 5px;
    }

    .carousel-control.right {
        background-image: linear-gradient(to right, rgba(0, 0, 0, 0) 0px, rgba(0, 0, 0, 0.0) 100%);
        background-repeat: repeat-x;
        left: auto;
        right: 0;
    }

    .nopadding {
        padding-left: 0;
    }

    .panel .media {
        margin-top: 5px;
    }

    a:focus {
        outline: none;
    }

    .tab-content li {
        line-height: 28px;
        list-style: none;
        margin-left: -18px;
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
        <%--<div class="col-lg-12 back ">
            <div class="container-fluid">
                <img src="Images/header.png" class="widthimg" />
            </div>
        </div>--%>
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
                            <li><a>机构</a></li>
                         </ul>
                    </div>--%>
                    <%--     服务   需求  机构--%>
                    <div class="input-group">
                        <asp:TextBox ID="TextSearch" class="form-control" runat="server" placeholder="搜索"></asp:TextBox>
                        <span class="input-group-btn">
                            <button type="submit" class=" btn btn-default btnsearch" runat="server">
                                &nbsp;&nbsp; 搜&nbsp; 索&nbsp;&nbsp;
                            </button>
                        </span>
                    </div>

                </div>

                <div class="col-lg-3">
                    <div class="btn-group btn-group-lg pull-right">
                        <input class="btn btn-default btn-lg " type="button" value="免费发需求" />
                        <input class="btn btn-default btn-lg pull-right" type="button" value="免费发服务" />
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
        <%--内容--%>
        <div class="col-lg-12 ">
            <div class=" container">
                <%--左侧插件--%>
                <div class="col-lg-3 bottommargin">
                    <div class=" panel  panel-default bottommargin">
                        <div class="panel-heading"><span class="glyphicon glyphicon-star">&nbsp;</span>政府服务 <a class="pull-right">更多>></a></div>
                        <ul class="list-group ">
                            <li class="list-group-item  sanjiao "><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">科技型中小企业认定</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">科技型中小企业认定</a></li>


                        </ul>
                    </div>
                </div>
                <%--轮播插件--%>
                <div class="col-lg-6">
                    <%--  TODO  点击下边的小圆球不能导航的问题 --%>

                    <div id="myCarousel" class="carousel slide bottommargin" data-ride="carousel">
                        <ol class="carousel-indicators">
                            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                            <li data-target="#myCarousel" data-slide-to="1"></li>
                            <li data-target="#myCarousel" data-slide-to="2"></li>
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
                            <span class="sr-only">Previous</span></a>
                        <a class="carousel-control right" href="#myCarousel"
                            data-slide="next"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                            <span class="sr-only">Next</span></a>
                    </div>

                    <img src="Images/2013process.jpg" class="img-rounded widthimg bottommargin img-thumbnail" style="margin-top: 14px;" />
                </div>
                <div class="col-lg-3  bottommargin">
                    <div style="height: 50px;" class="bottommargin ">
                        <img src="http://www.tten.cn/trs/images/weibo.png" class="img widthimg img-thumbnail" />
                        <div style="padding-bottom: 0px; padding-left: 149px; padding-right: 0px; height: 35px; margin-top: -38px;">
                            <a target="_blank" href="http://widget.weibo.com/dialog/follow.php?fuid=3516630045&amp;refer=www.tten.cn&amp;language=zh_cn&amp;type=widget_page&amp;vsrc=app_followbutton&amp;backurl=http%3A%2F%2Fwww.tten.cn%2Ftrs%2Fiframeindex.html&amp;rnd=1385975666644">
                                <img width="63" height="23" src="http://www.tten.cn/trs/images/weibo1.jpg">
                            </a>
                        </div>
                    </div>
                    <div class=" panel  panel-default bottommargin" style="margin-top: 14px;">
                        <div class="panel-heading">
                            <span class="glyphicon glyphicon-star">&nbsp;</span>
                            新手上路 <a class="pull-right">更多>></a>

                        </div>
                        <ul class="list-group">
                            <li class="list-group-item  sanjiao"><a href="#">如何申报科企认定及年检？</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">如何发布服务产品？</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">科服网法律声明</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">如何在科服网上申请服务产品？</a></li>
                        </ul>
                    </div>
                    <div class=" panel  panel-default bottommargin" style="margin-top: 13px;">
                        <div class="panel-heading">
                            <span class="glyphicon glyphicon-star">&nbsp;</span>
                            创新企业 <a class="pull-right">详细>></a>

                        </div>
                        <div class="  media">
                            <div class="media-heading col-lg-6">
                                <img src="Images/chuang.jpg" class="img  widthimg img-thumbnail" />
                            </div>
                            <div class="media-body">

                                <li class="  sanjiao "><a href="#">政策聚焦</a></li>
                                <li class=" sanjiao "><a href="#">众创空间</a></li>
                                <li class="sanjiao "><a href="#">创业视频</a></li>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>


        <div class="col-lg-12">
            <div class="container">
                <div class="col-lg-3">
                    <div class="panel panel-default bottommargin">
                        <div class="panel-heading">
                            <span class="glyphicon glyphicon-star">&nbsp;</span>
                            统计监测 
                        </div>
                        <ul class="list-group">
                            <li class="list-group-item  sanjiao"><a href="#">科技型中小企业认定状态查询</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">全市累计认定 71285 家</a></li>
                            <li class="list-group-item  sanjiao"><a href="#">小巨人企业 3406 家</a></li>

                        </ul>
                    </div>
                    <div class="panel panel-default bottommargin">
                        <div class="panel-heading">
                            <span class="glyphicon glyphicon-star">&nbsp;</span>
                            主题导航
                        </div>
                        <div class="panel-body">
                            <div class="col-lg-12">
                                <input type="button" class="btn  btn-primary btn-lg bottommargin" value="种子期" />
                                <input type="button" class="btn  btn-primary  btn-lg pull-right bottommargin " value="初创期" />

                                <input type="button" class="btn  btn-primary  btn-lg" value="成长期" />
                                <input type="button" class="btn  btn-primary  btn-lg pull-right" value="壮大期" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class=" panel panel-default">
                        <div class="panel-heading">
                            <ul class="nav nav-tabs " id="tabs">
                                <li role="presentation" class="active"><a href="#tab1" data-toggle="tab">工作动态</a></li>

                                <li role="presentation"><a href="#tab2" data-toggle="tab">通知公告</a></li>
                                <li role="presentation"><a href="#tab3" data-toggle="tab">工作简报</a></li>
                            </ul>

                        </div>
                        <div class="panel-body">
                            <div class=" tab-content">
                                <div class="tab-pane active " id="tab1">


                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                </div>
                                <div class="tab-pane  " id="tab2">
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                </div>
                                <div class="tab-pane  " id="tab3">
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                    <li><a href="#" class=" sanjiao">中国能源建设集团在河东建电力产业园</a><span class="pull-right">2015-10-06</span></li>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
    <script src="App_Themes/Bootstrap/jquery-1.11.1.min.js"></script>
    <script src="App_Themes/Bootstrap/bootstrap.min.js"></script>
</body>
</html>
