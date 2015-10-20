<%@ Page Title="个人物品" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PersonalGoods.aspx.cs" Inherits="SecondHand.Web.PersonalGoods" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        html, body, div, header, footer, form, p, input, button, h1, h2, h3, h4, h5, h6, ul, li, img, textarea {
            border: 0 none;
            outline: medium none;
            padding: 0;
        }
         #my_info .infos li {
            display: inline-block;
            line-height: 30px;
            text-align: left;
            vertical-align: middle;
        }
         .infos {
            color: #444444;
            font: 14px "Microsoft YaHei";
            margin: 10px 0 0 20px;
        }
         #my_info li {
            float: left;
        }
         .infoer {
            width: 60px;
            margin-right: 10px;
        }
         .square {
            background-color: #f5f5f5;
            border: 1px solid #e3e3e3;
            -ms-border-radius: 4px;
            border-radius: 4px;
            -webkit-box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05) inset;
            -ms-box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05) inset;
            box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05) inset;
        }
         .padd {
            padding: 5px 20px;
        }
         .imgsquare {
            width: 110px;
            height: 110px;
        }
         .backcolor {
            background-color: #f5f5f5;
            padding: 10px;
            -ms-border-radius: 4px;
            border-radius: 4px;
            -webkit-box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05) inset;
            -ms-box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05) inset;
        }
             .backcolor:hover {
                background-color: #CCFFFF;
                padding: 10px;
            }
         .jumbotron {
            font-family: Microsoft YaHei;
            background: #009999;
            background: linear-gradient(8deg, #006666, #00CC99);
            min-height: 100%;
            color: white;   margin-bottom: 10px;
        }
         .img-circle {
            width: 200px;
            height: 200px;
        }
         .hei {
             min-height: 160px;
         }
    </style>
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12 jumbotron">
        <div class="col-lg-10 col-lg-offset-1">
            <h1>我的商品</h1>
            <br />
            <h3>校园二手物品交易市场</h3>
            <br />
        </div>
    </div>
    <div class="col-lg-10 col-lg-offset-1">
        <div class="col-lg-12 square" style="height: 260px; padding: 30px;">
             <div class="pull-left" style="width: 200px; margin: 0    30px;">
                <img id="UserIconImg" class="img-circle" runat="server" />
            </div>
            <table style="border-color: black; height: 200px; border-left-style: solid; border-width: 1px; float: left;">
                <tr>
                    <td></td>
                </tr>
            </table>
            <div style="float: left; margin-left: 30px;">
                <h1>
                    <asp:Label ID="lblName" runat="server" Text=" "></asp:Label></h1>
                <br />
                <br />
                <h3>已发布了<asp:Label ID="lblGoodsCount" runat="server" Text=" "></asp:Label>件二手物品</h3>
            </div>
         </div>
    </div>
     <div class="col-lg-10 col-lg-offset-1" style="margin-top: 20px;">
        <ul class="nav  nav-tabs" role="tabits">
            <li role="presentation"><a href="PersonalEidt.aspx" style="font-size: 20px; outline: none;">个人信息</a></li>
            <li role="presentation" class="active"><a href="#tab2" data-toggle="tab" style="font-size: 20px; outline: none;">我的商品</a></li>
            <li role="presentation"><a href="PersonIconEdit.aspx"  style="font-size: 20px; outline: none;">修改头像</a></li>
            <li role="presentation"><a href="PersonChangePass.aspx"   style="font-size: 20px; outline: none;">修改密码</a></li>
        </ul>
    </div>
     <div class="col-lg-10 col-lg-offset-1 hei">
        <div class="tab-content">
            <div class="tab-pane " id="tab1">
            </div>
            <div class="tab-pane active " id="tab2">
                <asp:Repeater ID="RepeaterGoods" runat="server">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <div class="padd">
                            <div class="media backcolor">
                                <div class="media-left">
                                    <a href="IntroduceGoods.aspx?wpad=<%#Eval("GoodsID") %>">
                                        <img  src="<%#Eval("GoodsImg") %>" class="media-object imgsquare" /></a>
                                </div>
                                <div class="media-body">
                                    <asp:LinkButton ID="LinkButtonDelete" title="删除" CssClass="pull-right" runat="server" CommandArgument='<%#Eval("GoodsID") %>'
                                        OnCommand="Deleter" OnClientClick='<%#  "if (!confirm(\"你确定要删除商品：" + Eval("GoodsName").ToString() + "吗?\")) return false;"%>'>
                                                        <span class="glyphicon glyphicon-trash"></span>
                                    </asp:LinkButton>
                                    <a class="pull-right " title="修改物品信息" style="padding-right: 15px;" href="GoodsDetailEdit.aspx?wpad=<%#Eval("GoodsID") %>"><span class="glyphicon glyphicon-pencil"></span></a>
                                     <h4><%#Eval("GoodsName") %></h4>
                                    <%#Eval("Detail").ToString().Length>60? Eval("Detail").ToString().Substring(0,60)+"...":Eval("Detail").ToString()%>
                                    <br />
                                    <br />
                                    <b><%#Eval("Price") %>&nbsp;元</b><b class="pull-right"><%#Convert.ToDateTime(Eval("PublishTime").ToString()).ToLongDateString() %>&nbsp;</b>
                                </div>
                             </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="tab-pane " id="tab3">werewr</div>
            <div class="tab-pane " id="tab4"> </div>
        </div>
    </div>
 </asp:Content>
