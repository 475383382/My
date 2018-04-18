	$(function(){
	var $nav = $("#navbar li");/**/
	/*$("#navbar li").css({"border":"1px #f00 solid","height":"75px","overflow":"hidden"});*/
	
	$nav.hover(function(){
		$(this).find(".ej_show_box").css({"display":"block"});
		/*console.log($(this).index());*/
	},function(){
		$(this).find(".ej_show_box").css({"display":"none"});
	})
})