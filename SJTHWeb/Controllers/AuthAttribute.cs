using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJTHWeb.Controllers
{
    /// <summary>
    /// 验证权限（action执行前会先执行这里）
    /// </summary>
    [ErrorAttribute]
    public class AuthAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 验证权限（action执行前会先执行这里）
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //如果存在身份信息
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ContentResult Content = new ContentResult();
                Content.Content = string.Format("<script type='text/javascript'>window.location.href='{0}';</script>", "/UserManager/Login");//FormsAuthentication.LoginUrl alert('请先登录！');"/Account/Login"
                filterContext.Result = Content;
            }
        }
    }
}