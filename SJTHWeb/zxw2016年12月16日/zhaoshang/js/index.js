$.noConflict();
jQuery(function (){
	initComplexArea('seachprov', 'seachcity', 'seachdistrict', area_array, sub_array, '44', '0', '0');
});

//得到地区码
function getAreaID(){
	var area = 0;          
	if(jQuery("#seachdistrict").val() != "0"){
		area = jQuery("#seachdistrict").val();                
	}else if (jQuery("#seachcity").val() != "0"){
		area = jQuery("#seachcity").val();
	}else{
		area = jQuery("#seachprov").val();
	}
	return area;
}

function showAreaID() {
	//地区码
	var areaID = getAreaID();
	//地区名
	var areaName = getAreaNamebyID(areaID) ;
	alert("您选择的地区码：" + areaID + "      地区名：" + areaName);            
}

//根据地区码查询地区名
function getAreaNamebyID(areaID){
	var areaName = "";
	if(areaID.length == 2){
		areaName = area_array[areaID];
	}else if(areaID.length == 4){
		var index1 = areaID.substring(0, 2);
		areaName = area_array[index1] + " " + sub_array[index1][areaID];
	}else if(areaID.length == 6){
		var index1 = areaID.substring(0, 2);
		var index2 = areaID.substring(0, 4);
		areaName = area_array[index1] + " " + sub_array[index1][index2] + " " + sub_arr[index2][areaID];
	}
	return areaName;
}

function set_address(){
	//地区码
	var areaID = getAreaID();
	//地区名
	var areaName = getAreaNamebyID(areaID) ;
      
       jQuery("#address").val(areaName);
}



var btncd;
var cdi=60;
if(jQuery.cookie("cdi")){
      cdi=jQuery.cookie("cdi");
      jQuery("#sendbtn").attr("disabled","disabled");
     Countdown();
}

function showcd(){
       cdi--;
      if(cdi==0){
            cdi=60;  
             jQuery("#sendbtn").val("获取短信验证码");
            jQuery("#sendbtn").removeAttr("disabled");
            clearInterval(btncd);
           
      }else{
            jQuery.cookie("cdi",cdi);
           jQuery("#sendbtn").val(cdi+"秒后可重新获取");
      }

}
function Countdown(){
      jQuery("#sendbtn").attr("disabled","disabled");
      btncd=setInterval("showcd()",1000);
}
function sendsms(){
		if(!(/^1[3578]{1}[0-9]{9}$/.test(jQuery("#mobile").val()))){
			jQuery('#mobile').focus();
			alert("手机号码输入有误！");		
		}else{
                
                  jQuery("#sendbtn").attr("disabled","disabled");
			jQuery.post("sendsms.php",{mobi:jQuery("#mobile").val(),r:Math.random()},function(data){
				alert(data);
                        jQuery("#sendbtn").removeAttr("disabled");
                         if(data=="验证码已发送到你手机! "){
                              Countdown();
                        }
			});
			
		}
		return false;		
}