using DigitalWatermarking.fourier;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DigitalWatermarking.encoder
{
    public class FFTColorDecoder
    {
        public string DecodedMessage { get; private set; }
        public string AccuracyInfo { get; private set; }


        public void DecodeImage(Bitmap encodedBitmap, Bitmap originalImage, String message)
        {
            var fft = new FFTColor(encodedBitmap);
            var fftOriginal = new FFTColor(originalImage);

            fft.ForwardFFT();
            fftOriginal.ForwardFFT();
            fft.FFTShift();
            fftOriginal.FFTShift();

            fftOriginal.ROutput = fftOriginal.RFFTShifted;
            fftOriginal.GOutput = fftOriginal.GFFTShifted;
            fftOriginal.BOutput = fftOriginal.BFFTShifted;
            fftOriginal.AlphaOutput = fftOriginal.AlphaFFTShifted;
            fftOriginal.FFTShift();
            fftOriginal.BFourier = fftOriginal.BFFTShifted;
            fftOriginal.RFourier = fftOriginal.RFFTShifted;
            fftOriginal.GFourier = fftOriginal.GFFTShifted;
            fftOriginal.AlphaFourier = fftOriginal.AlphaFFTShifted;
            fftOriginal.InverseFFT();
            fftOriginal.ForwardFFT();
            fftOriginal.FFTShift();
            var byteMessage = new BitArray(Encoding.ASCII.GetBytes(message));
            var bitArray = new BitArray(byteMessage.Length);
            var resBitArray = new BitArray(byteMessage.Length);

            var RRes = DecodeLayer(fft.RFFTShifted, fftOriginal.RFFTShifted, message);
            var GRes = DecodeLayer(fft.GFFTShifted, fftOriginal.GFFTShifted, message);
            var BRes = DecodeLayer(fft.BFFTShifted, fftOriginal.BFFTShifted, message);
            for (int i = 0; i < RRes.Length; i++)
            {
                if ((RRes[i] > 2 ? 1 : 0) + (GRes[i] > 2 ? 1 : 0) + (BRes[i] > 2 ? 1 : 0) >= 2)
                    resBitArray[i] = true;
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

        private int[] DecodeLayer(COMPLEX[,] magnitude, COMPLEX[,] magnitudeOriginal, String message)
        {
            int d1 = magnitude.GetLength(0) / 3;
            int d2 = magnitude.GetLength(1) / 3;
            var byteMessage = new BitArray(Encoding.ASCII.GetBytes(message));
            var bitArray = new BitArray(byteMessage.Length);
            var bitArray2 = new BitArray(byteMessage.Length);
            var bitArray3 = new BitArray(byteMessage.Length);
            var bitArray4 = new BitArray(byteMessage.Length);
            var resBitArray = new int [byteMessage.Length];

            int pos = 0;
            for (int c = d1; c < Math.Min(d1 + byteMessage.Length, magnitude.GetLength(0)); c++)
            {
                var v1 = magnitudeOriginal[c, d2].Magnitude();
                var v2 = magnitude[c, d2].Magnitude();
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
                v1 = magnitudeOriginal[c, d2 * 2].Magnitude();
                v2 = magnitude[c, d2 * 2].Magnitude();
                if (Math.Abs(v2) < Math.Abs(v1) || v2 == v1)
                {
                    bitArray2[pos] = false;
                }
                else
                {
                    bitArray2[pos] = true;
                    counter++;
                }
                v1 = magnitudeOriginal[c + d1, d2].Magnitude();
                v2 = magnitude[c + d1, d2].Magnitude();
                if (Math.Abs(v2) < Math.Abs(v1) || v2 == v1)
                {
                    bitArray3[pos] = false;
                }
                else
                {
                    bitArray3[pos] = true;
                    counter++;
                }
                v1 = magnitudeOriginal[c + d1, d2 * 2].Magnitude();
                v2 = magnitude[c + d1, d2 * 2].Magnitude();
                if (Math.Abs(v2) < Math.Abs(v1) || v2 == v1)
                {
                    bitArray4[pos] = false;
                }
                else
                {
                    bitArray4[pos] = true;
                    counter++;
                }
                resBitArray[pos] = counter;
                pos++;
            }

            return resBitArray;
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