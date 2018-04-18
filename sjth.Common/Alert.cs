using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace sjth.Common
{
    public static class Alert
    {

        #region 提示信息并返回原页面
        public static void show(string text)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.showAlertMsg('" + text + "');</script>");
            //HttpContext.Current.Response.End();
        }
        #endregion

        #region 不提示信息只返回原页面
        public static void Up()
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.history.go(-1);</script>");
        }
        #endregion

        #region 提示信息并重新加载原页面
        public static void reload(string text)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.showAlertMsg('" + text + "');window.location.reload();</script>");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 只提示信息
        public static void showOnly(string text)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.showAlertMsg('" + text + "');</script>");
        }
        #endregion

        #region 提示信息并跳转到指定页面
        public static void showAndGo(string text, string goUrl)
        {
            HttpContext.Current.Response.Write("<script language='javascript'> toastr.success('" + text + "');location.href='" + goUrl + "';</script>");
        }
        public static void showAndGo(System.Web.UI.Page page, string text, string goUrl)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript'> toastr.success('" + text + "');location.href='" + goUrl + "';</script>");
        }
        /// <summary>
        /// 显示消息提示 并跳转转指定页面
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="text">text: 显示消息</param>
        /// <param name="time">time：停留时间ms</param>
        /// <param name="type"> type：类型 4：成功，5：失败，3：警告</param>
        /// <param name="goUrl">goUrl:跳转URL</param>
        public static void showAndGo(string text, int time, int type, string goUrl)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.showOverAlertMsg('" + text + "'," + time + "," + type + ");location.href='" + goUrl + "';</script>");
        }
        #endregion

        #region 不提示信息只跳转到指定页面
        public static void GoHref(string goUrl)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>location.href='" + goUrl + "';</script>");
            HttpContext.Current.Response.End();
        }
        public static void GoParentHref(string goUrl)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>parent.location.href='" + goUrl + "';</script>");
            HttpContext.Current.Response.End();
        }
        public static void GoHrefAddTab(string title, string goUrl)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.addTab('" + title + "','" + goUrl + "',true);</script>");
            HttpContext.Current.Response.End();
        }
        public static void GoHrefAddTab_page(System.Web.UI.Page page, string title, string goUrl)
        {

            page.ClientScript.RegisterStartupScript(page.GetType(), "", "<script language='javascript' >window.parent.addTab('" + title + "','" + goUrl + "',true);</script>");
        }
        /// <summary>
        /// 打开新页 并关闭指定页
        /// </summary>
        /// <param name="title"></param>
        /// <param name="goUrl"></param>
        public static void GoHrefAddTabAndCloseCurr(string title, string goUrl, string closePageTitle)
        {

            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.addTab('" + title + "','" + goUrl + "',true);</script>");
            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.tabCloseBySubTitle('" + closePageTitle + "');</script>");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 不提示信息只跳转到父页面
        public static void GoParent(string goUrl)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>parent.location.href='" + goUrl + "';</script>");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 不提示信息只跳转到主页面
        public static void GoIndex(string goUrl)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>top.location.href='" + goUrl + "';</script>");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 只显示部分字符串
        public static string SubStr(string sString, int nLeng)
        {
            if (sString.Length <= nLeng)
            {
                return sString;
            }
            string sNewStr = sString.Substring(0, nLeng);
            sNewStr = sNewStr + "...";
            return sNewStr;
        }
        public static void RedirectUrl(string url)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.location.href='" + url + "';</script>");
        }
        #endregion

        #region 向页面注册JavaScript，使页面弹出提示框时页面背景不会为空白
        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>window.parent.showAlertMsg('" + msg.ToString() + "');</script>");
        }
        /// <summary>
        /// 显示消息提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">msg: 显示消息</param>
        /// <param name="time">time：停留时间ms</param>
        /// <param name="type"> type：类型 4：成功，5：失败，3：警告</param>
        public static void Show(System.Web.UI.Page page, string msg, int time, int type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>window.parent.showOverAlertMsg('" + msg.ToString() + "'," + time + "," + type + ");</script>");
        }

        /// </summary>
        /// <param name="text">显示消息</param>
        public static void ShowAndCloes(string text)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.showAlertMsg('" + text + "');window.parent.tabclosetab(); </script>");
            HttpContext.Current.Response.End();
        }
        /// </summary>
        /// <param name="text">显示消息</param>
        public static void GoBack()
        {
            HttpContext.Current.Response.Write("<script language='javascript'>history.go(-1) </script>");
            HttpContext.Current.Response.End();
        }
        /// </summary>
        /// <param name="text">显示消息</param>
        public static void ShowAndBack(string text)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.showAlertMsg('" + text + "');history.go(-1)</script>");
            HttpContext.Current.Response.End();
        }
        /// </summary>
        /// <param name="text">显示消息</param>
        public static void ShowConfirmAndCloseTab(string text, int time, int type)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.showAlertMsg('" + text + "'," + time + "," + type + ");window.parent.tabclosetab();</script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 显示消息提示框 并且关闭当前页面
        /// </summary>
        /// <param name="text">显示消息</param>
        /// <param name="time">time：停留时间ms</param>
        /// <param name="type"> type：类型 4：成功，5：失败，3：警告</param>
        public static void ShowAndCloes(string text, int time, int type)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.showOverAlertMsg('" + text + "'," + time + "," + type + ");window.parent.tabclosetab(); </script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 显示消息提示框 并且关闭当前页面
        /// </summary>
        /// <param name="text">显示消息</param>
        /// <param name="time">time：停留时间ms</param>
        /// <param name="type"> type：类型 4：成功，5：失败，3：警告</param>
        public static void ShowAndClose(string text, int time, int type)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.showOverAlertMsg('" + text + "'," + time + "," + type + ");window.parent.getIframe();</script>");
            HttpContext.Current.Response.End();
        }
        public static void ShowAndAction(System.Web.UI.Page page, string msg, string action)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>eval('" + action + "');window.parent.showAlertMsg('" + msg + "');</script>");
        }

        public static void ShowAndBack(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>window.parent.showAlertMsg('" + msg + "');window.history.go(-1);</script>");

        }
        /// <summary>
        /// 控件点击 消息确认提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }
        /// <summary>
        /// 显示消息提示框 并且关闭当前页面
        /// </summary>
        /// <param name="text">显示消息</param>
        /// <param name="time">time：停留时间ms</param>
        /// <param name="type"> type：类型 4：成功，5：失败，3：警告</param>
        /// <param name="url"> 跳转链接</param>
        public static void ShowAndGo(string text, int time, int type, string url)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.showOverAlertMsg('" + text + "'," + time + "," + type + ");window.location.href='" + url + "'</script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirectgo(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("window.parent.showAlertMsg('{0}');", msg);
            Builder.AppendFormat("window.location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }
        /// <summary>
        /// 输出自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
        }
        #endregion

    }
}
