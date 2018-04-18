using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
namespace sjth.Common
{
    public class FlashPrinter
    {
        private static string webPath;

        private static void _ParseSwf(object o)
        {
            try
            {
                string path = o.ToString();
                string fileName = Path.Combine(webPath, @"FlashPrinter\FlashPrinter.exe");
                //HLog.WriteOperateErrorLog(fileName);
                ProcessStartInfo startInfo = new ProcessStartInfo(fileName)
                {
                    WindowStyle = ProcessWindowStyle.Normal
                };
                if (File.Exists(fileName) && File.Exists(path))
                {
                    string str3 = Path.ChangeExtension(path, ".swf");
                    //HLog.WriteOperateErrorLog(fileName + " " + path + " -o " + str3);
                    startInfo.Arguments = " " + path + " -o " + str3;
                    Process.Start(startInfo);
                }
            }
            catch (Exception ex)
            {
                //HLog.WriteOperateErrorLog("{0}\r\n{1}\r\n{2}".FormatResult(ex.ToNullString(), ex.Message, ex.StackTrace));
            }
        }

        public static void ParseSwf(string filePath)
        {
            //webPath = PageBase.WebPath;
            new Thread(new ParameterizedThreadStart(FlashPrinter._ParseSwf)).Start(filePath);
        }
    }
}
