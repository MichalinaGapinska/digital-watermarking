using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace DigitalWatermarking.encoder
{
    public class LsbImageEncoder : AbstractBitBaseEncoder<Bitmap>
    {
        public Bitmap PreparedImage { get; private set; }
        private BitmapData _bitmapData;
        private int _position;
        private unsafe byte* _bitmapDataPointer;

        public LsbImageEncoder(Bitmap bitmap, Bitmap message) : base(bitmap, message)
        {
            PrepareMessageImage();
        }

        public new unsafe void Encode()
        {
            _bitmapData = PreparedImage.LockBits(new Rectangle(0, 0, PreparedImage.Width, PreparedImage.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            _bitmapDataPointer = (byte*) _bitmapData.Scan0;

            base.Encode();
            PreparedImage.UnlockBits(_bitmapData);
        }


        protected override unsafe void ProcessPixel(byte* pixelPointer)
        {
            var sumOfPixels = _bitmapDataPointer[0] + _bitmapDataPointer[1] + _bitmapDataPointer[2];
            pixelPointer[0] = sumOfPixels < 300 ? SetOne(pixelPointer[0]) : SetZero(pixelPointer[0]); // black -> 1, white -> 0
            _bitmapDataPointer += 4; //4 bytes per pixel

        }

        private void PrepareMessageImage()
        {
            var tBrush = new TextureBrush(Message);
            PreparedImage = new Bitmap(OutBitmap.Width, OutBitmap.Height);
            var g = Graphics.FromImage(PreparedImage);
            g.FillRectangle(tBrush, new Rectangle(0, 0, PreparedImage.Width, PreparedImage.Height));
        }
    }
}