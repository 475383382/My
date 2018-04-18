using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace sjth.Common
{
    public class FFMpeg
    {
        private static string webPath = System.AppDomain.CurrentDomain.BaseDirectory;
        private static void _GetFlvImage(object o)
        {
            string[] strArray = o as string[];
            string path = strArray[0];
            string str2 = strArray[1];
            string str3 = "5";
            string str4 = "8";
            if (str2 != null)
            {
                str3 = str2;
                str4 = str2;
            }
            if (File.Exists(path))
            {
                string fileName = Path.Combine(webPath, @"ffmpeg\ffmpeg.exe");
                ProcessStartInfo info = new ProcessStartInfo(fileName)
                {
                    WindowStyle = ProcessWindowStyle.Normal
                };
                if (File.Exists(fileName))
                {
                    string str6 = Path.ChangeExtension(path, ".jpg");
                    info.Arguments = string.Format("-i \"{0}\" -y -f image2 -t {1} -ss {2} \"{3}\"", new object[] { path, str3, str4, str6 });
                    try
                    {
                        Process process = new Process
                        {
                            StartInfo = info
                        };
                        process.Start();
                        process.WaitForExit();
                        string thumbnailPath = Path.Combine(Path.GetDirectoryName(str6), "s" + Path.GetFileName(str6));
                        Images.MakeThumbnail(str6, thumbnailPath, 190, 0x84, "Cut");
                    }
                    catch
                    {
                    }
                }
            }
        }

        private static void _ParseFlv(object o)
        {
            string path = o.ToString();
            string fileName = Path.Combine(webPath, @"ffmpeg\ffmpeg.exe");
            ProcessStartInfo startInfo = new ProcessStartInfo(fileName)
            {
                WindowStyle = ProcessWindowStyle.Normal
            };
            if (File.Exists(fileName) && File.Exists(path))
            {
                string str3 = Path.ChangeExtension(path, ".flv");
                startInfo.Arguments = "-i " + path + " -ab 56 -ar 22050 -b 1200 -r 15 " + str3;
                try
                {
                    Process.Start(startInfo);
                }
                catch
                {
                }
            }
        }

        public static void GetFlvImage(string filePath, string time = null)
        {
            new Thread(new ParameterizedThreadStart(FFMpeg._GetFlvImage)).Start(new string[] { filePath, time });
        }

        public static void ParseFlv(string filePath)
        {
            new Thread(new ParameterizedThreadStart(FFMpeg._ParseFlv)).Start(filePath);
        }
    }
}
