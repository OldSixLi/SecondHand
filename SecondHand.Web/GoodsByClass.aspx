<%@ Page Title="物品分类" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GoodsByClass.aspx.cs" Inherits="SecondHand.Web.GoodsByClass" %>
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
            background: #f06;
            background: linear-gradient(8deg, #006666, #00CC99);
            min-height: 100%;
            color: white;
             margin-bottom: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12 jumbotron">
        <div class="col-lg-10 col-lg-offset-1">
            <h1>校园二手网</h1>
            <br />
            <h3>物品分类：<asp:Label ID="lblClassName" runat="server" Text="Label"></asp:Label></h3>
            <br />
        </div>
    </div>
    <div class="col-lg-10 col-lg-offset-1 " style="min-height:500px;">
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
                             <h4><a href="IntroduceGoods.aspx?wpad=<%#Eval("GoodsID") %>"><%#Eval("GoodsName") %></a></h4>
                            <%#Eval("Detail").ToString().Length>60? Eval("Detail").ToString().Substring(0,60)+"...":Eval("Detail").ToString()%>
                            <br />
                            <br />
                            <span class="label label-danger"><b><%#Eval("Price") %>&nbsp;元</b></span> <b><%#Eval("UserName") %></b> <b class="pull-right"><%#Convert.ToDateTime(Eval("PublishTime").ToString()).ToLongDateString() %>&nbsp;</b>
                        </div>
                     </div>
                </div>
            </ItemTemplate>
            <FooterTemplate></FooterTemplate>
        </asp:Repeater>
    </div>
 </asp:Content>
