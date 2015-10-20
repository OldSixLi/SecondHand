<%@ Page Title="商品详情" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="IntroduceGoods.aspx.cs" Inherits="SecondHand.Web.IntroduceGoods" %> <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style/introducegoods.css" rel="stylesheet" />
    <style>
        .fromwho {
        }         .jumbotron {
            font-family: Microsoft YaHei;
            /*background: #f06;*/
            background: #009999;
            background: linear-gradient(8deg, #006666, #00CC99);
            /*background: linear-gradient(8deg, #009999, #009999);*/
            min-height: 100%;
            color: white;   margin-bottom: 10px;
        }         .img-thumbnail {
            width: 600px;
            height: 600px;
        }         .fontsize {
            font-size: 17px;
        }
    /*#Goodsimg {
            width: 600px;
            height: 600px;
        }*/
        /*tr {
        margin : 5px;             background: #006666;
        }*/
    </style>
    <script>
        $(document).ready(function () {
            $(".Reply").click(function () {
                var aa = $(this).attr("data-param");
            });
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--表头--%>
    <div class="col-lg-12 jumbotron">
        <div class="col-lg-10 col-lg-offset-1">
            <h1>商品介绍</h1>
            <br />
            <h3>校园二手物品交易市场</h3>
            <br />
        </div>
    </div>
    <%--物品相关信息--%>
    <div class="col-lg-offset-1 col-lg-10 back">
        <%--头像--%>
        <div class="col-lg-8 " style="height: 600px; width: 600px; overflow: hidden">
            <img id="Goodsimg" class="img-thumbnail" runat="server" />
            <%-- <asp:Button ID="btnsavegoods" CssClass="btn btn-primary" runat="server" Text="收藏" OnClick="btnsavegoods_Click" />--%>
        </div>
        <%--物品详细介绍--%>
        <div class="col-lg-4 ">
            <div class=" col-lg-10">
                <table class="intro">
                    <tr>
                        <td class="td1">
                            <label class="goodsheader"></label>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <h1>&nbsp;</h1>
                    <tr>
                        <td class="td1">
                            <label class="goodsheader">物品</label>
                        </td>
                        <td>
                           <asp:Label ID="goodsname" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td1">
                            <label class="goodsheader">联系人</label></td>
                        <td>
                            <asp:Label ID="username" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td1">
                            <label class="goodsheader">价格</label></td>
                        <td>
                            <asp:Label ID="price" runat="server" Text="Label"></asp:Label>元</td>
                    </tr>
                    <tr>
                        <td class="td1">
                            <label class="goodsheader">议价</label></td>
                        <td>
                            <asp:Label ID="ischage" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td1">
                            <label class="goodsheader">交易地点</label></td>
                        <td>
                            <asp:Label ID="address" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="td1">
                            <label class="goodsheader">联系电话</label>
                        </td>
                        <td>
                            <asp:Label ID="content" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="td1">
                            <label class="goodsheader">QQ联系</label>
                        </td>
                        <td>
                            <asp:Label ID="QQnum" runat="server" Text=" "></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <%-- <td class="td1">
                                <label class="goodsheader">图片路径</label>
                            </td>
                            <td>
                             </td>--%>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <%--描述内容--%>
    <div class="col-lg-10 col-lg-offset-1 back" style="margin-top: 20px;">
        <label style="float: left; font-size: 20px;">物品介绍</label><hr style="border: 1px solid; color: #003366; margin-top: 13px;" />
        <div class="well">
            <asp:Label ID="detail" runat="server" Text="Label" class="fontsize"></asp:Label>
        </div>
    </div>
    <%--评论及推荐--%>
    <div class="col-lg-10 col-lg-offset-1 back" style="margin-top: 20px;">
        <%--评论区--%>
        <%-- TODO 后其添加物品推荐项--%>
        <div class="col-lg-12" style="padding:  0 ;  ">
            <div class="panel panel-default chat">
                <div class="panel-heading"><span class="glyphicon glyphiconmargin glyphicon-comment"></span>评论区</div>
                <div class="panel-body">
                    <ul>
                        <asp:Repeater ID="RepeatComment" runat="server">
                            <HeaderTemplate></HeaderTemplate>
                            <%--评论各项--%>
                            <ItemTemplate>
                                <li class="left clearfix">
                                    <span class="chat-img pull-left">
                                        <img style="width: 60px; height: 60px;" class="img-circle" src="<%#Eval("UserIcon") %>">
                                    </span>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div class="chat-body clearfix">
                                        <strong class="primary-font fromwho"><%#Eval("FromWho") %></strong>回复
                                                <strong class="primary-font"><%#Eval("ToWho") %> </strong>
                                        <small class="text-muted pull-right"><%#Eval("PublishTime") %></small>
                                        <p class="p_comment"><%#Eval("CommentContent") %></p>
                                        <asp:LinkButton ID="btnReply" class="btn btn-primary  btn-sm pull-right" OnClientClick='changeplaceholder()' runat="server" OnCommand="Reply" CommandArgument='<%#Eval("FromUser") %>'
                                            Visible='<%# ReplyFromWho !=Eval("FromUser").ToString()%>'>回复</asp:LinkButton>
                                        <%--todo 登陆后进来页面隐藏回复按钮，当前页面登陆不隐藏--%>
                                        <%--   <a class="Reply" data-param="<%#Eval("FromUser") %>">aaaa</a>--%>
                                    </div>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate></FooterTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="panel-footer">
                    <div class="input-group" id="chatfoot">
                        <asp:TextBox ID="txtComment" placeholder="Type your message here..." class="form-control " runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="Chat" runat="server" class="btn btn-success " Text="发表" OnClick="Chat_Click" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
