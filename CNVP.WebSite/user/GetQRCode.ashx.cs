using System;
using System.Collections.Generic;
using System.Web;

namespace CNVP.WebSite.user
{
    using System.Drawing;
    using System.Drawing.Drawing2D;

    using MessagingToolkit.QRCode.Codec;

    /// <summary>
    /// GetQRCode 的摘要说明
    /// </summary>
    public class GetQRCode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String data = context.Request["t"];
            if (!string.IsNullOrEmpty(data))
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 8;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                System.Drawing.Image image = qrCodeEncoder.Encode(data);
                System.IO.MemoryStream MStream = new System.IO.MemoryStream();
                image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png);

                System.IO.MemoryStream MStream1 = new System.IO.MemoryStream();
                CombinImage(image, context.Server.MapPath("~/images/iconappli1.png")).Save(MStream1, System.Drawing.Imaging.ImageFormat.Png);
                context.Response.ClearContent();
                context.Response.ContentType = "image/png";
                context.Response.BinaryWrite(MStream1.ToArray());
                MStream.Dispose();
                MStream1.Dispose();
            }
            context.Response.Flush();
            context.Response.End();
        }

        /// <summary>  
        /// 调用此函数后使此两种图片合并，类似相册，有个  
        /// 背景图，中间贴自己的目标图片  
        /// </summary>  
        /// <param name="imgBack">粘贴的源图片  
        /// <param name="destImg">粘贴的目标图片  
        public static Image CombinImage(Image imgBack, string destImg)
        {
            Image img = Image.FromFile(destImg);        //照片图片    
            if (img.Height != 65 || img.Width != 65)
            {
                img = KiResizeImage(img, 65, 65, 0);
            }
            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);   

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框  

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);  

            //g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            GC.Collect();
            return imgBack;
        }


        /// <summary>  
        /// Resize图片  
        /// </summary>  
        /// <param name="bmp">原始Bitmap  
        /// <param name="newW">新的宽度  
        /// <param name="newH">新的高度  
        /// <param name="Mode">保留着，暂时未用  
        /// <returns>处理以后的图片</returns>  
        public static Image KiResizeImage(Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量  
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}