String.prototype.format = function () {
    var args = arguments;
    return this.replace(/\{(\d+)\}/g,
        function (m, i) {
            return args[i];
        });
}
//String的静态方法  
String.format = function () {
    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;

}
var sumCountP = 0;
var pageIndex = 0;
var Find = Class.create();
var IsWork = false;
Find.prototype = {
    initialize: function (options) { },
    async: false,
    Get: function (index) {
        // pageIndex = index;  
        //验证  
        var validate = GoValidate($("#queryBtn").attr("rel"));

        var CardNO = $("#queryCardNO").val();
        var CPH = $("#queryCPH").val();
        var ParkName = $("#queryParkName").val();
        //  var pageIndex = 0;  
        var outcount = 0;
        $("#page").html("正在执行查询请稍后...").show();

        $.getJSON("/GOOUTRECORD/FindQuery", { CardNO: CardNO, CPH: CPH, ParkName: ParkName, pageIndex: index, pageSize: 22 },
              function (json) {
                  if (json.Success) {
                      var html = "";
                      //填充数据  
                      var pagetemp = "<div class=\"c666\"  >查询完毕，共找到 <span id=\"resultcount\">{0}</span> 条有效记录</div>";
                      var temp = "<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td><td>{10}</td><td>{11}</td><td>{12}</td><td>{13}</td><td>{14}</td><td>{15}</td><td>{16}</td><td>{17}</td><td>{18}</td><td>{19}</td><td>{20}</td><td>{21}</td><td>{22}</td><td>{23}</td><td>{24}</td><td>{25}</td><td>{26}</td><td>{27}</td><td>{28}</td><td>{29}</td>";
                      for (var i = 0; i < json.Count; i++) {

                          var o = json.Data[i];
                          html += temp.format(o.CardNO, o.CPH, o.CardType, o.InTime, o.OutTime, o.InGateName, o.OutGateName, o.InOperatorCard, o.OutOperatorCard, o.InOperator, o.OutOperator, o.InPic, o.InUser, o.OutPic, o.OutUser, o.ZJPic, o.SFJE, o.Balance, o.YSJE, o.SFTime, o.SFOperator, o.SFOperatorCard, o.SFGate, o.OvertimeSymbol, o.OvertimeSFTime, o.OvertimeSFJE, o.CarparkNO, o.BigSmall, o.ParkName, o.FreeReason);
                      }
                      $("#tb tbody").html(html);
                      $("#page").html(String.format(pagetemp, json.Count));
                      $("#tb tbody tr:odd").addClass("bgcf8"); //偶数行颜色  
                      var Dijipage = pageIndex + 1

                      sumCountP = (json.SumCount % 22 == 0 ? parseInt(json.SumCount / 22) : parseInt(json.SumCount / 22 + 1));
                      var htmlStr = "";
                      htmlStr += "<span>共有记录" + json.SumCount + "条;  共<span id='SumPcount'>" + parseInt(Dijipage) + "/" + sumCountP + "</span>页  " + "</span>";
                      htmlStr += "<a href='javascript:void' onclick='GoToFirstPage()' id='aFirstPage' >首    页</a>   ";
                      htmlStr += "<a href='javascript:void' onclick='GoToPrePage()' id='aPrePage' >前一页</a>   ";
                      htmlStr += "<a href='javascript:void' onclick='GoToNextPage()' id='aNextPage'>后一页</a>   ";
                      htmlStr += "<a href='javascript:void' onclick='GoToEndPage()' id='aEndPage' >尾    页</a>   ";
                      htmlStr += "<input type='text' style=margin-right:5px;width:35px; height:20px;/><input  type='button' style=margin-left:5px; value='跳转' onclick='GoToAppointPage(this)' /> ";
                      $("#barcon").html(htmlStr);


                  }
                  else {
                      $("#page").html(json.Message);
                  }
                  if (json.Count > 0) {
                      //$(".result").slideDown("slow");  
                      $("div#resultdiv").attr("style", "overflow-y: auto; overflow-x: auto;height:400px;display: none;");
                      $("div#resultdiv").slideDown("slow");

                  }
                  else {
                      $("div#resultdiv").attr("style", "display: none;");
                  }
                  IsWork = false;
              }
        );
    }
};



$(function () {
    var find = new Find();
    //alert(find.Template);  

    $.ajaxSetup({
        cache: false,
        async: false,
        global: false,
        type: "POST"
    });

    //$(".Validate").click(function () { return GoValidate($(this).attr("rel")) });  

    $("#queryBtn").click(function () { find.Get() });
    $("#queryBtnGj").click(function () { openwindow() });
})


//首页  
function GoToFirstPage() {
    alert(1)
    var find = new Find();
    pageIndex = 0;
    find.Get(pageIndex)
    // AjaxGetData($("#txtSearch").val(), pageIndex);  
}
//前一页  
function GoToPrePage() {
    pageIndex -= 1;
    pageIndex = pageIndex >= 0 ? pageIndex : 0;
    var find = new Find();
    find.Get(pageIndex)

    // AjaxGetData($("#txtSearch").val(), pageIndex);  
}
//后一页  
function GoToNextPage() {
    if (pageIndex + 1 < sumCountP) {
        pageIndex += 1;
    }

    var find = new Find();

    find.Get(pageIndex)

    //AjaxGetData($("#txtSearch").val(), pageIndex);  
}
//尾页  
function GoToEndPage() {
    pageIndex = sumCountP - 1;
    var find = new Find();

    find.Get(pageIndex)
    //AjaxGetData($("#txtSearch").val(), pageIndex);  
}
//跳转  
function GoToAppointPage(e) {
    var page = $(e).prev().val();
    if (isNaN(page)) {
        alert("请输入数字!");
    }
    else {
        var tempPageIndex = pageIndex;
        pageIndex = parseInt($(e).prev().val()) - 1;
        if (pageIndex < 0 || pageIndex >= sumCountP) {
            pageIndex = tempPageIndex;
            alert("请输入有效的页面范围!");
        }
        else {
            var find = new Find();

            find.Get(pageIndex)
            //AjaxGetData($("#txtSearch").val(), pageIndex);  
        }
    }
}

$("#queryBtnGj").click(function () { openwindow() });

function openwindow() {
    window.showModalDialog("/Advancedsearch/Index", window, "status:no;scroll:no;dialogWidth:235px;dialogHeight:400px");
}