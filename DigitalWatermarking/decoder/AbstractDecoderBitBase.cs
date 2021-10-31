using System.Drawing;
using System.Drawing.Imaging;

namespace DigitalWatermarking.decoder
{
    public abstract class AbstractDecoderBitBase<T>
    {
        public T Encode(Bitmap image)
        {
            var clone = (Bitmap) image.Clone();
            var message = GetEmptyMessage();

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
                        message = ProcessPixel(imagePointer1, position++, message);
                        imagePointer1 += 4; //4 bytes per pixel
                    }

                    imagePointer1 += bitmapData1.Stride - (bitmapData1.Width * 4); //4 bytes per pixel
                }
            }

            return message;
        }

        protected abstract unsafe T ProcessPixel(byte* pixelPointer, int position, T message);

        protected abstract T GetEmptyMessage();
    }
}