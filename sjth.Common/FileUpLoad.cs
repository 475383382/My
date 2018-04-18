/************************************************************************ 
 * 项目名称 :  CA.Common   
 * 项目描述 :      
 * 类 名 称 :  FileUpLoad 
 * 版 本 号 :  v1.0.0.0  
 * 说    明 :      
 * 作    者 :  xuxiaokui 
 * 创建时间 :  2016/9/28 14:18:55 
 * 更新时间 :  2016/9/28 14:18:55 
************************************************************************ 
 * Copyright @ 莹和视兴 2016. All rights reserved. 
************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sjth.Common;

namespace sjth.Common
{
    public class FileUpLoad
    {
        //public List<string> File_Up_Load(string flist)
        //{
        //    //附件上传
        //    List<UploadFileInfo> listFile = new List<UploadFileInfo>();
        //    List<string> listReturn = new List<string>();
        //    if (!string.IsNullOrEmpty(flist))
        //    {
        //        List<FileJson> listFileJson = JsonConvert.DeserializeObject<List<FileJson>>(flist);
        //        List<FilePath> listFilePath = new List<FilePath>();
        //        Upload upload = new Upload();
        //        for (int i = 0; i < listFileJson.Count; i++)
        //        {
        //            //包含http是数据库原来有的文件
        //            if (!listFileJson[i].fileBase64.IsNullOrEmpty())
        //            {
        //                if (listFileJson[i].fileBase64.IndexOf("http:") == -1)
        //                {
        //                    FilePath filePath = new FilePath();
        //                    UploadFileInfo uploadFile = upload.UploadFile(listFileJson[i].fileBase64,
        //                        listFileJson[i].fileName, 1, filePath); //int.Parse(listFileJson[i].fileType)
        //                    listFile.Add(uploadFile);
        //                    listFilePath.Add(filePath);
        //                }
        //                else
        //                {
        //                    FilePath filePath = new FilePath();
        //                    UploadFileInfo uploadFile = upload.UpdateFile(listFileJson[i].fileName, fdt, filePath);
        //                    listFile.Add(uploadFile);
        //                    listFilePath.Add(filePath);
        //                }
        //            }
        //        }
        //        //删除图片
        //        if (fdt != null)
        //        {
        //            upload.DeleteFile(listFile, fdt);

        //        }
        //        if (listFile.Count > 0)
        //        {
        //            listReturn.Add(CA.Common.JsonHelper.JsonSerializer<List<UploadFileInfo>>(listFile));
        //            listReturn.Add(CA.Common.JsonHelper.JsonSerializer<List<FilePath>>(listFilePath));
        //        }
        //    }
        //    return listReturn;
        //}
    }
}
