 //顶部搜索
function topTag(e,f){
	var topli=document.getElementById("top_menu"+e).getElementsByTagName("li");
	var topml=document.getElementById("top_main"+e).getElementsByTagName("ul");
	for(h=0;h<topli.length;h++){
	   topli[h].className=h==f?"top_hover":"";
	   topml[h].style.display=h==f?"block":"none";
	}
}

 //通知通告 | 新闻动态 | 工作简报
function setTag(m,n){
	var tli=document.getElementById("menu"+m).getElementsByTagName("li");
	var mli=document.getElementById("main"+m).getElementsByTagName("ul");
	for(i=0;i<tli.length;i++){
	   tli[i].className=i==n?"hover":"";
	   mli[i].style.display=i==n?"block":"none";
	}

	for(var k=0;k<3;k++)
	{
		document.all["subLink"+k].style.display="none";
		if(k==n)
		{
		 document.all["subLink"+k].style.display="block";
		}
	}
}

 //创业载体
function carrierTag(x,y){
	var carrierli=document.getElementById("carrier_menu"+x).getElementsByTagName("li");
	var carrierml=document.getElementById("carrier_main"+x).getElementsByTagName("span");
	for(j=0;j<carrierli.length;j++){
	   carrierli[j].className=j==y?"carrier_hover":"";
	   carrierml[j].style.display=j==y?"block":"none";
	}
}
 
