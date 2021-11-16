using DigitalWatermarking.fourier;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DigitalWatermarking.encoder
{
    public class FFTEncoder
    {
        private readonly Bitmap _originalImage;
        public Bitmap GreyOriginalImage { get; private set; }
        private readonly string _message;
        private static readonly double _oneFactore = 1.5;
        private static readonly double _zeroFactore = 0.8;

        public Bitmap EncodedImage { get; private set; }
        public Bitmap MagnitudePlotImage { get; private set; }
        public FFTEncoder(Bitmap bitmap, string message)
        {
            _originalImage = bitmap;
            var fft = new FFT(_originalImage);
            fft.ForwardFFT();
            fft.InverseFFT();
            GreyOriginalImage = fft.Obj;
            _message = message;
        }

        public void EncodeMessage()
        {
            var fft = new FFT(GreyOriginalImage);

            fft.ForwardFFT();
            fft.FFTShift();

            var magnitude = fft.FFTShifted;

            int d1 = fft.Width / 3;
            int d2 = fft.Height / 3;
            var byteMessage = new BitArray(Encoding.ASCII.GetBytes(_message));
            int pos = 0;
           
            for (int c = d1; c < Math.Min(d1 + byteMessage.Length, fft.Width); c++)
            {
                if (!byteMessage[pos])
                {
                    magnitude[c, d2].real *= _zeroFactore;
                    magnitude[c, d2 * 2].real *= _zeroFactore;
                    magnitude[c + d1, d2].real *= _zeroFactore;
                    magnitude[c + d1, d2 * 2].real *= _zeroFactore;
                }
                else
                {
                    magnitude[c, d2].real *= _oneFactore;
                    magnitude[c, d2 * 2].real *= _oneFactore;
                    magnitude[c + d1, d2].real *= _oneFactore;
                    magnitude[c + d1, d2 * 2].real *= _oneFactore;
                }
                pos++;
            }

            //reverse
            fft.Output = magnitude;
            fft.FFTPlot();
            MagnitudePlotImage = fft.PhasePlot;
            fft.FFTShift();
            fft.InverseFFT(fft.FFTShifted);

            EncodedImage = fft.Obj;
        }
    }
}