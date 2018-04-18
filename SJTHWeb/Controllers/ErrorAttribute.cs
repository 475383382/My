using sjth.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJTHWeb.Controllers
{
    public class ErrorAttribute : ActionFilterAttribute, IExceptionFilter
    {
        protected LogHelper Logger = new LogHelper();
        // GET: ErrorAttribute
        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext filterContext)
        {
            //获取异常信息，入库保存
            Exception Error = filterContext.Exception;
            string Message = Error.Message;//错误信息
            string Url = HttpContext.Current.Request.RawUrl;//错误发生地址

            Logger.writeInfos("-----------public void OnException(ExceptionContext filterContext)-----------\r\n" + Url + "\r\n" + Message + "\r\n");
            filterContext.ExceptionHandled = true;
            //filterContext.Result = new RedirectResult("/Shared/Error/");//跳转至错误提示页面
        }
    }
}