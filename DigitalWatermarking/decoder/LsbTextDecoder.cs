using System.Collections;
using System.Drawing;
using System.Text;

namespace DigitalWatermarking.decoder
{
    public class LsbTextDecoder : AbstractDecoderBitBase<string>
    {
        private readonly BitArray _bitArray;
        private int _position;


        public LsbTextDecoder(Bitmap bitmap) : base(bitmap)
        {
            _bitArray = new BitArray(_bitmap.Height * _bitmap.Width * 3);
        }

        public new string GetMessage()
        {
            if (!_isDecoded)
            {
                return string.Empty;
            }

            var das = ToByteArray(_bitArray);

            var s = Encoding.ASCII.GetString(das);
            return s;
        }

        protected override unsafe void ProcessPixel(byte* pixelPointer)
        {
            for (var i = 0; i < 4; i++)
            {
                if (_position >= _bitArray.Length)
                {
                    return;
                }

                _bitArray[_position++] = ( pixelPointer[i] & 1) != 0;
            }
        }

        protected override string GetEmptyMessage()
        {
            return string.Empty;
        }


        private static byte[] ToByteArray(BitArray bits)
        {
            var numBytes = bits.Count / 8;
            if (bits.Count % 8 != 0) numBytes++;

            var bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (var i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    bytes[byteIndex] |= (byte) (1 << (bitIndex));

                bitIndex++;
                if (bitIndex != 8)
                {
                    continue;
                }

                bitIndex = 0;
                byteIndex++;
            }

            return bytes;
        }
    }
}