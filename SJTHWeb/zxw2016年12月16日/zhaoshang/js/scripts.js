
jQuery(document).ready(function() {

    /*
        Background slideshow
       jQuery.backstretch([
      "assets/img/backgrounds/1.jpg"
    , "assets/img/backgrounds/2.jpg"
    , "assets/img/backgrounds/3.jpg"
    ], {duration: 3000, fade: 750});
*/
 
    /*
        Tooltips
       jQuery('.links a.home').tooltip();
    jQuery('.links a.blog').tooltip(); */


    /*
        Form validation
    */
    jQuery('.register form').submit(function(){
        jQuery(this).find("label[for='xingming']").html('姓名');
        jQuery(this).find("label[for='weixin']").html('微信号');
        jQuery(this).find("label[for='mobile']").html('手机号码');
        jQuery(this).find("label[for='smscode']").html('短信认证');
        jQuery(this).find("label[for='password']").html('Password');
        ////
        var firstname = jQuery(this).find('input#tt_name').val();
        var lastname = jQuery(this).find('input#weixin').val();
        var mobile = jQuery(this).find('input#mobile').val();
        var smscode = jQuery(this).find('input#smscode').val();
        var password = jQuery(this).find('input#password').val();
        var namerule = new RegExp("^[\u4e00-\u9fa5]{2,5}");
	  var PADD = new RegExp("^[A-Za-z0-9_\u554A-\u9C52]{3,50}");
		
       if(!namerule.test(firstname)) {
            
			 alert("请正确输入，姓名只能是2~5个汉字");
			
            return false;
					
			
        }
		
		
        if(!PADD.test(lastname)) {
            jQuery(this).find("label[for='weixin']").append("<span style='display:none' class='red'> - 只能含有汉字、数字、字母、下划线最少5个字节.</span>");
            jQuery(this).find("label[for='weixin'] span").fadeIn('medium');
            return false;
        }
        if(mobile == '') {
            jQuery(this).find("label[for='mobile']").append("<span style='display:none' class='red'> - 请正确输入手机号.</span>");
            jQuery(this).find("label[for='mobile'] span").fadeIn('medium');
            return false;
        }
        if(smscode == '') {
            jQuery(this).find("label[for='smscode']").append("<span style='display:none' class='red'> - 请输入您手机收到的验证码.</span>");
            jQuery(this).find("label[for='smscode'] span").fadeIn('medium');
            return false;
        }
        if(password == '') {
            jQuery(this).find("label[for='password']").append("<span style='display:none' class='red'> - Please enter a valid password.</span>");
            jQuery(this).find("label[for='password'] span").fadeIn('medium');
            return false;
        }

       if(jQuery("#seachcity").val()=="0" || jQuery("#seachprov").val()=="0"){
             alert("请选择所在地区");
            return false;
      }

       if(!jQuery("#dizhi").val()){
             alert("请填写你的详细街道地址!");
            return false;
      }


    });


});

