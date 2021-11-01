using System.Collections;
using System.Drawing;

namespace DigitalWatermarking.encoder
{
    public class LsbTextEncoder : AbstractEncoder<string>
    {
        private readonly BitArray _messageInBit;
        private int _position;

        public LsbTextEncoder(Bitmap bitmap, string message) : base(bitmap, message)
        {
            var bytes = System.Text.Encoding.Default.GetBytes(message);
            _messageInBit = new BitArray(bytes);
        }

        protected override unsafe void ProcessPixel(byte* pixelPointer)
        {
            // pixelPointer[0] = 255; // b
            // pixelPointer[1] = 255; // g
            // pixelPointer[2] = 255; // r
            // pixelPointer[3] = 255; // a

            for (var i = 0; i < 4; i++)
            {
                if (_position >= _messageInBit.Length)
                {
                    return;
                }
                // pixelPointer[i] = 100;
                pixelPointer[i] = _messageInBit[_position++] ? SetOne(pixelPointer[i]) : SetZero(pixelPointer[i]);
            }
        }
    }
}