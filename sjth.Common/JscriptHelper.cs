using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;
using System.Web;

namespace sjth.Common
{
    /// <summary>
    /// 客户端提示信息
    /// </summary>
    public class JscriptHelper : Controller
    {
        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="tyle">1-成功 2-错误 3-警告</param>
        //public ActionResult toastrAlertMessage(string message, int tyle)
        //{
        //    string exScript = "";
        //    switch (tyle)
        //    {
        //        case  1:
        //            exScript = string.Format("toastr.success('{0}');", message);
        //            break;
        //        case 2:
        //            exScript = string.Format("toastr.error('{0}');", message);
        //            break;
        //        case 3:
        //            exScript = string.Format("toastr.warning('{0}');", message);
        //            break;
        //    }

        //    return ShowAlert(exScript);

        //}
        //public ActionResult showAndGo(string text, string goUrl)
        //{
        //    return ShowAlert(" toastr.success('" + text + "');location.href='" + goUrl + "';");
        //}
   //     public ActionResult ShowAlert(string script)
   //     {

   //         StringBuilder strBuilder=new StringBuilder();
   //         strBuilder.Append("    <script src=\"/Content/assets/plugins/modernizr/js/modernizr.js\"></script>");
   // strBuilder.Append(" <script src=\"/Scripts/jquery-1.10.2.min.js\"></script> ");
   // strBuilder.Append(" <script src=\"/Scripts/jquery.unobtrusive-ajax.min.js\"></script>");
   // strBuilder.Append(" <script src=\"/Content/vendor/plugins/toastrt/toastr.min.js\"></script>");
   //strBuilder.Append("  <link href=\"/Content/css/toastr/toastr.min.css\" rel=\"stylesheet\" />");
   //strBuilder.Append("  <link href=\"/Content/css/mycss.css\" rel=\"stylesheet\" />");
   //        // var script = string.Format("toastr.warning('{0}');", msg);

   //      //   return JavaScript(strBuilder + script);

   //         return Content(strBuilder + "<script >" + script + "</script >", "text/html");

   //     }


        /// <summary>
        /// 返回JS提示信息并跳转ViewResult
        /// </summary>
        ///  <remarks>
        /// 提示显示图标默认显示成功,不自动关闭
        /// </remarks>
        /// <param name="msg">提示消息</param>
        /// <param name="actionName">操作的名称</param>
        /// <param name="controllerName">控制器的名称</param>
        /// <param name="roteValues">路由的参数</param>
        /// <param name="msgStatus">提示显示图标（默认显示成功）</param>
        /// <param name="autoClose">是否自动关闭，1：是，0：否</param>
        /// <returns></returns>
        public ActionResult RedirectArtDialogToAction(string message, string actionName, string controllerName, object roteValues,int tyle)
        {
            string url = controllerName + "/" + actionName;
            string exScript = "";
            switch (tyle)
            {
                case 1:
                    exScript = string.Format("toastr.success('{0}');", message);
                    break;
                case 2:
                    exScript = string.Format("toastr.error('{0}');", message);
                    break;
                case 3:
                    exScript = string.Format("toastr.warning('{0}');", message);
                    break;
            }
           // string url = Url.Action(actionName, controllerName, roteValues);

            string _RedirectJSString = @"
                 <script src='/Content/assets/plugins/modernizr/js/modernizr.js'></script>
    <script src='/Scripts/jquery-1.10.2.min.js'></script>
    <script src='/Scripts/jquery.unobtrusive-ajax.min.js'></script>
    <script src='/Content/vendor/plugins/toastrt/toastr.min.js'></script>
    <link href='/Content/css/toastr/toastr.min.css' rel='stylesheet' />
    <link href='/Content/css/mycss.css' rel='stylesheet' />

                <script type='text/javascript'>
               $(function(){
                       " + exScript + "; setInterval(\"location.href = '/" + url + "'\", 3000);})</script>";

           System.Web.HttpContext.Current.Response.Write(_RedirectJSString);
            return null;
        }
    }
}
