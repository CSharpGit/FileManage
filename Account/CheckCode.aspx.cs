using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_CheckCode : System.Web.UI.Page
{
    Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            //调用该方法实现的事数字和字符的效果
            //string str = getRandomValidate(4);
            //调用该方法实现的是验证码中数字和字母的组合
            string str = CreateRandomCode(4);
            Session["CheckCode"] = str;
            getImageValidate(str);
        }
        private string getRandomValidate(int len)
        {
            int num;
            int temp;
            string str = "";
            for (int i = 0; i < len; i++)
            {
                num = random.Next();
                //生成数字验证码
                temp = num % 10 + '0';
                //生成字符验证码
                temp = num % 10 + 'A';
                str += Convert.ToChar(temp).ToString();
            }
            return str;
        }

        //验证码是数字和字母的随机组合
        private string CreateRandomCode(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,Q,W,E,R,T,Y,U,I,O,P,A,S,D,F,G,H,J,K,L,Z,X,C,V,B,N,M";
            string[] allCharArray = allChar.Split(',');//Split()方法竟然返回数组？？？！！！！
            string randomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp!=-1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(35);
                if (temp==t)
                {
                    return CreateRandomCode(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }
        //生成图像
        private void getImageValidate(string strValue)
        {
            int width = Convert.ToInt32(strValue.Length * 14);
            Bitmap image = new Bitmap(width, 21);
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            
           
            //写验证码，定义字体样式
            Font font = new Font("Arial",15, FontStyle.Bold);
           
            System.Drawing.Drawing2D.LinearGradientBrush brush =
                new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width - 1, image.Height - 1),Color.Blue,Color.Purple,1.2f,true);
            g.DrawString(strValue, font, brush, -2, 0);
            drawLine(g, image);
            //将图片添加的页面
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            //更改HTTP头
            Response.ClearContent();
            Response.ContentType = "image/gif";
            Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            image.Dispose();
            Response.End();
        }
        private void drawPoint(Bitmap image)
        {
            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(random.Next()));//描绘随机杂点
            }
            //杂点颜色相同
            int color = random.Next();
            for (int i = 0; i < 20; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(color));
            }
        }
        //画线
        private void drawLine(Graphics g, Bitmap image)
        {
            for (int i = 0; i < 10; i++)
            {
                int x1 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int x2 = random.Next(image.Width);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }
        }
    }
