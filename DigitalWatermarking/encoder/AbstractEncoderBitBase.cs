using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;

namespace DigitalWatermarking.encoder
{
    public abstract class AbstractBitBaseEncoder<T>
    {
        private bool _encoded = false;

        public T Message { get; set; }

        protected Bitmap OutBitmap { get; set; }

        public Bitmap GetEncoded()
        {
            return !_encoded ? null : OutBitmap;
        }

        protected AbstractBitBaseEncoder(Bitmap bitmap, T message)
        {
            OutBitmap = (Bitmap) bitmap.Clone();
            Message = message;
        }

        public void Encode()
        {
            var bitmapData1 = OutBitmap.LockBits(new Rectangle(0, 0, OutBitmap.Width, OutBitmap.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            unsafe
            {
                var imagePointer1 = (byte*) bitmapData1.Scan0;

                for (var i = 0; i < bitmapData1.Height; i++)
                {
                    for (var j = 0; j < bitmapData1.Width; j++)
                    {
                        ProcessPixel(imagePointer1);
                        imagePointer1 += 4; //4 bytes per pixel
                    }

                    imagePointer1 += bitmapData1.Stride - (bitmapData1.Width * 4); //4 bytes per pixel
                }
            }

            _encoded = true;
            OutBitmap.UnlockBits(bitmapData1);
        }

        protected abstract unsafe void ProcessPixel(byte* pixelPointer);


        protected byte SetZero(byte b)
        {
            return (byte) (b & ~(1 << 0));
        }

        protected byte SetOne(byte b)
        {
            return (byte) (b | (1 << 0));
        }
    }
}