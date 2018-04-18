using sjth.Common;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sjth.BLL;
using System.Web.Security;
namespace SJTHWeb.Controllers
{
    public class UserManagerController : Controller
    {
        // GET: UserManager
        private manageBLL BLL = new manageBLL();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            manager models = new manager();
            string cnum = Session["ValidateCode"] == null ? "" : Session["ValidateCode"].ToString();
            models = BLL.managerLogin(model.Name, model.password);
            if (models!=null)
            {
                //FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, models.id.ToString(), DateTime.Now, DateTime.Now.AddDays(7), false, models.id.ToString());
                //            HttpCookie Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(Ticket));//加密身份信息，保存至Cookie
                //            Response.Cookies.Add(Cookie);


                            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, models.id.ToString(), DateTime.Now, DateTime.Now.AddDays(7), false,models.id.ToString());
                            
                            string encTicket = FormsAuthentication.Encrypt(Ticket);
                this.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,encTicket));
                            //HttpCookie Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(Ticket));//加密身份信息，保存至Cookie
                            //Response.Cookies.Add(Cookie);
                 
                            return Redirect("/Product/count");
               
            }
            else
            {
                //验证码错误
               // ModelState.AddModelError("yanzhengma", "验证码错误！");
                return View();
            }
        }
        
        public ActionResult aa()
        {
            return View();
        }
        public ActionResult userInfo()
        {
            return View();
        }
        #region 验证码
        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckCode()
        {
            //生成验证码
            ValidateCode validateCode = new ValidateCode();
            string code = ValidateCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
        #endregion
    }
}