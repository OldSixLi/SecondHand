<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="杂色.aspx.cs" Inherits="SecondHand.Web.杂色" %>
 <!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>方块</title>
    <style>
        .inde {
            z-index: 0;
            height: 99px;
            width: 100%;
                        border-left:solid black 1px;
            border-top: solid black 1px;
            border-right: solid black 1px;
            /*border-bottom: solid black 1px;*/
        }
         .shu {
            z-index: 10;
            height:800px;
            width: 100px;
            float: left;
            opacity: 0.3;
           border-right:solid black 1px;
           /*  border-top: solid black 1px;
            border-bottom: solid black 1px;*/
        }
         .square {
            margin-top: 20px;
            width: 1000px;
            height: 800px;
            margin-left: auto;
            margin-right: auto;
        }
    </style>
</head>
 <body style="padding: 0; margin: 0;">
    <form id="form1" runat="server">
        <div class="square">
            <div class="inde" style="background-color: #33CCFF"></div>
            <div class="inde" style="background-color: #33FF33"></div>
            <div class="inde" style="background-color: #33FF99"></div>
            <div class="inde" style="background-color: #6633FF"></div>
            <div class="inde" style="background-color: #666666"></div>
            <div class="inde" style="background-color: #993333"></div>
            <div class="inde" style="background-color: #99CC66"></div>
            <div class="inde" style="height: 98px;background-color: #99FFFF;border-bottom:solid black 1px;"></div>
        </div>
        <div style="position:relative; left: 0; top: -820px;; overflow: hidden" class="square">
             <div class="shu" style="background-color: #33CCFF"></div>
            <div class="shu" style="background-color: #33FF33"></div>
            <div class="shu" style="background-color: #33FF99"></div>
            <div class="shu" style="background-color: #6633FF"></div>
            <div class="shu" style="background-color: #666666"></div>
            <div class="shu" style="background-color: #993333"></div>
            <div class="shu" style="background-color: #99CC66"></div>
            <div class="shu" style="background-color: #99FFFF"></div>
            <div class="shu" style="background-color: #339933"></div>
            <div class="shu" style="background-color: #FF66CC"></div>
            <div class="shu" style="background-color: #FF9966"></div>
            <div class="shu" style="background-color: #FFCCFF"></div>
            <div class="shu" style="background-color: #33CCCC"></div>
        </div>
    </form>
</body>
</html>
