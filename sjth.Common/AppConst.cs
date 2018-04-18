using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace sjth.Common
{
    /// <summary>
    /// 验证类
    /// </summary>
    public static class AppConst
    {
        public const string StringNull = "";
        public const int IntNull = 0;
        public const decimal DecimalNull = 0;

        public static DateTime DateTimeNull = DateTime.Parse("1900-01-01");
        #region 验证数字
        /// <summary>
        /// 验证是否位数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            if (str == null || str.Length == 0)
                return false;
            foreach (char c in str)
            {
                if (!char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 正则表达验证数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool RegExp_IsNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
            return reg1.IsMatch(str);
        }
        #endregion
        #region 验证日期
        public static bool IsDate(object str)
        {
            try
            {
                Convert.ToDateTime(str);
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion
        /// <summary>
        /// 验证手机号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsMobilePhone(string str)
        {
            Regex reg = new Regex("^13\\d{9}$");
            return reg.IsMatch(str);
        }
        /// <summary>
        /// 验证正整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUint(string str)
        {
            Regex reg = new Regex("^[0-9]*[1-9][0-9]*$");
            return reg.IsMatch(str);
        }
        ///<summary>
        ///判断输入的字符串是否是一个合法的Email地址
        ///</summary>
        ///<param name="input"></param>
        ///<returns></returns> 
        public static bool IsEmail(string input)
        {
            string pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]
                {1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
        ///<summary>
        ///判断输入的字符串是否只包含数字和英文字母
        ///</summary>
        ///<param name="input"></param>
        ///<returns></returns> 
        public static bool IsNumAndEnCh(string input)
        {
            string pattern =@"^[A-Za-z0-9]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
        public static string ProductImageUrl
        {
            get { return WebConfigurationManager.AppSettings["ProductImage"]; }
        }
    }
}
