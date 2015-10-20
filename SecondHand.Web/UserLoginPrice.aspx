<%@ Page Title="校园二手网" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserLoginPrice.aspx.cs" Inherits="SecondHand.Web.UserLoginPrice" %> <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .jumbotron {
            font-family: Microsoft YaHei;
            /*background: #f06;*/
            background: #009999;
            background: linear-gradient(8deg, #006666, #00CC99);
            /*background: linear-gradient(8deg, #009999, #009999);*/
            background-image: url("Images/sunset.jpg");
            min-height: 100%;
            margin-bottom: 15px;
            color: white;
        }         .pp {
            margin: 5px 2px;
        }         .spanleft {
            margin-left: -6px;
        }         .thumbnail .caption {
            color: #333;
            padding: 0px;
        }         .img-responsive, .thumbnail > img, .thumbnail a > img, .carousel-inner > .item > img, .carousel-inner > .item > a > img {
            width: 230px;
            height: 220px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12 jumbotron">
        <div class="col-lg-10 col-lg-offset-1">
            <h1>校园二手网</h1>
            <br />
            <h3>二手物品、闲置物品，通通放到这里</h3>
            <br />
        </div>
    </div>
    <%--  <div class="col-lg-9 col-lg-offset-2  " style="position: relative; left: -30px;">--%>
    <div class="col-lg-10 col-lg-offset-1  " style="position: relative;">
        <div class="container1">
            <ul class=" nav nav-tabs " role="tabits">
                <li role="presentation"><a href="UserLogin.aspx" style="font-size: 20px; outline: none;"><b>最新发布</b> </a></li>
                <li role="presentation" class="active"><a href="#tab2" style="font-size: 20px; outline: none;"><b>价格排行</b> </a></li>
            </ul>
        </div>
    </div>
    <%--<div class="col-lg-9 col-lg-offset-2 " style="position: relative; left: -30px;">--%>
    <div class="col-lg-10 col-lg-offset-1  " style="position: relative;">
        <div class="tab-content">
            <div class="tab-pane   active" id="tab2">
                <br />
                <%--   //Repeater价格--%>
                <asp:Repeater ID="Repeat1" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-3 col-md-4 col-sm-6">
                            <div class="thumbnail">
                                <a href="IntroduceGoods.aspx?wpad=<%#Eval("GoodsID") %>">
                                    <img src="<%#Eval("GoodsImg") %>" /></a><span style="float: right" class="label label-danger glyphicon glyphicon-yen"><asp:Label
                                        ID="lblprice" runat="server" Text=""><%#Eval("Price") %></asp:Label>
                                    </span><span>
                                        <asp:Label ID="lblusername" runat="server" Text=""><%#Eval("Username") %></asp:Label></span>
                                <div class="caption">
                                    <p class="pp">
                                        <a href="IntroduceGoods.aspx?wpad=<%#Eval("GoodsID") %>" style="outline: none; text-decoration: none">
                                            <site title="<%# Eval("GoodsName")%>">
                                                              <%#   Eval("GoodsName").ToString().Length>10?Eval("GoodsName").ToString().Substring(0,10)+"..":Eval("GoodsName").ToString()%>
                                            </site>
                                        </a>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="col-lg-12">
                            <div class="pager">
                                <nav>
                                    <%--翻页按钮--%>
                                    <ul class="pagination pagination-lg" style="margin-left: auto; margin-right: auto;">
                                        <li>
                                            <asp:LinkButton ID="lnkUpPage" runat="server" Enabled="<%# Webpageindex1>1%>" OnCommand="Goup1"><span aria-hidden="true">&laquo;</span></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="pagejian2" runat="server" Text='<%# Webpageindex1 -2%>' Visible='<%# Webpageindex1 -2 > 0%>'
                                                OnCommand="GOjian21"></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="pagejian1" runat="server" Text='<%# Webpageindex1 -1%>' Visible='<%# Webpageindex1 -1 > 0%>'
                                                OnCommand="GOjian11"></asp:LinkButton>
                                        </li>
                                        <li class=" active"><a href="#"><%# Webpageindex1%></a>
                                            <li>
                                                <asp:LinkButton ID="lnkjia1" runat="server" Text='<%# Webpageindex1 +1%>' Visible='<%# Webpageindex1 +1 <=WebPageCount1%>'
                                                    OnCommand="GOjia11"></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnkjia2" runat="server" Text='<%# Webpageindex1+2%>' Visible='<%# Webpageindex1 +2<=WebPageCount1%>'
                                                    OnCommand="GOjia21"></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnkNextPage" runat="server" Enabled="<%# WebPageCount1-Webpageindex1>0%>"
                                                    OnCommand="Gonp1"><span aria-hidden="true">&raquo;</span></asp:LinkButton>
                                            </li>
                                    </ul>
                                </nav>
                            </div>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
