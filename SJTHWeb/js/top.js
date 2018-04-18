$(function(){
    $(".topbox ul li a").click(function(){
        $(".topbox ul li a").removeClass("topeven")
        $(this).addClass("topeven")
    })
})