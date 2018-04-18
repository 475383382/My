using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;

namespace sjth.Common
{
    public static class AppConfig
    {
        /// <summary>
        /// 邮件服务器URL
        /// </summary>
        public static string MailServer
        {
            get
            {
                return ConfigurationManager.AppSettings["mailServer"];
            }
        }
        /// <summary>
        /// 项目URL
        /// </summary>
        public static string CreateUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["CreateUrl"];
            }
        }
        /// <summary>
        /// 页面名称
        /// </summary>
        public static string PageName
        {
            get
            {
                return System.IO.Path.GetFileName(HttpContext.Current.Request.Path)
                     .Substring(0, System.IO.Path.GetFileName(HttpContext.Current.Request.Path).IndexOf('.'));
            }
        }
    }
}
