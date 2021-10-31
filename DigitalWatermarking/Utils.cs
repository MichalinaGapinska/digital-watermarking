using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace DigitalWatermarking
{
    public class Utils
    {
        public static byte[] BitmapToByteArray(Bitmap img)      //img is the input image. Image width and height in pixels. PixelFormat is 24 bit per pixel in this case
        {
            BitmapData bmpData=img.LockBits(new Rectangle(0,0,img.Width,img.Height),ImageLockMode.ReadOnly,img.PixelFormat);    //define and lock the area of the picture with rectangle
            int pixelbytes =Image.GetPixelFormatSize(img.PixelFormat) / 8;     //for 24 bpp the value of pixelbytes is 3, for 32 bpp is 4, for 8 bpp is 1
            IntPtr ptr=bmpData.Scan0;      //this is a memory address, where the bitmap starts
            Int32 psize = bmpData.Stride * bmpData.Height;      // picture size in bytes
            byte[] byOut=new byte[psize];     //create the output byte array, which size is obviously the same as the input one

            Marshal.Copy(ptr, byOut, 0, psize);      //this is a very fast method, which copies the memory content to byteOut array, but implemented for 24 bpp pictures only
            img.UnlockBits(bmpData);      //release the locked memory
            return byOut;      //  e finita la commedia
        }



        //convert byte array to bitmap
        
        public static Bitmap ByteArrayToBitmap(byte[] byteIn, int imwidth, int imheight)     // byteIn the input byte array. Picture size should be known
        {
            Bitmap picOut=new Bitmap(imwidth,imheight,PixelFormat.Format24bppRgb);  //define the output picture
            BitmapData bmpData = picOut.LockBits(new Rectangle(0, 0, imwidth, imheight), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            IntPtr ptr=bmpData.Scan0;
            Int32 psize =   bmpData.Stride*imheight;
            Marshal.Copy(byteIn,0,ptr,psize);
            picOut.UnlockBits(bmpData);
            return picOut;      //  e finita la commedia
        }
    }
}