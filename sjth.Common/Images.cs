using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
namespace sjth.Common
{
    public class Images
    {
        public static Bitmap GetValidateCodeImage(string str)
        {
            if ((str == null) || (str.Trim() == string.Empty))
            {
                return null;
            }
            Bitmap image = new Bitmap((int)Math.Ceiling((double)(str.Length * 12.5)), 0x16);
            Graphics graphics = Graphics.FromImage(image);
            try
            {
                int num;
                Random random = new Random();
                graphics.Clear(Color.White);
                for (num = 0; num < 10; num++)
                {
                    int num2 = random.Next(image.Width);
                    int num3 = random.Next(image.Width);
                    int num4 = random.Next(image.Height);
                    int num5 = random.Next(image.Height);
                    graphics.DrawLine(new Pen(Color.Silver), num2, num4, num3, num5);
                }
                Font font = new Font("Arial", 12f, FontStyle.Italic | FontStyle.Bold);
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                graphics.DrawString(str, font, brush, (float)2f, (float)2f);
                for (num = 0; num < 0x19; num++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
            }
            catch
            {
            }
            return image;
        }

        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            Image image;
            if (originalImagePath.ToLower().StartsWith("http"))
            {
                WebClient client = new WebClient();
                MemoryStream stream = new MemoryStream(client.DownloadData(originalImagePath));
                image = Image.FromStream(stream);
            }
            else
            {
                image = Image.FromFile(originalImagePath);
            }
            int num = width;
            int num2 = height;
            int x = 0;
            int y = 0;
            int num5 = image.Width;
            int num6 = image.Height;
            string str2 = mode;
            if ((str2 != null) && (str2 != "HW"))
            {
                if (!(str2 == "W"))
                {
                    if (str2 == "H")
                    {
                        num = (image.Width * height) / image.Height;
                    }
                    else if (str2 == "Cut")
                    {
                        if ((((double)image.Width) / ((double)image.Height)) > (((double)num) / ((double)num2)))
                        {
                            num6 = image.Height;
                            num5 = (image.Height * num) / num2;
                            y = 0;
                            x = (image.Width - num5) / 2;
                        }
                        else
                        {
                            num5 = image.Width;
                            num6 = (image.Width * height) / num;
                            x = 0;
                            y = (image.Height - num6) / 2;
                        }
                    }
                }
                else
                {
                    num2 = (image.Height * width) / image.Width;
                }
            }
            Image image2 = new Bitmap(num, num2);
            Graphics graphics = Graphics.FromImage(image2);
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.Transparent);
            graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num5, num6), GraphicsUnit.Pixel);
            try
            {
                string path = thumbnailPath.Substring(0, thumbnailPath.LastIndexOf(@"\") + 1);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                image2.Save(thumbnailPath, ImageFormat.Jpeg);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
            }
        }
    }
}
