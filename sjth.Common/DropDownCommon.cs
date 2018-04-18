using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace sjth.Common
{
    public class DropDownCommon
    {
        /// <summary>
        /// 绑定 DropDownList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ds"></param>
        /// <returns></returns>
        public DropDownList GetDropDownList<T>(DropDownList ds)
        {
            foreach (int myCode in Enum.GetValues(typeof(T)))
            {
                //获取名称
                string strName = Enum.GetName(typeof(T), myCode);
                //获取值
                string strVaule = myCode.ToString();
                ds.Items.Add(new ListItem(strName, strVaule));
            }
            return ds;
        }
        /// <summary>
        /// 绑定DropDownList
        /// </summary>
        /// <param name="ds">DropDownList Name</param>
        /// <param name="dict">Dictionary Type</param>
        /// <param name="isBool"> true 请选择 false 无请选择</param>
        /// <returns>DropDownList</returns>
        public DropDownList GetDropDownList(DropDownList ds, Dictionary<int,string> dict,bool isBool)
        {
            if (isBool == true)
                ds.Items.Add(new ListItem("--请选择--", "0"));
            foreach (var model in dict)
            {
                ds.Items.Add(new ListItem(model.Value, model.Key.ToString()));
            }
            return ds;
        }
        /// <summary>
        /// 清除DropDownList
        /// </summary>
        /// <param name="ds"></param>
        public static void DropDownListClear(DropDownList ds)
        {
            ds.Items.Clear();
            ds.Items.Add(new ListItem("--请选择--", "0"));
        }

        /// <summary>
        /// 获取枚举的名称
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="vaule">vaule</param>
        /// <returns></returns>
        public static string GetEnumName<T>(string vaule)
        {
            string strName = string.Empty;
            foreach (int myCode in Enum.GetValues(typeof(T)))
            {
                if (vaule == myCode.ToString())
                {
                    strName = Enum.GetName(typeof(T), myCode);
                    break;
                }
            }
            return strName;
        }
    }
}
