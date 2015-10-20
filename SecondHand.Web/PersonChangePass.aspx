<%@ Page Title="密码修改" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PersonChangePass.aspx.cs" Inherits="SecondHand.Web.PersonChangePass" %> <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        }         .img-circle {
            width: 200px;
            height: 200px;
        }         .txtpad {
            margin : 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12 jumbotron">
        <div class="col-lg-10 col-lg-offset-1">
            <h1>密码修改</h1>
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
            <li role="presentation"><a href="PersonalGoods.aspx" style="font-size: 20px; outline: none;">我的商品</a></li>
            <li role="presentation"><a href="PersonIconEdit.aspx" style="font-size: 20px; outline: none;">编辑头像</a></li>
            <li role="presentation" class="active"><a href="#tab4" data-toggle="tab" style="font-size: 20px; outline: none;">修改密码</a></li>
        </ul>
    </div>
    <div class="col-lg-10 col-lg-offset-1">
        <div class="tab-content">
            <div class="tab-pane " id="tab1">
            </div>
            <div class="tab-pane " id="tab2">
            </div>
            <div class="tab-pane " id="tab3">
            </div>
            <div class="tab-pane active" id="tab4">
                <div class="col-lg-4">
                    <asp:TextBox ID="oldpass" placeholder="请输入原来的密码" CssClass="form-control txtpad" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:TextBox ID="newpass" placeholder="请输入新的密码，不能和原密码一致"  CssClass="form-control txtpad"  runat="server" TextMode="Password"></asp:TextBox>
                    <asp:TextBox ID="repeatpass" placeholder="请再次输入新密码"  CssClass="form-control txtpad"  runat="server" TextMode="Password"></asp:TextBox>
                    <asp:Button ID="btnChange" class=" btn btn-primary" runat="server" Text="修改" style="display:block;margin-left: auto;margin-right: auto" OnClick="btnChange_Click" />
                </div>
            </div>
        </div>
    </div> </asp:Content>
