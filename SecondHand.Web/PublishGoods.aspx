<%@ Page Title="发布二手物品" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="PublishGoods.aspx.cs" Inherits="SecondHand.Web.PublishGoods" %> <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style/publish.css" rel="stylesheet" />
    <style type="text/css">
        .hr1 {
            color: #003366;
            margin-top: 0;
        }         .img-circle {
            width: 200px;
            height: 200px;
            border: 1px solid green;
        }     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12 jumbotron">
        <%--页头--%>
        <div class="col-lg-10 col-lg-offset-1">             <h1>发布二手物品</h1>
            <br />
            <h3>&nbsp;</h3>
            <br />
        </div>
    </div>
    <div class="col-lg-10 col-lg-offset-1    ">
        <div class="well">
            <div class="form-horizontal">
                <%--名称--%>
                <div class="form-group  ">
                    <div class="col-lg-5 col-lg-offset-4">
                        <div style="width: 200px; height: 200px; margin: 30px;">
                            <img id="ImgIcon" class="img-circle" runat="server" alt="上传图片" src="Images/can1.png"></img>
                        </div>                         <br />
                        <div>
                            <asp:FileUpload ID="fileAttachment" CssClass="pull-left" Width="200px" runat="server" />                             <asp:Button ID="btnFileUpload" runat="server" Text="上传图片" class="btn btn-danger btn-sm" OnClick="btnFileUpload_Click" />
                        </div>                     </div>
                </div>
                <div class="col-lg-4 col-lg-offset-1">
                    <div class="spantext " style="color: black">
                        商品详情<span class="spantext">（请完善以下信息）</span>
                    </div>
                </div>
                <div class="col-lg-9 col-lg-offset-1">
                    <hr class="hr1" style="border: 0; background-color: #006666; height: 1px;" />
                </div>
                <div class="form-group  ">
                    <label for="goodsname" class="col-lg-2 col-lg-offset-1 control-label ">商品名称</label>
                    <div class="col-lg-6">
                        <asp:TextBox ID="goodsname" class="form-control" runat="server" placeholder="请输入不超过15个字的商品名称"></asp:TextBox>
                    </div>
                </div>
                <%-- 商品详情--%>                 <div class="form-group ">
                    <label for="goodsdetail" class="col-lg-2 col-lg-offset-1 control-label ">商品描述</label>
                    <div class="col-lg-6">
                        <%--<asp:TextBox ID="goodsdetail" runat="server" class="form-control" Rows="3" ></asp:TextBox>--%>
                        <textarea id="goodsdetail" class="form-control" runat="server" rows="3" placeholder="建议填写物品用途，新旧程度，原价等信息，不少于25字"></textarea>
                    </div>
                </div>
                <%--交易地点--%>
                <div class="form-group">
                    <label for="chargeplace" class="control-label col-lg-1 col-lg-offset-2">
                        交易地点
                    </label>
                    <div class="col-lg-6">
                        <asp:TextBox ID="chargeplace" runat="server" class="form-control" placeholder="宿舍，教学楼，食堂等"></asp:TextBox>
                    </div>
                </div>
                <%--价格--%>
                <div class="form-group">
                    <label for="price" class="col-lg-2 col-lg-offset-1 control-label">价格</label>
                    <div class="col-lg-3 ">
                        <div class="input-group">
                            <span class="input-group-btn spantextt">
                                <button class="btn btn-default ">
                                    <span style="font-size: 14px;">￥</span>
                                </button>
                            </span>
                            <asp:TextBox ID="price" runat="server" class="form-control" placeholder="" MaxLength="8" onkeyup="value=value.replace(/[^\d.]/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <%--分类--%>
                <div class="form-group">
                    <label for="chooseclass" class="control-label col-lg-1 col-lg-offset-2">分类</label>
                    <div class="col-lg-3">
                        <asp:DropDownList ID="ddlFristClass" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFristClass_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-lg-3">
                        <asp:DropDownList ID="ddlSecondClass" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <%--  议价--%>
                <div class="form-group">
                    <label for="Charge" class="control-label col-lg-2 col-lg-offset-1">可否议价</label>
                    <div class="col-lg-3">
                        <input id="Charge" runat="server" type="checkbox" aria-checked="True" class="form-control  "
                            data-on-text="可议价" data-on-color="info" data-off-text="不可议价" data-off-color="danger" />
                    </div>
                </div>
                <div class="col-lg-4 col-lg-offset-1">
                    <div class="spantext " style="color: black">
                        联系方式<span class="spantext">（请至少填写一项）</span>
                    </div>
                </div>
                <%--分割线--%>
                <div class="col-lg-9 col-lg-offset-1">
                    <hr class="hr1" style="border: 0; background-color: #006666; height: 1px;" />
                </div>
                <%-- 手机--%>
                <div class="form-group">
                    <label for="txtPhone" class="control-label col-lg-2 col-lg-offset-1">手机号</label>
                    <div class="col-lg-3">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="请填写有效手机号码"></asp:TextBox>
                    </div>
                </div>
                <%--     QQ--%>
                <div class="form-group">
                    <label for="QQNumber" class="control-label col-lg-2 col-lg-offset-1">QQ号</label>
                    <div class="col-lg-3">
                        <asp:TextBox ID="QQNumber" runat="server" CssClass="form-control" placeholder="请留下您的联系QQ "></asp:TextBox>
                    </div>
                </div>
                <%--同意规则--%>
                <div class="form-group">
                    <label for="" class="control-label col-lg-2 col-lg-offset-1"></label>
                    <div class="col-lg-4">
                        <input id="checkAgree" onclick="isaccepted()" runat="server" type="checkbox" data-switch-no-init />&nbsp;<a href="WZNotice/GoodsNotice.html" target="_blank">我同意《商品发布规则》</a>
                    </div>
                </div>
                <%--发布按钮--%>
                <div class="form-group">
                    <div class="col-lg-3 col-lg-offset-3">
                        <asp:Button ID="btnPublish" runat="server" disabled="disabled" CssClass="btn btn-block btn-success  spantextt"
                            Text="发布商品" OnClick="btnPublish_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--后期移出--%>
    <script>
        function isaccepted() {
            var a = document.getElementById("ContentPlaceHolder1_checkAgree").checked;
            if (a) {
                $("#ContentPlaceHolder1_btnPublish").removeAttr("disabled");//按钮可用
                //alert(a);
            } else {
                $("#ContentPlaceHolder1_btnPublish").attr("disabled", true);//按钮不可用
            }
        };
        $(document).ready(function () {
            isaccepted();
            //提示是否离开页面
            //$(function () {
            //    window.onbeforeunload = function () { event.returnValue = "您正在编辑的信息尚未提交，离开本页面后信息将丢失!"; };
            //});
        }
        );
    </script>
</asp:Content>
<%--data-switch-no-init checked --%>