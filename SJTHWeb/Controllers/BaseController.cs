using sjth.BLL;
using sjth.Common;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace SJTHWeb.Controllers
{
     [ErrorAttribute]
    public class BaseController : Controller
    {
        /// <summary>
        /// 用户登录信息
        /// </summary>
         public manager BaseCompany { get; set; }
        /// <summary>
        /// 企业ID
        /// </summary>
        public int USERID { get; set; }
        public BaseController()
        {

        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext)
        {
            manager modelUserInfo = new manager();
            base.Initialize(requestContext);
            //这里实现用户信息的相关验证业务  
            if (System.Web.HttpContext.Current.Request.IsAuthenticated)//是否通过身份验证
            {
                HttpCookie authCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];//获取cookie
                FormsAuthenticationTicket Ticket = FormsAuthentication.Decrypt(authCookie.Value);//解密
                // BaseUsersinfo = bllUserinfoService.GetById(Ticket.UserData.ToInt());
                manageBLL modelst = new manageBLL();


                BaseCompany = modelst.GetById(Convert.ToInt32(Ticket.UserData));//反序列化
                USERID = BaseCompany.id;
            }
            else
            {
                //非登录用户跳转  
                requestContext.HttpContext.Response.Redirect("/UserManager/Login");
            }
        }
        /// <summary>  
        /// 统一错误日志编写  
        /// </summary>  
        /// <param name="filterContext"></param>  
        protected override void OnException(ExceptionContext filterContext)
        {
            LogHelper Logger = new LogHelper();
            // 错误日志编写      
            string controllerNamer = filterContext.RouteData.Values["controller"].ToString();
            string actionName = filterContext.RouteData.Values["action"].ToString();
            string exception = filterContext.Exception.ToString();

            Logger.writeInfos("-----------" + controllerNamer + "-----------\r\n" + actionName + "\r\n" + exception + "\r\n");
            // 执行基类中的OnException      
            base.OnException(filterContext);
        }
    }
}