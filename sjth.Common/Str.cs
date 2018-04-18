using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sjth.Common
{
    public class Str
    {
        public static string CreateFileUrl(int uploadCategory, string fileName, string extName)
        {
            return ("00" + uploadCategory.ToString("X2") + fileName + extName);
        }

        public static string GetRandomByTime(int digit, string format = "yyMMddHHmmss")
        {
            return (DateTime.Now.ToString(format) + GetRandom(digit).ToString());
        }

        public static int GetRandom(int digit)
        {
            Random random = new Random();
            return random.Next((int)Math.Pow(10.0, (double)digit));
        }

        public static string GetFileUrl(object objFileName)
        {
            string str3 = objFileName.ToString();

            return (str3.Substring(2, 2) + "/" + str3.Substring(4, 2) + "/" + str3.Substring(6, 2) + "/" + str3.Substring(8, 2) + "/" + str3);
        }
        public static string GetFileType(string objFileType)
        {
            if (objFileType.IndexOf(".") > -1)
            {
                return objFileType;
            }
            else
            {
                return "." + objFileType;
            }
        }
        public static string[] GetReg(string pattern, string input)
        {
            Match match = new Regex(pattern, RegexOptions.Singleline).Match(input);
            if (!match.Success)
            {
                return null;
            }
            string[] strArray = new string[match.Groups.Count - 1];
            for (int i = 1; i < match.Groups.Count; i++)
            {
                strArray[i - 1] = match.Groups[i].Value.Trim();
            }
            return strArray;
        }
    }
}
