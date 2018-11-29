using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ZXing.QrCode;

namespace ServiceCore.Helpers
{
    public class QRCodeHelper
    {
        //创建二维码
        public static void CreateQRCode(string fileName, string content, int height, int width, int margin)
        {
            var qrCodeWriter = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions { Height = height, Width = width, Margin = margin }
            };

            var pixelData = qrCodeWriter.Write(content);
            using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            using (var ms = new MemoryStream())
            {

                var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height),
                    System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                try
                {
                    // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image
                    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0,
                        pixelData.Pixels.Length);
                }
                finally
                {
                    bitmap.UnlockBits(bitmapData);
                }
                // save to stream as PNG
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
        public static void CreateQRCode(string fileName, string content)
        {
            CreateQRCode(fileName, content, 200, 200, 0);
        }
    }
}
