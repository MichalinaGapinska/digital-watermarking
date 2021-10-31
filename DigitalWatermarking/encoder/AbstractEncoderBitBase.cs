using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;

namespace DigitalWatermarking.encoder
{
    public abstract class AbstractEncoder<T>
    {
        public Bitmap Encode(Bitmap image, T message)
        {
            var clone = (Bitmap) image.Clone();

            var bitmapData1 = clone.LockBits(new Rectangle(0, 0, clone.Width, clone.Height),
                ImageLockMode.ReadWrite, clone.PixelFormat);

            unsafe
            {
                var imagePointer1 = (byte*) bitmapData1.Scan0;
                var position = 0;

                for (var i = 0; i < bitmapData1.Height; i++)
                {
                    for (var j = 0; j < bitmapData1.Width; j++)
                    {
                        ProcessPixel(imagePointer1, position++, message);
                        imagePointer1 += 4; //4 bytes per pixel
                    }

                    imagePointer1 += bitmapData1.Stride - (bitmapData1.Width * 4); //4 bytes per pixel
                }
            }

            return clone;
        }

        protected abstract unsafe void ProcessPixel(byte* pixelPointer, int position, T message);
    }
}