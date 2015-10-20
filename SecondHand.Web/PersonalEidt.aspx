<%@ Page Title="个人资料" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PersonalEidt.aspx.cs" Inherits="SecondHand.Web.PersonalEidt" %> <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        html, body, div, header, footer, form, p, input, button, h1, h2, h3, h4, h5, h6, ul, li, img, textarea {
            border: 0 none;
            outline: medium none;
            padding: 0;
        }         #my_info .infos li {
            display: inline-block;
            line-height: 30px;
            text-align: left;
            vertical-align: middle;
        }         .infos {
            color: #444444;
            font: 14px "Microsoft YaHei";
            margin: 10px 0 0 20px;
        }         #my_info li {
            float: left;
        }         .infoer {
            width: 60px;
            margin-right: 10px;
        }         .square {
            background-color: #f5f5f5;
            border: 1px solid #e3e3e3;
            -ms-border-radius: 4px;
            border-radius: 4px;
            -webkit-box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05) inset;
            -ms-box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05) inset;
            box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05) inset;
        }         .jumbotron {
            font-family: Microsoft YaHei;
            background: #009999;
            background: linear-gradient(8deg, #006666, #00CC99);
            min-height: 100%;
            color: white;   margin-bottom: 10px;
        }.img-circle {
            width: 200px;
            height: 200px;
        }     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12 jumbotron">
        <div class="col-lg-10 col-lg-offset-1">
            <h1>个人中心</h1>
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
            <li role="presentation" class="active"><a href="#tab1" data-toggle="tab" style="font-size: 20px; outline: none;">个人信息</a></li>
            <li role="presentation"><a href="PersonalGoods.aspx" style="font-size: 20px; outline: none;">我的商品</a></li>
            <li role="presentation"><a href="PersonIconEdit.aspx" 
                 style="font-size: 20px; outline: none;">编辑头像</a></li>
            <li role="presentation"><a href="PersonChangePass.aspx"  style="font-size: 20px; outline: none;">密码修改</a></li> 
        </ul>
    </div>
    <div class="col-lg-10 col-lg-offset-1">
        <div class="tab-content">
            <div class="tab-pane active" id="tab1">
                <div id="my_info">
                    <div id="account_info" class="col-lg-12">
                        <h2>账户信息</h2>
                        <div class="col-lg-12">
                            <ul class="infos">
                                <li class="infoer">账号</li>
                                <li>
                                    <span>
                                        <asp:Label ID="lblUserEmail" runat="server" Text=" "></asp:Label>
                                    </span>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div id="base_info" class="col-lg-12">
                        <h2>基本信息&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnEdit" CssClass="btn btn-primary btn-sm" runat="server" Text="编辑" OnClick="btnEdit_Click" />    
                            <asp:Button ID="btnSave" CssClass="btn btn-success btn-sm" runat="server" Text="保存" Visible="False" OnClick="btnSave_Click" /></h2>
                        <div class="col-lg-12">
                            <ul class="infos">
                                <li class="infoer">昵称</li>
                                <li>
                                    <asp:Label ID="lblUserName1" Style="width: 100px;" nowrap="nowrap" runat="server" Text=" "></asp:Label>
                                </li>
                                <li>
                                    <asp:TextBox ID="txtuserName" runat="server" Style="width: 200px;" CssClass="  form-control" Visible="False"></asp:TextBox>
                                </li>
                            </ul>
                        </div>
                        <div class="col-lg-12">
                            <ul class="infos">
                                <li class="infoer">手机</li>
                                <li>
                                    <span id="phone_span">
                                        <asp:Label ID="lblPhoneNum" runat="server" Text=" "></asp:Label></span>           </li>
                                <li>
                                    <asp:TextBox ID="txtPhoneNum" runat="server" Style="width: 200px;" CssClass="  form-control" Visible="False"></asp:TextBox>
                                </li>
                            </ul>
                        </div>
                        <div class="col-lg-12">
                            <ul class="infos">
                                <li class="infoer">QQ</li>
                                <li>
                                    <span id="qq_span">
                                        <asp:Label ID="lblQQNum" runat="server" Text=" "></asp:Label></span> </li>
                                <li>
                                    <asp:TextBox ID="txtQQNum" runat="server" Style="width: 200px;" CssClass="  form-control" Visible="False"></asp:TextBox>
                                </li>
                            </ul>
                        </div>
                        <div class="col-lg-12">
                            <ul class="infos">
                                <li class="infoer">邮箱</li>
                                <li>
                                    <span>
                                        <asp:Label ID="lblinfoEmai" runat="server" Text=" "></asp:Label></span> </li>
                                <li>
                                    <asp:TextBox ID="txtInfoEmail" runat="server" Style="width: 200px;" CssClass="  form-control" Visible="False"></asp:TextBox>
                                </li>
                            </ul>
                        </div>
                        <%--<div class="col-lg-12">
                            <ul class="infos">
                                <li class="infoer">证件号</li>
                                <li>
                                    <span>
                                        <asp:Label ID="lblContent" runat="server" Text=" "></asp:Label></span> </li>
                                <li>
                                    <asp:TextBox ID="txtContent" runat="server" Style="width: 200px;" CssClass="  form-control" Visible="False"></asp:TextBox>
                                </li>
                            </ul>
                        </div>--%>
                    </div>
                </div>
            </div>
            <div class="tab-pane " id="tab2">werwe</div>
            <div class="tab-pane " id="tab3">werewr</div>
             <div class="tab-pane " id="tab4">werwerwerewr</div>
        </div>
    </div>
</asp:Content>
