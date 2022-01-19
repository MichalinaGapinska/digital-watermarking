using DigitalWatermarking.fourier;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DigitalWatermarking.encoder
{
    public class SinColorEncoder
    {
        private readonly BitArray _messageInBit;
        public Bitmap OriginalImage { get; private set; }
        private readonly string _message;
        private static readonly double _oneFactore = 1.5;
        private static readonly double _zeroFactore = 0.8;

        public Bitmap EncodedImage { get; private set; }
        public Bitmap MagnitudePlotImage { get; private set; }
        public SinColorEncoder(Bitmap bitmap, string message)
        {
            var bytes = System.Text.Encoding.Default.GetBytes(message);
            OriginalImage = bitmap;
            _messageInBit = new BitArray(bytes);
            _message = message;
        }

        public void EncodeMessage()
        {
            var fft = new FFTColor(OriginalImage);

            fft.ForwardFFT();
            fft.FFTShift();

            int d1 = fft.Width / 3;
            int d2 = fft.Height / 3;
            var byteMessage = new BitArray(Encoding.ASCII.GetBytes(_message));
            int pos = 0;
           
            for (int c = d1; c < Math.Min(d1 + byteMessage.Length, fft.Width-1); c++)
            {
                if (!byteMessage[pos])
                {
                    fft.RFFTShifted[c, d2].imag *= _zeroFactore;
                    fft.RFFTShifted[c, d2 * 2].imag *= _zeroFactore;
                    fft.RFFTShifted[c + d1, d2].imag *= _zeroFactore;
                    fft.RFFTShifted[c + d1, d2 * 2].imag *= _zeroFactore;

                    fft.GFFTShifted[c, d2].imag *= _zeroFactore;
                    fft.GFFTShifted[c, d2 * 2].imag *= _zeroFactore;
                    fft.GFFTShifted[c + d1, d2].imag *= _zeroFactore;
                    fft.GFFTShifted[c + d1, d2 * 2].imag *= _zeroFactore;

                    fft.BFFTShifted[c, d2].imag *= _zeroFactore;
                    fft.BFFTShifted[c, d2 * 2].imag *= _zeroFactore;
                    fft.BFFTShifted[c + d1, d2].imag *= _zeroFactore;
                    fft.BFFTShifted[c + d1, d2 * 2].imag *= _zeroFactore;
                }
                else
                {
                    fft.RFFTShifted[c, d2].imag *= _oneFactore;
                    fft.RFFTShifted[c, d2 * 2].imag *= _oneFactore;
                    fft.RFFTShifted[c + d1, d2].imag *= _oneFactore;
                    fft.RFFTShifted[c + d1, d2 * 2].imag *= _oneFactore;

                    fft.GFFTShifted[c, d2].imag *= _oneFactore;
                    fft.GFFTShifted[c, d2 * 2].imag *= _oneFactore;
                    fft.GFFTShifted[c + d1, d2].imag *= _oneFactore;
                    fft.GFFTShifted[c + d1, d2 * 2].imag *= _oneFactore;

                    fft.BFFTShifted[c, d2].imag *= _oneFactore;
                    fft.BFFTShifted[c, d2 * 2].imag *= _oneFactore;
                    fft.BFFTShifted[c + d1, d2].imag *= _oneFactore;
                    fft.BFFTShifted[c + d1, d2 * 2].imag *= _oneFactore;

                }
                pos++;
            }

            //reverse
            fft.ROutput = fft.RFFTShifted;
            fft.GOutput = fft.GFFTShifted;
            fft.BOutput = fft.BFFTShifted;
            fft.AlphaOutput = fft.AlphaFFTShifted;
            fft.FFTShift();
            fft.BFourier = fft.BFFTShifted;
            fft.RFourier = fft.RFFTShifted;
            fft.GFourier = fft.GFFTShifted;
            fft.AlphaFourier = fft.AlphaFFTShifted;
            fft.InverseFFT();

            EncodedImage = fft.Obj;
        }
    }
}