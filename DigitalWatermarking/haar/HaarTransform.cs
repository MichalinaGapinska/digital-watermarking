using System;
using System.Drawing;
using System.Drawing.Imaging;
using DigitalWatermarking.domain;

namespace DigitalWatermarking.haar
{
    public class HaarTransform
    {
        private const double W0 = 0.5;
        private const double W1 = -0.5;
        private const double S0 = 0.5;
        private const double S1 = 0.5;
        private const int PixelSize = 4;

        public Bitmap OriginalImage { get; set; }
        public Bitmap TransformedImage { get; set; }

        public ImageArrays<double> ImageArrays = new ImageArrays<double>();


        public void Prepare(bool forward, int iterations)
        {
            var bmp = forward ? new Bitmap(OriginalImage) : new Bitmap(TransformedImage);

            var maxScale = (int) (Math.Log(bmp.Width < bmp.Height ? bmp.Width : bmp.Height) / Math.Log(2));
            if (iterations < 1 || iterations > maxScale)
            {
                throw new Exception("Iteration must be Integer from 1 to " + maxScale);
            }

            ImageArrays.Red = new double[bmp.Width, bmp.Height];
            ImageArrays.Green = new double[bmp.Width, bmp.Height];
            ImageArrays.Blue = new double[bmp.Width, bmp.Height];

            var bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format32bppRgb);

            unsafe
            {
                for (var j = 0; j < bmData.Height; j++)
                {
                    var row = (byte*) bmData.Scan0 + (j * bmData.Stride);
                    for (var i = 0; i < bmData.Width; i++)
                    {
                        ImageArrays.Red[i, j] = (double) Scale(0, 255, -1, 1, row[i * PixelSize + 2]);
                        ImageArrays.Green[i, j] = (double) Scale(0, 255, -1, 1, row[i * PixelSize + 1]);
                        ImageArrays.Blue[i, j] = (double) Scale(0, 255, -1, 1, row[i * PixelSize]);
                    }
                }
            }
        }

        public unsafe void ApplyHaarTransform(bool forward, int iterations)
        {
            var bmp = new Bitmap(OriginalImage.Width, OriginalImage.Height);
            var bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format32bppRgb);

            if (forward)
            {
                FWT(ImageArrays.Red, iterations);
                FWT(ImageArrays.Green, iterations);
                FWT(ImageArrays.Blue, iterations);
            }
            else
            {
                IWT(ImageArrays.Red, iterations);
                IWT(ImageArrays.Green, iterations);
                IWT(ImageArrays.Blue, iterations);
            }

            for (var j = 0; j < bmData.Height; j++)
            {
                var row = (byte*) bmData.Scan0 + (j * bmData.Stride);
                for (var i = 0; i < bmData.Width; i++)
                {
                    row[i * PixelSize + 2] = (byte) Scale(-1, 1, 0, 255, ImageArrays.Red[i, j]);
                    row[i * PixelSize + 1] = (byte) Scale(-1, 1, 0, 255, ImageArrays.Green[i, j]);
                    row[i * PixelSize] = (byte) Scale(-1, 1, 0, 255, ImageArrays.Blue[i, j]);
                }
            }

            bmp.UnlockBits(bmData);

            if (forward)
            {
                TransformedImage = new Bitmap(bmp);
            }
            else
            {
                OriginalImage = new Bitmap(bmp);
            }
        }


        /// <summary>
        ///   Discrete Haar Wavelet Transform
        /// </summary>
        /// TODO: Daubechies 
        private static void Fwt(double[] data)
        {
            var temp = new double[data.Length];

            var h = data.Length >> 1; // divide by 2
            for (var i = 0; i < h; i++)
            {
                var k = (i << 1); // multiply by 2
                temp[i] = data[k] * S0 + data[k + 1] * S1;
                temp[i + h] = data[k] * W0 + data[k + 1] * W1;
        // private const double W0 = 0.5;
        // private const double W1 = -0.5;
        // private const double S0 = 0.5;
        // private const double S1 = 0.5;
            }

            for (var i = 0; i < data.Length; i++)
                data[i] = temp[i];
        }

        /// <summary>
        ///   Discrete Haar Wavelet 2D Transform
        /// </summary>
        /// 
        // ReSharper disable once InconsistentNaming
        private void FWT(double[,] data, int iterations)
        {
            var rows = data.GetLength(0);
            var cols = data.GetLength(1);

            var row = new double[cols];
            var col = new double[rows];

            for (var k = 0; k < iterations; k++)
            {
                for (var i = 0; i < rows; i++)
                {
                    for (var j = 0; j < row.Length; j++)
                        row[j] = data[i, j];

                    Fwt(row);

                    for (var j = 0; j < row.Length; j++)
                        data[i, j] = row[j];
                }

                for (var j = 0; j < cols; j++)
                {
                    for (var i = 0; i < col.Length; i++)
                        col[i] = data[i, j];

                    Fwt(col);

                    for (var i = 0; i < col.Length; i++)
                        data[i, j] = col[i];
                }
            }
        }

        /// <summary>
        ///   Inverse Haar Wavelet Transform
        /// </summary>
        /// 
        // ReSharper disable once InconsistentNaming
        private void IWT(double[] data)
        {
            double[] temp = new double[data.Length];

            int h = data.Length >> 1;
            for (int i = 0; i < h; i++)
            {
                int k = (i << 1);
                temp[k] = (data[i] * S0 + data[i + h] * W0) / W0;
                temp[k + 1] = (data[i] * S1 + data[i + h] * W1) / S0;
            }

            for (int i = 0; i < data.Length; i++)
                data[i] = temp[i];
        }

        /// <summary>
        ///   Inverse Haar Wavelet 2D Transform
        /// </summary>
        /// 
        // ReSharper disable once InconsistentNaming
        private void IWT(double[,] data, int iterations)
        {
            var rows = data.GetLength(0);
            var cols = data.GetLength(1);

            var col = new double[rows];
            var row = new double[cols];

            for (var l = 0; l < iterations; l++)
            {
                for (var j = 0; j < cols; j++)
                {
                    for (var i = 0; i < row.Length; i++)
                        col[i] = data[i, j];

                    IWT(col);

                    for (var i = 0; i < col.Length; i++)
                        data[i, j] = col[i];
                }

                for (var i = 0; i < rows; i++)
                {
                    for (var j = 0; j < row.Length; j++)
                        row[j] = data[i, j];

                    IWT(row);

                    for (var j = 0; j < row.Length; j++)
                        data[i, j] = row[j];
                }
            }
        }

        private static double Scale(double fromMin, double fromMax, double toMin, double toMax, double x)
        {
            if (fromMax - fromMin == 0) return 0;
            var value = (toMax - toMin) * (x - fromMin) / (fromMax - fromMin) + toMin;
            if (value > toMax)
            {
                value = toMax;
            }

            if (value < toMin)
            {
                value = toMin;
            }

            return value;
        }
    }
}