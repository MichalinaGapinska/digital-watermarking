using System;

namespace DigitalWatermarking.encoder
{
    public class LsbTextEncoder: AbstractEncoder<string>
    {
        protected override unsafe void ProcessPixel(byte* pixelPointer, int position, string message)
        {
            // throw new NotImplementedException();
            return;
        }
    }
}