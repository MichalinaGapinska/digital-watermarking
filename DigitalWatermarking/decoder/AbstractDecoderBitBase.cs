using System.Drawing;
using System.Drawing.Imaging;

namespace DigitalWatermarking.decoder
{
    public abstract class AbstractDecoderBitBase<T>
    {
        protected Bitmap _bitmap;
        private T _message;
        protected bool _isDecoded = false;

        protected AbstractDecoderBitBase(Bitmap bitmap)
        {
            _bitmap = (Bitmap) bitmap.Clone();
        }

        public T GetMessage()
        {
            return _isDecoded ? _message : GetEmptyMessage();
        }

        public void Decode()
        {

            var bitmapData1 = _bitmap.LockBits(new Rectangle(0, 0, _bitmap.Width, _bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                var imagePointer1 = (byte*) bitmapData1.Scan0;
                var position = 0;

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

            _isDecoded = true;
        }

        protected abstract unsafe void ProcessPixel(byte* pixelPointer);

        protected abstract T GetEmptyMessage();
    }
}