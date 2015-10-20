/**************************************************************************************************
 * 描述：
 *      选项卡（tab） jquery 插件。
 * 变更历史：
 *      作者：李亮  时间：2014/6/26 16:25:23     新建 
 **************************************************************************************************/
$.fn.extend({
    cstTab: function (option) {
        return this.each(function () {
            var t = $(this),
                o = option || {},
                head = o.head || t.find("li[data-flag='cst-tab-head']"), //标签点击的对象。
                body = o.body || t.find("div[data-flag='cst-tab-body']"), //内容显示的对象。
                event = o.event || 'mouseover', //事件可以为click,hover或是mouseover。
                eq = o.eq || 0; //初始化的时候可以默认显示第几块。不传值显示第一个。
            
            head.bind(event, function () { //通过bind 传这个evt,事件就可以变动了，不一定只是click事件了。
                $(this).addClass('cst-tab-curr')
                       .siblings(head)
                       .removeClass('cst-tab-curr'); //处理标签头：加当前的Class，样式通过css改变
                
                body.eq(head.index($(this)))
                    .show()
                    .siblings("div[data-flag='cst-tab-body']")
                    .hide(); //内容块显示。
                
            }).hover(function () {
                $(this).addClass('cst-tab-hover')
                       .siblings(head)
                       .removeClass('cst-tab-hover'); //标签的body移上去的时候加一个样式，这样子这个标签头可以有默认，hover和curr三种状态。
            });
            
            event === 'click' ? head.eq(eq).click() : head.eq(eq).mouseover(); //初始化，当前是第几个
        });
    }
});