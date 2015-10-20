/*首页 logo & 搜索功能 模块 脚本 v1.0.4.1*/
//顶部搜索
function topTag(e, f) {
    var topli = document.getElementById("top_menu" + e).getElementsByTagName("li");
    var topml = document.getElementById("top_main" + e).getElementsByTagName("ul");
    for (h = 0; h < topli.length; h++) {
        topli[h].className = h == f ? "top_hover" : "";
        topml[h].style.display = h == f ? "block" : "none";
    }
}
/* 服务 需求 搜索 */
function LogoAndSearchModuleMenuClick(e, weburl, url, Search) {
    var vs = ""
    if (Search == "txtSearchB") {
        vs = document.getElementById(Search).value;
        if (vs == "") {
            //vs = "$ALL$";
            vs = "";
        }
    }
    else {
        vs = document.getElementById(Search).value;
    }
    if (url.indexOf("?") >= 0) {
        url = weburl + "/Iframe.aspx?OrgUrl=" + url + "&para=" + vs;
    }
    else {
        url = weburl + "/Iframe.aspx?OrgUrl=" + url + "?para=" + vs;
    }
    var urlNewurl = encodeURI(url);
    parent.window.open(urlNewurl);
}
/* 机构搜索 */
function LogoAndSearchModuleOrgMenuClick(e, weburl, search) {
    var value = document.getElementById(search).value;
    var url = weburl + "/OrgInformation/OrgSearch.aspx?OrgName=" + value;
    var urlNewUrl = encodeURI(url);
    parent.window.open(urlNewUrl);
}
function returnDefalt() {
    window.open("Default.html");
}
$(function () {
    $("#txtName").click(function () {
        $("#clickValue").val("1");
    });
    $("#txtPwd").click(function () {
        $("#clickValue").val("1");
    });
    $("#txtSearchA").click(function () {
        $("#clickValue").val("2");
    });
    $("#txtSearchB").click(function () {
        $("#clickValue").val("3");
    });
    $("#txtSearchC").click(function () {
        $("#clickValue").val("4");
    });
    //回车事件
    $("body").keydown(function (event) {
        if (event.keyCode == 13) {
            switch ($("#clickValue").val()) {
                case "1":
                    $("#btnSub").focus();
                    $("#btnSub").click();
                    break;
                case "2":
                    LogoAndSearchModuleMenuClick(this,"http://www.tten.cn", "http://218.69.114.49/Product/AllProductSearch.aspx", "txtSearchA");
                    break;
                case "3":
                    LogoAndSearchModuleMenuClick(this, "http://www.tten.cn", "http://218.69.114.49/Demand/DemandSearch.aspx", "txtSearchB");
                    break;
                case "4":
                    LogoAndSearchModuleOrgMenuClick(this, "http://www.tten.cn", "txtSearchC");
                    break;
                default:
            }
        }
    });
});
/*首页 导航条 模块 脚本 v1.0.4.1*/
function HomePageNavigationMenuClick(e, url) {
    if (trim($(e).text(), "s") == "仪器设备") {
        if (url.indexOf("?") >= 0) {
            url = encodeURI(encodeURI(url + "&name=" + "仪器共享服务平台"));
        }
        else {
            url = encodeURI(encodeURI(url + "?name=" + "仪器共享服务平台"));
        }
    }
    else {
        if (url.indexOf("?") >= 0) {
            url = encodeURI(encodeURI(url + "&name=" + $(e).text()));
        }
        else {
            url = encodeURI(encodeURI(url + "?name=" + $(e).text()));
        }
    }
    parent.window.location.href = url;
}
/*科淘 点击事件*/
function HomePageNavigationMenuClickByKetao(e, url,defaultUrl,wfparaA) {
    var vs = defaultUrl + "/Portal/CloudIndex.aspx" + wfparaA;
    if (url.indexOf("?") >= 0) {
        url = url + "&name=" + $(e).text();
    }
    else {
        url = url + "?name=" + $(e).text();
    }
    url = encodeURI(url + "&OrgUrl=" + vs);
    parent.window.location.href = url;
}
//去除空格
function trim(str, is_global) {
    var result;
    result = str.replace(/(^\s+)|(\s+$)/g, "");
    if (is_global.toLowerCase() == "s")
        result = result.replace(/\s/g, "");
    return result;
}
/*首页 统计监测 模块 脚本 v1.0.4.1*/
$().ready(function () {
    try {
        //点击‘搜索按钮’事件
        $("#search").click(function () {
            //获取服务器上的ip地址
            var hostport = document.location.host;
            var host = "http://218.69.114.77:8040/";
            if (hostport.indexOf("www.tten.cn") >= 0) {
                host = "http://218.69.114.79/";
            } 
            var url = host+"/login/AllApproveIdentifiedEntInfo.aspx?companyName=";
            //文本框的值不等于‘请输入企业名称’
            if ($("#txtCompanyName").val() != "请输入企业名称")
                //给‘搜索’添加属性，添加超链接地址并且加上文本框的内容
                url = encodeURI(url + encodeURI($("#txtCompanyName").val()));
            //文本框的值等于‘请输入企业名称’               
            $("#search").attr("href", url);
        });
        //文本框失焦事件
        $("#txtCompanyName").blur(function () {
            //判断文本框的内容是否为空 如果是：文本框赋值‘请输入企业名称’ 如果否：不采取措施
            if ($("#txtCompanyName").val() == "") {
                $("#txtCompanyName").val('请输入企业名称');
            }
        });
    } catch (ex) {
    }
});
//点击文本框事件
function txtCompanyName_onclick() {
    //判断文本框的名称是否‘请输入企业名称’ 如果是：清空文本框的值 如果否：不采取措施
    if ($("#txtCompanyName").val() == "请输入企业名称") {
        $("#txtCompanyName").val('');
    }
}
//4个导航
function liclick(now) {
//    var value = $(now).html();
    //获取服务器上的ip地址
    var hostport = document.location.host;
    var hostUrl = "";
    if (hostport.indexOf("www.tten.cn") >= 0) {
        hostUrl = "http://www.tten.cn/";
    } else {
        hostUrl = "http://218.69.114.77:8020/";
    }
    hostUrl = hostUrl + "/TechnologyService.html?Name=" + now;
   // hostUrl = encodeURI(encodeURI(hostUrl));
    window.open(hostUrl);
}
/*首页 企业展厅 模块 脚本 v1.0.4.1*/
function CompanyExhibitionClick(IdentifiedInfoId, Orgid) {
    //获取服务器上的ip地址
    var hostport = document.location.host;
    if (hostport.indexOf("www.tten.cn") >= 0) {
        window.open('http://218.69.114.79/CompanyShow/CompanyShowDetail.aspx?IdentifiedInfoId=' + IdentifiedInfoId + '&OrgID=' + Orgid);
    } else {
        window.open('http://218.69.114.77:8040/CompanyShow/CompanyShowDetail.aspx?IdentifiedInfoId=' + IdentifiedInfoId + '&OrgID=' + Orgid);
    }
}
/*首页 需求信息 模块 脚本 v1.0.4.1*/
$(function () {
    try {
        //tab
        $("#technologyFinancialModule_tab").cstTab();
    } catch (e) {
    }
});
//免费发布需求
function TechnologyFinancialModulePostXuqu() {
    var type = "2";
    var orgid = "";
    $.post("getSessionForDefault.ashx", function (data, state) {
        var array = data.split('|');
        orgid = array[0];
        var typeid = array[1];
        if (state == "success") {
            if (orgid != null && orgid != "") {
                if (type == 1) { //服务
                    if (typeid == "2") //企业
                    {
                        $("#divFreeServer").show();
                        $("#divFreeServer").dialog({
                            title: "友情提示",
                            modal: true,
                            resizable: false,
                            width: 350,
                            height: 200,
                            buttons: {
                                "立即认证": function () {
                                    var hostportThree = document.location.host;
                                    var urlThree = "";
                                    if (!hostportThree.indexOf("www.tten.cn")) {
                                        urlThree = "../Gotopage.aspx?GotoUrl=http://218.69.114.49/Demand/DemandType.aspx&GotoMenuID=EnterpriseToOrganization_ID";
                                    } else {
                                        urlThree = "../Gotopage.aspx?GotoUrl=http://218.69.114.77/Demand/DemandType.aspx&GotoMenuID=EnterpriseToOrganization_ID";
                                    }
                                    window.open(urlThree);
                                    $("#divFreeServer").dialog('close');
                                },
                                "取消": function () {
                                    $("#divFreeServer").dialog('close');
                                }
                            }
                        });
                        //  alert("对不起，只有实名认证的企业可以发布服务");
                        return false;
                    }
                    //获取服务器上的ip地址
                    var hostportTwo = document.location.host;
                    var urlTwo = "";
                    if (!hostportTwo.indexOf("www.tten.cn")) {
                        urlTwo = "../Gotopage.aspx?GotoUrl=http://218.69.114.49/Demand/DemandType.aspx&GotoMenuID=wf_createproduct";
                    } else {
                        urlTwo = "../Gotopage.aspx?GotoUrl=http://218.69.114.77/Demand/DemandType.aspx&GotoMenuID=wf_createproduct";
                    }
                    if (typeid == "8") {
                        window.open(urlTwo);
                    }
                    if (typeid != "" && typeid != "8") {
                        window.open(urlTwo);
                    } if (typeid == "") {
                        alert("该用户没有权限！！");
                    }
                }
                if (type == 2) { //需求
                    if (typeid == "1") //机构
                    {
                        alert("对不起，机构账户暂时无此权限，请登陆企业账户发布需求！");
                        return false;
                    }
                    //获取服务器上的ip地址
                    var hostport = document.location.host;
                    var url = "";
                    if (!hostport.indexOf("www.tten.cn")) {
                        url = "../Gotopage.aspx?GotoUrl=http://218.69.114.49/Demand/DemandType.aspx&GotoMenuID=wf_ReleaseRequirement";
                    } else {
                        url = "../Gotopage.aspx?GotoUrl=http://218.69.114.77/Demand/DemandType.aspx&GotoMenuID=wf_ReleaseRequirement";
                    }
                    if (typeid == "8") {
                        window.open(url);
                    }
                    if (typeid != "" && typeid != "8") {
                        window.open(url);
                    } if (typeid == "") {
                        //alert("该功能还没完善，请点击用户中心");
                        alert("您没有权限访问该页！");
                        // window.open("../Gotopage.aspx?GotoUrl=http://218.69.114.77/ComTechnologicalProcess/Navigation.aspx&GotoMenuID=wf_ReleaseRequirement");
                    }
                }
            }
            else {
                window.open("../loginNew.aspx");
            }
        }
    });
}
/*首页 服务产品 模块 脚本 v1.0.4.1*/
//免费发布服务
function ServiceProductModulePostFuwu() {
    var type = "1";
    var orgid = "";
    $.post("getSessionForDefault.ashx", function (data, state) {
        var array = data.split('|');
        orgid = array[0];
        var typeid = array[1];
        if (state == "success") {
            if (orgid != null && orgid != "") {
                if (type == 1) { //服务
                    if (typeid == "2") //企业
                    {
                        $("#divFreeServer").show();
                        $("#divFreeServer").dialog({
                            title: "友情提示",
                            modal: true,
                            resizable: false,
                            width: 350,
                            height: 200,
                            buttons: {
                                "立即认证": function () {
                                    var hostportThree = document.location.host;
                                    var urlThree = "";
                                    if (hostportThree.indexOf("www.tten.cn")) {
                                        urlThree = "../Gotopage.aspx?GotoUrl=http://218.69.114.49/Demand/DemandType.aspx&GotoMenuID=EnterpriseToOrganization_ID";
                                    } else {
                                        urlThree = "../Gotopage.aspx?GotoUrl=http://218.69.114.77/Demand/DemandType.aspx&GotoMenuID=EnterpriseToOrganization_ID";
                                    }
                                    window.open(urlThree);
                                    $("#divFreeServer").dialog('close');
                                },
                                "取消": function () {
                                    $("#divFreeServer").dialog('close');
                                }
                            }
                        });
                        //  alert("对不起，只有实名认证的企业可以发布服务");
                        return false;
                    }
                    //获取服务器上的ip地址
                    var hostportTwo = document.location.host;
                    var urlTwo = "";
                    if (hostportTwo.indexOf("www.tten.cn")) {
                        urlTwo = "../Gotopage.aspx?GotoUrl=http://218.69.114.49/Demand/DemandType.aspx&GotoMenuID=wf_createproduct";
                    } else {
                        urlTwo = "../Gotopage.aspx?GotoUrl=http://218.69.114.77/Demand/DemandType.aspx&GotoMenuID=wf_createproduct";
                    }
                    if (typeid == "8") {
                        window.open(urlTwo);
                    }
                    if (typeid != "" && typeid != "8") {
                        window.open(urlTwo);
                    } if (typeid == "") {
                        alert("该用户没有权限！！");
                    }
                }
                if (type == 2) { //需求
                    if (typeid == "1") //机构
                    {
                        alert("对不起，机构账户暂时无此权限，请登陆企业账户发布需求！");
                        return false;
                    }
                    //获取服务器上的ip地址
                    var hostport = document.location.host;
                    var url = "";
                    if (hostport.indexOf("www.tten.cn")) {
                        url = "../Gotopage.aspx?GotoUrl=http://218.69.114.49/Demand/DemandType.aspx&GotoMenuID=wf_ReleaseRequirement";
                    } else {
                        url = "../Gotopage.aspx?GotoUrl=http://218.69.114.77/Demand/DemandType.aspx&GotoMenuID=wf_ReleaseRequirement";
                    }
                    if (typeid == "8") {
                        window.open(url);
                    }
                    if (typeid != "" && typeid != "8") {
                        window.open(url);
                    } if (typeid == "") {
                        //alert("该功能还没完善，请点击用户中心");
                        alert("您没有权限访问该页！");
                        // window.open("../Gotopage.aspx?GotoUrl=http://218.69.114.77/ComTechnologicalProcess/Navigation.aspx&GotoMenuID=wf_ReleaseRequirement");
                    }
                }
            }
            else {
                window.open("../loginNew.aspx");
            }
        }
    });
}
/*首页 浮动广告 模块 脚本 v1.0.4.1*/
function addEvent(obj, evtType, func, cap) {
    cap = cap || false;
    if (obj.addEventListener) {
        obj.addEventListener(evtType, func, cap);
        return true;
    } else if (obj.attachEvent) {
        if (cap) {
            obj.setCapture();
            return true;
        } else {
            return obj.attachEvent("on" + evtType, func);
        }
    } else {
        return false;
    }
}
function getPageScroll() {
    var xScroll, yScroll;
    if (self.pageXOffset) {
        xScroll = self.pageXOffset;
    } else if (document.documentElement && document.documentElement.scrollLeft) {
        xScroll = document.documentElement.scrollLeft;
    } else if (document.body) {
        xScroll = document.body.scrollLeft;
    }
    if (self.pageYOffset) {
        yScroll = self.pageYOffset;
    } else if (document.documentElement && document.documentElement.scrollTop) {
        yScroll = document.documentElement.scrollTop;
    } else if (document.body) {
        yScroll = document.body.scrollTop;
    }
    arrayPageScroll = new Array(xScroll, yScroll);
    return arrayPageScroll;
}
function GetPageSize() {
    var xScroll, yScroll;
    if (window.innerHeight && window.scrollMaxY) {
        xScroll = document.body.scrollWidth;
        yScroll = window.innerHeight + window.scrollMaxY;
    } else if (document.body.scrollHeight > document.body.offsetHeight) {
        xScroll = document.body.scrollWidth;
        yScroll = document.body.scrollHeight;
    } else {
        xScroll = document.body.offsetWidth;
        yScroll = document.body.offsetHeight;
    }
    var windowWidth, windowHeight;
    if (self.innerHeight) {
        windowWidth = self.innerWidth;
        windowHeight = self.innerHeight;
    } else if (document.documentElement && document.documentElement.clientHeight) {
        windowWidth = document.documentElement.clientWidth;
        windowHeight = document.documentElement.clientHeight;
    } else if (document.body) {
        windowWidth = document.body.clientWidth;
        windowHeight = document.body.clientHeight;
    }
    if (yScroll < windowHeight) {
        pageHeight = windowHeight;
    } else {
        pageHeight = yScroll;
    }
    if (xScroll < windowWidth) {
        pageWidth = windowWidth;
    } else {
        pageWidth = xScroll;
    }
    arrayPageSize = new Array(pageWidth, pageHeight, windowWidth, windowHeight)
    return arrayPageSize;
}
var AdMoveConfig = new Object();
AdMoveConfig.IsInitialized = false;
AdMoveConfig.ScrollX = 0;
AdMoveConfig.ScrollY = 0;
AdMoveConfig.MoveWidth = 0;
AdMoveConfig.MoveHeight = 0;
AdMoveConfig.Resize = function () {
    var winsize = GetPageSize();
    AdMoveConfig.MoveWidth = winsize[2];
    AdMoveConfig.MoveHeight = winsize[3];
    AdMoveConfig.Scroll();
}
AdMoveConfig.Scroll = function () {
    var winscroll = getPageScroll();
    AdMoveConfig.ScrollX = winscroll[0];
    AdMoveConfig.ScrollY = winscroll[1];
}
addEvent(window, "resize", AdMoveConfig.Resize);
addEvent(window, "scroll", AdMoveConfig.Scroll);
function AdMove(id) {
    if (!AdMoveConfig.IsInitialized) {
        AdMoveConfig.Resize();
        AdMoveConfig.IsInitialized = true;
    }
    var obj = document.getElementById(id);
    obj.style.position = "absolute";
    var W = AdMoveConfig.MoveWidth - obj.offsetWidth;
    var H = AdMoveConfig.MoveHeight - obj.offsetHeight;
    var x = W * Math.random(), y = H * Math.random();
    var rad = (Math.random() + 1) * Math.PI / 6;
    var kx = Math.sin(rad), ky = Math.cos(rad);
    var dirx = (Math.random() < 0.5 ? 1 : -1), diry = (Math.random() < 0.5 ? 1 : -1);
    var step = 1;
    var interval;
    this.SetLocation = function (vx, vy) { x = vx; y = vy; }
    this.SetDirection = function (vx, vy) { dirx = vx; diry = vy; }
    obj.CustomMethod = function () {
        obj.style.left = (x + AdMoveConfig.ScrollX) + "px";
        obj.style.top = (y + AdMoveConfig.ScrollY) + "px";
        rad = (Math.random() + 1) * Math.PI / 6;
        W = AdMoveConfig.MoveWidth - obj.offsetWidth;
        H = AdMoveConfig.MoveHeight - obj.offsetHeight;
        x = x + step * kx * dirx;
        if (x < 0) { dirx = 1; x = 0; kx = Math.sin(rad); ky = Math.cos(rad); }
        if (x > W) { dirx = -1; x = W; kx = Math.sin(rad); ky = Math.cos(rad); }
        y = y + step * ky * diry;
        if (y < 0) { diry = 1; y = 0; kx = Math.sin(rad); ky = Math.cos(rad); }
        if (y > H) { diry = -1; y = H; kx = Math.sin(rad); ky = Math.cos(rad); }
    }
    this.Run = function () {
        var delay = 10;
        interval = setInterval(obj.CustomMethod, delay);
        obj.onmouseover = function () { clearInterval(interval); }
        obj.onmouseout = function () { interval = setInterval(obj.CustomMethod, delay); }
    }
}
function hide() {
    float_close.style.visibility = "hidden";
}
