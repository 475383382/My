using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace sjth.Common
{
    public class SerializeHelper
    {
        public readonly static SerializeHelper Instance = new SerializeHelper();

        /// <summary>
        /// 将C#数据实体转化为JSON数据
        /// </summary>
        /// <param name="obj">要转化的数据实体</param>
        /// <returns>JSON格式字符串</returns>
        public string JsonSerialize<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            stream.Position = 0;

            StreamReader sr = new StreamReader(stream);
            string resultStr = sr.ReadToEnd();
            sr.Close();
            stream.Close();

            return resultStr;
        }

        /// <summary>
        /// 将JSON数据转化为C#数据实体
        /// </summary>
        /// <param name="json">符合JSON格式的字符串</param>
        /// <returns>T类型的对象</returns>
        public T JsonDeserialize<T>(string json)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json.ToCharArray()));
            T obj = (T)serializer.ReadObject(ms);
            ms.Close();
            return obj;
        }
        public List<T> JSONStringToList<T>( string JsonStr)
        {

            JavaScriptSerializer Serializer = new JavaScriptSerializer();

            List<T> objs = Serializer.Deserialize<List<T>>(JsonStr);

            return objs;

        }
        public static string Obj2Json<T>(IList<T> data)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, data);
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch
            {
                return null;
            }
        }
        public static Object Json2Obj(String json, Type t)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(t);
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {

                    return serializer.ReadObject(ms);
                }
            }
            catch
            {
                return null;
            }
        }
         /// <summary>
          /// 将datatable转换为json  
          /// </summary>
          /// <param name="dtb">Dt</param>
          /// <returns>JSON字符串</returns>
          public static string Dtb2Json(DataTable dtb)
          {
              JavaScriptSerializer jss = new JavaScriptSerializer();
              System.Collections.ArrayList dic = new System.Collections.ArrayList();
             foreach (DataRow dr in dtb.Rows)
             {
                 List<string> drow = new List<string>();
                 foreach (DataColumn dc in dtb.Columns)
                 {
                     drow.Add(dr[dc.ColumnName].ToString());
                 }
                dic.Add(drow);
 
             }
             //序列化  
             return jss.Serialize(dic);
         }

    }
}