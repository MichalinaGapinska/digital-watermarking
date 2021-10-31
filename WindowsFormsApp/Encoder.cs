using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsFormsApp2
{
    public class Encoder
    {
        public Bitmap Encode(Bitmap bitmap, string message)
        {
            var byteArray = Utils.BitmapToByteArray(bitmap);
            var messageBits = new BitArray(Encoding.ASCII.GetBytes(message));


            for (int i = 0; i < Math.Min(byteArray.Length, messageBits.Length); i++)
            {
                byteArray[i] = messageBits[i] ? setOne(byteArray[i]) : setZero(byteArray[i]);
            }

            return Utils.ByteArrayToBitmap(byteArray, bitmap.Width, bitmap.Height);
        }

        byte setZero(byte b)
        {
            return (byte) (b & ~(1 << 0));
        }

        byte setOne(byte b)
        {
            return (byte) (b | (1 << 0));
        }

        static byte[] PadLines(byte[] bytes, int rows, int columns)
        {
            int currentStride = columns; // 3
            int newStride = columns; // 4
            byte[] newBytes = new byte[newStride * rows];
            for (int i = 0; i < rows; i++)
                Buffer.BlockCopy(bytes, currentStride * i, newBytes, newStride * i, currentStride);
            return newBytes;
        }
        
           
  
    }

    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }
    }
}