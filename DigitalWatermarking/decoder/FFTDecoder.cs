using DigitalWatermarking.fourier;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DigitalWatermarking.encoder
{
    public class FFTDecoder
    {
        public string DecodedMessage { get; private set; }
        public string AccuracyInfo { get; private set; }


        public void DecodeImage(Bitmap encodedBitmap, Bitmap originalImage, String message)
        {
            var fft = new FFT(encodedBitmap);
            var fftOriginal = new FFT(originalImage);

            fft.ForwardFFT();
            fftOriginal.ForwardFFT();
            fft.FFTShift();
            fftOriginal.FFTShift();

            fftOriginal.Output = fftOriginal.FFTShifted;
            fftOriginal.FFTShift();
            fftOriginal.InverseFFT(fftOriginal.FFTShifted);
            fftOriginal.ForwardFFT();
            fftOriginal.FFTShift();

            var magnitude = fft.FFTShifted;
            var magnitudeOriginal = fftOriginal.FFTShifted;

            int d1 = fft.Width / 3;
            int d2 = fft.Height / 3;
            var byteMessage = new BitArray(Encoding.ASCII.GetBytes(message));
            var bitArray = new BitArray(byteMessage.Length);
            var bitArray2 = new BitArray(byteMessage.Length);
            var bitArray3 = new BitArray(byteMessage.Length);
            var bitArray4 = new BitArray(byteMessage.Length);
            var resBitArray = new BitArray(byteMessage.Length);

            int pos = 0;
            for (int c = d1; c < Math.Min(d1 + byteMessage.Length, fft.Width); c++)
            {
                var v1 = magnitudeOriginal[c, d2].real;
                var v2 = magnitude[c, d2].real;
                int counter = 0;
                if (Math.Abs(v2) < Math.Abs(v1) || v2 == v1)
                {
                    bitArray[pos] = false;
                }
                else
                {
                    bitArray[pos] = true;
                    counter++;
                }
                v1 = magnitudeOriginal[c, d2 * 2].real;
                v2 = magnitude[c, d2 * 2].real;
                if (Math.Abs(v2) < Math.Abs(v1) || v2 == v1)
                {
                    bitArray2[pos] = false;
                }
                else
                {
                    bitArray2[pos] = true;
                    counter++;
                }
                v1 = magnitudeOriginal[c + d1, d2].real;
                v2 = magnitude[c + d1, d2].real;
                if (Math.Abs(v2) < Math.Abs(v1) || v2 == v1)
                {
                    bitArray3[pos] = false;
                }
                else
                {
                    bitArray3[pos] = true;
                    counter++;
                }
                v1 = magnitudeOriginal[c + d1, d2 * 2].real;
                v2 = magnitude[c + d1, d2 * 2].real;
                if (Math.Abs(v2) < Math.Abs(v1) || v2 == v1)
                {
                    bitArray4[pos] = false;
                }
                else
                {
                    bitArray4[pos] = true;
                    counter++;
                }
                resBitArray[pos] = counter > 2;
                pos++;
            }

            double diff = 0;
            for (int i = 0; i < bitArray.Length; i++)
                if (resBitArray[i] != byteMessage[i])
                    diff++;

            AccuracyInfo = $"Wrong bits: {diff} - {Math.Round(diff / bitArray.Length,2) * 100}%";
            var das = ToByteArray(resBitArray);

            var segment = das.Take(8000).ToArray();

            DecodedMessage = Encoding.ASCII.GetString(segment);
        }

        private static IEnumerable<byte> ToByteArray(BitArray bits)
        {
            var numBytes = bits.Count / 8;
            if (bits.Count % 8 != 0) numBytes++;

            var bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (var i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    bytes[byteIndex] |= (byte)(1 << (bitIndex));

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