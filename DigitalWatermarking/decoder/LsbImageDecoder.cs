using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace DigitalWatermarking.decoder
{
    public class LsbImageDecoder : AbstractDecoderBitBase<Bitmap>
    {
        private BitmapData _bitmapData;
        private unsafe byte* _bitmapDataPointer;

        public LsbImageDecoder(Bitmap bitmap) : base(bitmap)
        {
            Message = new Bitmap(bitmap.Width, bitmap.Height);
        }

        public new unsafe void Decode()
        {
            _bitmapData = Message.LockBits(new Rectangle(0, 0, Message.Width, Message.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            _bitmapDataPointer = (byte*) _bitmapData.Scan0;
            base.Decode();
            Message.UnlockBits(_bitmapData);
        }

        protected override unsafe void ProcessPixel(byte* pixelPointer)
        {
            if ((pixelPointer[0] & 1) != 1)
            {
                _bitmapDataPointer[0] = 255;
                _bitmapDataPointer[1] = 255;
                _bitmapDataPointer[2] = 255;
            }
            else
            {
                _bitmapDataPointer[0] = 0;
                _bitmapDataPointer[1] = 0;
                _bitmapDataPointer[2] = 0;
            }

            _bitmapDataPointer[3] = 255; // alpha

            _bitmapDataPointer += 4; //4 bytes per pixel
        }

        protected override Bitmap GetEmptyMessage()
        {
            throw new System.NotImplementedException();
        }
    }
}