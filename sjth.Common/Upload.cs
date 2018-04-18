/************************************************************************ 
 * 项目名称 :  CA.Common   
 * 项目描述 :      
 * 类 名 称 :  Upload 
 * 版 本 号 :  v1.0.0.0  
 * 说    明 :      
 * 作    者 :  xuxiaokui 
 * 创建时间 :  2016/9/28 14:46:52 
 * 更新时间 :  2016/9/28 14:46:52 
************************************************************************ 
 * Copyright @ 莹和视兴 2016. All rights reserved. 
************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;

namespace sjth.Common
{
    public class Upload
    {
        private const string illegal = ".asp|.aspx|.php|.jsp|.html|.htm|.cgi|.cer|.cdx|.htr|.shtm|.shtml|.exe|.dll|.bat";
        private string webPath = System.Configuration.ConfigurationManager.AppSettings["webPath"];

        [WebMethod]
        public string UploadFile(string base64str, string fFileName, int fuploadCategory)
        {
            string extName = Path.GetExtension(fFileName).ToLower();    // 文件的扩展名
            string fileName = Str.CreateFileUrl(fuploadCategory, Str.GetRandomByTime(5), extName);         // 根据当前配置构造的文件名
            string path = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["UploadPath"]) + "\\" + Str.GetFileUrl(fileName); 
            string directory = Path.GetDirectoryName(path);         // 目录

            // 目录不存在，创建目录
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            bool flag = ImageHelper.StringToFile(base64str, path);

            return "/upload/" + Str.GetFileUrl(fileName);
        }
    }
}
