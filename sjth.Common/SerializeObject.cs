using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace sjth.Common
{
    /// <summary>
    ///SerializeObject 的摘要说明
    /// </summary>
    public class SerializeObject
    {
        public SerializeObject()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public static string GetSerializeString(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            byte[] result = new byte[ms.Length];
            result = ms.ToArray();
            string temp = System.Convert.ToBase64String(result);
            ms.Flush();
            ms.Close();
            return temp;
        }

        public static object GetSerializeObject(string str)
        {
            byte[] b = System.Convert.FromBase64String(str);
            MemoryStream ms = new MemoryStream(b, 0, b.Length);
            BinaryFormatter bf = new BinaryFormatter();
            object obj = bf.Deserialize(ms);
            ms.Flush();
            ms.Close();
            return obj;
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

    }
}
