/*
 * RNCaptcha
 * 
 * version 1.0
 * 
 * Copyright (c) 2014, Roger Ngo <rogerngo90@gmail.com>
 * 
 * GPL License
 * http://www.gnu.org/licenses/gpl.html
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace RNCaptcha
{
    public class RNCaptcha
    {
        private int width;
        private int height;
        private int fontSize;
        private string answer;


        public RNCaptcha(string answer)
        {
            this.width = 192;
            this.height = 48;
            this.fontSize = 24;
            this.answer = answer;
        }

        public RNCaptcha(int width, int height, int fontSize, string answer)
        {
            this.width = width;
            this.height = height;
            this.fontSize = fontSize;
            this.answer = answer;
        }

        public static string GenerateRandomString()
        {
            string universe = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@$#%^&*";
            string result = "";

            Random rand = new Random();

            for (int i = 0; i < 8; i++)
            {
                int randomIndex = rand.Next(0, universe.Length - 1);

                result = result + universe.Substring(randomIndex, 1);
            }

            return result;
        }

        public static string GenerateMarkup(string captchaInput)
        {
            StringBuilder html = new StringBuilder();

            html.AppendFormat("<img src=\"data:image/png;base64,{0}\" />", captchaInput);

            return html.ToString();
        }

        public string GetCaptcha()
        {
            Bitmap bmp = new Bitmap(this.width, this.height);
            RectangleF rect = new RectangleF(8, 5, 0, 0);
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.FromArgb(240,240,240));
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            g.DrawString(this.answer, new Font("Tahoma", this.fontSize, FontStyle.Bold ^ FontStyle.Italic), Brushes.CornflowerBlue, rect);

            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                int x0 = rand.Next(0, this.width);
                int y0 = rand.Next(0, this.height);
                int x1 = rand.Next(0, this.width);
                int y1 = rand.Next(0, this.height);

                g.DrawLine(new Pen(Color.FromArgb(192, 75, 75, 75)), x0, y0, x1, y1);
            }


            for (int i = 0; i < 10; i++)
            {
                int x0 = rand.Next(0, this.width);
                int y0 = rand.Next(0, this.height);
                int x1 = rand.Next(0, this.width);
                int y1 = rand.Next(0, this.height);

                g.DrawLine(new Pen(Color.FromArgb(192, 125, 75, 255)), x0, y0, x1, y1);
            }

            MemoryStream mem = new MemoryStream();
            bmp.Save(mem, ImageFormat.Png);

            g.Dispose();
            bmp.Dispose();
            
            return Convert.ToBase64String(mem.ToArray());
        }


    }
}
