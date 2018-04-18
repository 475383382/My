using sjth.DAO;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace sjth.BLL
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class manageBLL :Base2DAOManager<manager>
    {
        private managerDAO DAO = new managerDAO();
        public manager managerLogin(string name,string pw)
        {
            return DAO.managerLogin(name, pw);
        }
        /// <summary>
        /// 获取用户登录信息
        /// </summary>
        /// <returns></returns>
        public manager GetIsAutUsersInfo()
        {
            if (HttpContext.Current.Request.IsAuthenticated)//是否通过身份验证
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];//获取cookie
                FormsAuthenticationTicket Ticket = FormsAuthentication.Decrypt(authCookie.Value);//解密
                return GetById(Ticket.UserData.ToInt());
            }
            //非登录用户跳转  
            HttpContext.Current.Response.Redirect("/UserManager/Login");
            return null;
        }
    }
}
