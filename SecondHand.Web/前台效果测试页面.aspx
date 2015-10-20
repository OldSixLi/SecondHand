<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="前台效果测试页面.aspx.cs" Inherits="SecondHand.Web.前台效果测试页面" %>
 <!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>前台效果测试页面</title>
    <link href="style/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.11.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/highlight.js"></script>
    <script src="Scripts/bootstrap-switch.min.js"></script>
    <%--<script src="Scripts/main.js"></script>--%>
    <style>
        a {
            color: #008b8b;
        }
         .pp {
            margin: 5px 2px;
        }
         .spanleft {
            margin-left: -6px;
        }
         .thumbnail .caption {
            color: #333;
            padding: 0px;
        }
         .glyphicon-yen {
            font-size: 17px;
        }
         .label {
            padding: 0 0.2em 0.2em;
        }
    </style>     
    <script>
        function aclick() {
            window.location.href = "Images/1.xlsx" ;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="hidden">
            <div class="col-lg-3 col-md-4 col-sm-6">
                <div class="thumbnail">
                    <a>
                        <img src="http://placehold.it/300x300" /></a><span style="float: right" class="label label-danger glyphicon glyphicon-yen"><asp:Label
                            ID="Label10" runat="server" Text="1500"></asp:Label>
                        </span><span>
                            <asp:Label ID="Label11" runat="server" Text="用户名"></asp:Label></span>
                    <div class="caption">
                        <p class="pp">
                            <a href="#" style="outline: none; text-decoration: none">
                                <asp:Label ID="Label12" runat="server" Text="商品名称"></asp:Label></a>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6">
                <div class="thumbnail">
                    <a>
                        <img src="http://placehold.it/300x300" /></a><span style="float: right" class="label label-danger glyphicon glyphicon-yen"><asp:Label
                            ID="Label13" runat="server" Text="1500"></asp:Label>
                        </span><span>
                            <asp:Label ID="Label14" runat="server" Text="用户名"></asp:Label></span>
                    <div class="caption">
                        <p class="pp">
                            <a href="#" style="outline: none; text-decoration: none">
                                <asp:Label ID="Label15" runat="server" Text="商品名称"></asp:Label></a>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6">
                <div class="thumbnail">
                    <a>
                        <img src="http://placehold.it/300x300" /></a><span style="float: right" class="label label-danger glyphicon glyphicon-yen"><asp:Label
                            ID="Label16" runat="server" Text="1500"></asp:Label>
                        </span><span>
                            <asp:Label ID="Label17" runat="server" Text="用户名"></asp:Label></span>
                    <div class="caption">
                        <p class="pp">
                            <a href="#" style="outline: none; text-decoration: none">
                                <asp:Label ID="Label18" runat="server" Text="商品名称"></asp:Label></a>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6">
                <div class="thumbnail">
                    <a>
                        <img src="http://placehold.it/300x300" /></a><span style="float: right" class="label label-danger glyphicon glyphicon-yen"><asp:Label
                            ID="Label19" runat="server" Text="1500"></asp:Label>
                        </span><span>
                            <asp:Label ID="Label20" runat="server" Text="用户名"></asp:Label></span>
                    <div class="caption">
                        <p class="pp">
                            <a href="#" style="outline: none; text-decoration: none">
                                <asp:Label ID="Label21" runat="server" Text="商品名称"></asp:Label></a>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6">
                <div class="thumbnail">
                    <a>
                        <img src="http://placehold.it/300x300" /></a><span style="float: right" class="label label-danger glyphicon glyphicon-yen"><asp:Label
                            ID="Label22" runat="server" Text="1500"></asp:Label>
                        </span><span>
                            <asp:Label ID="Label23" runat="server" Text="用户名"></asp:Label></span>
                    <div class="caption">
                        <p class="pp">
                            <a href="#" style="outline: none; text-decoration: none">
                                <asp:Label ID="Label24" runat="server" Text="商品名称"></asp:Label></a>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6">
                <div class="thumbnail">
                    <a>
                        <img src="http://placehold.it/300x300" /></a><span style="float: right" class="label label-danger glyphicon glyphicon-yen"><asp:Label
                            ID="Label25" runat="server" Text="1500"></asp:Label>
                        </span><span>
                            <asp:Label ID="Label26" runat="server" Text="用户名"></asp:Label></span>
                    <div class="caption">
                        <p class="pp">
                            <a href="#" style="outline: none; text-decoration: none">
                                <asp:Label ID="Label27" runat="server" Text="商品名称"></asp:Label></a>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6">
                <div class="thumbnail">
                    <a>
                        <img src="http://placehold.it/300x300" /></a><span style="float: right" class="label label-danger glyphicon glyphicon-yen"><asp:Label
                            ID="Label28" runat="server" Text="1500"></asp:Label>
                        </span><span>
                            <asp:Label ID="Label29" runat="server" Text="用户名"></asp:Label></span>
                    <div class="caption">
                        <p class="pp">
                            <a href="#" style="outline: none; text-decoration: none">
                                <asp:Label ID="Label30" runat="server" Text="商品名称"></asp:Label></a>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6">
                <div class="thumbnail">
                    <a>
                        <img src="http://placehold.it/300x300" /></a><span style="float: right" class="label label-danger glyphicon glyphicon-yen"><asp:Label
                            ID="Label31" runat="server" Text="1500"></asp:Label>
                        </span><span>
                            <asp:Label ID="Label32" runat="server" Text="用户名"></asp:Label></span>
                    <div class="caption">
                        <p class="pp">
                            <a href="#" style="outline: none; text-decoration: none">
                                <asp:Label ID="Label33" runat="server" Text="商品名称"></asp:Label></a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class=" col-lg-12 jumbotron ">
            <div class="col-lg-10 col-lg-offset-1">
                <h1>Test</h1>
                <a class="btn btn-danger">测试按钮</a>  
                 <a id="link"onclick="saveImage.document.execCommand('saveAs');">sdfsdfs</a>         
                 <%--<a id="photo" onclick="aclick()" >图片</a>--%>
                 <iframe  height="0" width="0" src="Images/1.xlsx" name="saveImage" id="saveImage"></iframe> 
<a href="###" onclick="saveImage.document.execCommand('saveAs');">Click Me</a> 
            </div>
        </div>
        <div class="col-lg-10 col-lg-offset-1 hidden">
            <div class="container well">
                <asp:FileUpload ID="FileUpload1" runat="server" /><%--DataSourceID="SqlDataSource1"--%>
            </div>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th class="text-center" colspan="3" style="border-bottom: none;">AllGoods表
                        </th>
                    </tr>
                    <tr>
                        <th style="border-bottom: none">标题</th>
                        <th style="border-bottom: none">发布者</th>
                        <th style="border-bottom: none">时间</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate></HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="col-lg-4"><a href="IntroduceGoods.aspx?wpad=<%#Eval("GoodsID") %>"><%#Eval("GoodsName") %></a>
                                </td>
                                <td class="col-lg-4"><%#Eval("UserName") %></td>
                                <td class="col-lg-4"><%#Eval("PublishTime") %></td>
                            </tr>
                            <%-- <%#Eval("GoodsName") %>、<%#Eval("UserName") %>、<%#Eval("PublishTime") %><br/>--%>
                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <%--暂时注释前台数据源，利用后台传入数据--%>
            <%--          <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                ConnectionString="<%$ ConnectionStrings:SecondHandConnectionString %>"
                SelectCommand="SELECT [UserName], [GoodsName], [PublishTime], [UserID], [GoodsID] FROM [AllGoods]">
            </asp:SqlDataSource>--%>
            <asp:Repeater ID="thumbnaiL" runat="server">
                <HeaderTemplate></HeaderTemplate>
                <ItemTemplate>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <div class="thumbnail">
                            <a href="IntroduceGoods.aspx?wpad=<%#Eval("GoodsID") %>">
                                <img src="http://placehold.it/300x300" /></a><span style="float: right; font-size: 15px;"
                                    class="label label-danger glyphicon glyphicon-yen"><asp:Label
                                        ID="lblprice" runat="server" Text="">3000</asp:Label>
                                </span><span>
                                    <asp:Label ID="lblusername" runat="server" Text=""><%#Eval("UserName") %></asp:Label></span>
                            <div class="caption">
                                <p class="pp">
                                    <a href="IntroduceGoods.aspx?wpad=<%#Eval("GoodsID") %>" style="outline: none; text-decoration: none">
                                        <asp:Label ID="lbltitle" runat="server" Text=""><%#Eval("GoodsName") %></asp:Label></a>
                                </p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate></FooterTemplate>
            </asp:Repeater>
            <table class="table table-bordered">
                <tr>
                    <td>3</td>
                    <td>33</td>
                    <td>333</td>
                </tr>
                <tr>
                    <td>3</td>
                    <td>33</td>
                    <td>333</td>
                </tr>
                <tr>
                    <td>3</td>
                    <td>33</td>
                    <td>333</td>
                </tr>
            </table>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <button onclick="check()">UI噢撒旦</button>
            <script>
                function check() {
                    var a = $("#TextBox1").val();
                    isCardNo(a);
                }
                function isCardNo(card) {
                    // 身份证号码为15位或者18位，15位时全为数字，18位前17位为数字，最后一位是校验位，可能为数字或字符X  
                    var reg = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;
                    if (reg.test(card) === false) {
                        alert("身份证输入不合法");
                        return false;
                    }
                }
            </script>
        </div>
        <div class="col-lg-12">
            <div class="col-lg-10 col-lg-offset-1">
                <ul class="media-list">
                    <li class="media">
                        <div class="media-left" style="height: 170px; width: 170px; overflow: hidden">
                            <a href="#">
                                <img style="height: 100%; width: auto;" class="media-object" src="http://placehold.it/300x300" alt="商品图片">
                            </a>
                        </div>
                        <div class="media-body">
                            <h4 class="media-heading">新款耳机</h4>
                            <p>
                                新款耳机新款耳机新款耳机新款耳机新款耳机新款耳机新款耳机新款耳机新款耳机新款耳机新款耳机新款耳机新款耳机新款耳机新款耳机新款耳机新款
                           耳机新款耳机新款耳机新款耳机新款耳机新款耳机新款耳机
                            </p>
                            <div class="pull-left" style="width: 80%;">
                                <p class="col-lg-3">价格:1000yuan</p>
                                <p class="col-lg-3">用户：小米</p>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
        <%--侧边栏--%>
        <div class="panel-group col-lg-1" id="accordion" style="padding: 0; float: left; position: absolute; top: 260px; left: 0;" role="tablist" aria-multiselectable="true">
            <div class="panel panel-default">
                <div class="panel-heading" role="tab" id="headingOne">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">校园代步
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                    <div class="panel-body">
                        <a href="GoodsByClass.aspx?classid=100">电动车</a>
                        <a href="GoodsByClass.aspx?classid=101">自行车</a>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading" role="tab" id="heading2">
                    <h4 class="panel-title">
                        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse2" aria-expanded="false" aria-controls="collapse2">手机
                        </a>
                    </h4>
                </div>
                <div id="collapse2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading2">
                    <div class="panel-body">
                        <a href="GoodsByClass.aspx?classid=2">手机</a>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading" role="tab" id="headingThree">
                    <h4 class="panel-title">
                        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">电脑
                        </a>
                    </h4>
                </div>
                <div id="collapseThree" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                    <div class="panel-body">
                        <a href="GoodsByClass.aspx?classid=102">笔记本</a>
                        <a href="GoodsByClass.aspx?classid=103">台式机</a>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading" role="tab" id="headingfive">
                    <h4 class="panel-title">
                        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapsefive" aria-expanded="false" aria-controls="collapsefive">数码
                        </a>
                    </h4>
                </div>
                <div id="collapsefive" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingfive">
                    <div class="panel-body">
                        <a href="GoodsByClass.aspx?classid=113">数码配件</a>
                        <a href="GoodsByClass.aspx?classid=114">相机</a>
                        <a href="GoodsByClass.aspx?classid=115">单反</a>
                        <a href="GoodsByClass.aspx?classid=117">游戏机</a>
                        <a href="GoodsByClass.aspx?classid=155">平板</a>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading" role="tab" id="heading6">
                    <h4 class="panel-title">
                        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse6" aria-expanded="false" aria-controls="collapse6">电器
                        </a>
                    </h4>
                </div>
                <div id="collapse6" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading6">
                    <div class="panel-body">
                        <a href="GoodsByClass.aspx?classid=119">电扇</a>
                        <a href="GoodsByClass.aspx?classid=120">台灯</a>
                        <a href="GoodsByClass.aspx?classid=121">洗衣机</a>
                        <a href="GoodsByClass.aspx?classid=122">电吹风</a>
                        <a href="GoodsByClass.aspx?classid=123">电水壶</a>
                        <a href="GoodsByClass.aspx?classid=126">其他</a>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading" role="tab" id="heading7">
                    <h4 class="panel-title">
                        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse7" aria-expanded="false" aria-controls="collapse7">运动健身
                        </a>
                    </h4>
                </div>
                <div id="collapse7" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                    <div class="panel-body">
                        <a href="GoodsByClass.aspx?classid=127">篮球</a>
                        <a href="GoodsByClass.aspx?classid=128">足球</a>
                        <a href="GoodsByClass.aspx?classid=129">球拍</a>
                        <a href="GoodsByClass.aspx?classid=130">哑铃</a>
                        <a href="GoodsByClass.aspx?classid=131">轮滑</a>
                        <a href="GoodsByClass.aspx?classid=132">其他</a>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading" role="tab" id="heading8">
                    <h4 class="panel-title">
                        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse8" aria-expanded="false" aria-controls="collapse8">衣物伞帽
                        </a>
                    </h4>
                </div>
                <div id="collapse8" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading8">
                    <div class="panel-body">
                        <a href="GoodsByClass.aspx?classid=133">衣服</a>
                        <a href="GoodsByClass.aspx?classid=135">背包</a>
                        <a href="GoodsByClass.aspx?classid=136">雨伞</a>
                        <a href="GoodsByClass.aspx?classid=137">鞋</a>
                        <a href="GoodsByClass.aspx?classid=138">帽子</a>
                        <a href="GoodsByClass.aspx?classid=139">其他</a>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading" role="tab" id="heading9">
                    <h4 class="panel-title">
                        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse9" aria-expanded="false" aria-controls="collapse9">图书教材
                        </a>
                    </h4>
                </div>
                <div id="collapse9" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading9">
                    <div class="panel-body">
                        <a href="GoodsByClass.aspx?classid=140">教材</a>
                        <a href="GoodsByClass.aspx?classid=141">考研</a>
                        <a href="GoodsByClass.aspx?classid=142">托福/雅思/GRE</a>
                        <a href="GoodsByClass.aspx?classid=143">课外书</a>
                        <a href="GoodsByClass.aspx?classid=144">其他</a>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading" role="tab" id="heading10">
                    <h4 class="panel-title">
                        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse10" aria-expanded="false" aria-controls="collapse10">租赁
                        </a>
                    </h4>
                </div>
                <div id="collapse10" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                    <div class="panel-body">
                        <a href="GoodsByClass.aspx?classid=146">服装</a>
                        <a href="GoodsByClass.aspx?classid=147">道具</a>
                        <a href="GoodsByClass.aspx?classid=148">其他</a>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading" role="tab" id="heading11">
                    <h4 class="panel-title">
                        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse11" aria-expanded="false" aria-controls="collapse11">生活娱乐
                        </a>
                    </h4>
                </div>
                <div id="collapse11" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading11">
                    <div class="panel-body">
                        <a href="GoodsByClass.aspx?classid=149">虚拟账号</a>
                        <a href="GoodsByClass.aspx?classid=150">日常用品</a>
                        <a href="GoodsByClass.aspx?classid=151">其他</a>
                        <a href="GoodsByClass.aspx?classid=152">乐器</a>
                        <a href="GoodsByClass.aspx?classid=153">化妆品</a>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading" role="tab" id="heading12">
                    <h4 class="panel-title">
                        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse12" aria-expanded="false" aria-controls="collapse12">其他
                        </a>
                    </h4>
                </div>
                <div id="collapse12" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading12">
                    <div class="panel-body">
                        <a href="GoodsByClass.aspx?classid=12">其他</a>
                    </div>
                </div>
            </div>
        </div>
        <h1>ni </h1>
        <h1>ni </h1>
        <h1>ni </h1>
        <h1>ni </h1>
        <h1>ni </h1>
        <h1>ni </h1>
        <h1>ni </h1>
        <h1>ni </h1>
        <h1>ni </h1>
        <h1>ni </h1>
        <h1>ni </h1>
        <h1>ni </h1>
        <h1>ni </h1>
    </form>
</body>
</html>
