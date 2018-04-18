using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sjth.Common
{
   public static class NVCFromEnumValue
    {
       /// <summary>
       /// 从枚举类型和它的特性读出并返回一个键值对
        /// （使用此方法请确保枚举有特性）
       /// </summary>
       /// <param name="enumType">Type,该参数的格式为typeof(需要读的枚举类型</param>
       /// <returns>键值对</returns>
       public static NameValueCollection GetNVCFromEnumValue(Type enumType)
        {
            NameValueCollection nvc=new NameValueCollection();
            Type typeDescription = typeof (DescriptionAttribute);
            System.Reflection.FieldInfo[] fields = enumType.GetFields();
            string strText = string.Empty;
            string strValue = string.Empty;
            foreach (var field in fields)
            {
                if (field.FieldType.IsEnum)//判断当前的文件类型是否是枚举
                {
                    strValue = ((int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length>0)
                    {
                        DescriptionAttribute temp = (DescriptionAttribute) arr[0];
                        strText = temp.Description;
                    }
                    else
                    {
                        strText = field.Name;
                    }
                    nvc.Add(strText,strValue);
                }
            }
            return nvc;
        }
       public static Dictionary<int, string> GetStatus<T>()
       {
           return GetStatus(typeof(T));
       }
       public static string GetStatus<T>(object v)
       {
           return GetDescription(typeof(T), v);
       }
       private static Dictionary<int, string> GetStatus(System.Type t)
       {
           Dictionary<int, string> list = new Dictionary<int, string>();

           Array a = Enum.GetValues(t);
           for (int i = 0; i < a.Length; i++)
           {
               string enumName = a.GetValue(i).ToString();
               int enumKey = (int)System.Enum.Parse(t, enumName);
               string enumDescription = GetDescription(t, enumKey);
               list.Add(enumKey, enumDescription);
           }
           return list;
       }


       private static string GetName(System.Type t, object v)
       {
           try
           {
               return Enum.GetName(t, v);
           }
           catch
           {
               return "";
           }
       }

       private static Dictionary<string, string> GetStatuNames(System.Type t)
       {
           Dictionary<string, string> list = new Dictionary<string, string>();

           Array a = Enum.GetValues(t);
           for (int i = 0; i < a.Length; i++)
           {
               string enumName = a.GetValue(i).ToString();
               int enumKey = (int)System.Enum.Parse(t, enumName);
               string enumDescription = GetDescription(t, enumKey);
               list.Add(enumName, enumDescription);
           }
           return list;
       }
       /// <summary>
       /// 返回指定枚举类型的指定值的描述
       /// </summary>
       /// <param name="t">枚举类型</param>
       /// <param name="v">枚举值</param>
       /// <returns></returns>
       private static string GetDescription(System.Type t, object v)
       {
           try
           {
               FieldInfo fi = t.GetField(GetName(t, v));
               DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
               return (attributes.Length > 0) ? attributes[0].Description : GetName(t, v);
           }
           catch
           {
               return "";
           }
       }
    }
}
