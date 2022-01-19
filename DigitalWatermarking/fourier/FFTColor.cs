using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace DigitalWatermarking.fourier
{

    class FFTColor
    {
        public Bitmap Obj; // Input Object Image
        public Bitmap FourierPlot; // Generated Fouruer Magnitude Plot
        public Bitmap PhasePlot; // Generated Fourier Phase Plot

        public int[,] BImage;
        public int[,] GImage;
        public int[,] RImage;
        public int[,] AlphaImage;
        public float[,] FourierMagnitude;
        public float[,] FourierPhase;

        float[,] FFTLog; // Log of Fourier Magnitude
        float[,] FFTPhaseLog; // Log of Fourier Phase
        public int[,] FFTNormalized; // Normalized FFT Magnitude : Scale 0-1
        public int[,] FFTPhaseNormalized; // Normalized FFT Phase : Scale 0-1
        int nx, ny; //Number of Points in Width & height
        public int Width, Height;
        public COMPLEX[,] BFourier; //Fourier Magnitude  Array Used for Inverse FFT
        public COMPLEX[,] GFourier; //Fourier Magnitude  Array Used for Inverse FFT
        public COMPLEX[,] RFourier; //Fourier Magnitude  Array Used for Inverse FFT
        public COMPLEX[,] AlphaFourier; //Fourier Magnitude  Array Used for Inverse FFT
        public COMPLEX[,] FFTShifted; // Shifted FFT 
        public COMPLEX[,] RFFTShifted; // Shifted FFT 
        public COMPLEX[,] GFFTShifted; // Shifted FFT 
        public COMPLEX[,] BFFTShifted; // Shifted FFT 
        public COMPLEX[,] AlphaFFTShifted; // Shifted FFT 
        public COMPLEX[,] BOutput; // FFT Normal
        public COMPLEX[,] GOutput; // FFT Normal
        public COMPLEX[,] ROutput; // FFT Normal
        public COMPLEX[,] AlphaOutput; // FFT Normal
        public COMPLEX[,] FFTNormal; // FFT Shift Removed - required for Inverse FFT 

        /// <summary>
        /// Parameterized Constructor for FFT Reads Input Bitmap to a Greyscale Array
        /// </summary>
        /// <param name="Input">Input Image</param>
        public FFTColor(Bitmap Input)
        {
            Obj = Input;
            Width = nx = Input.Width;
            Height = ny = Input.Height;
            ReadImage();
        }

        /// <summary>
        /// Parameterized Constructor for FFT
        /// </summary>
        /// <param name="Input">Greyscale Array</param>
        public FFTColor(int[,] Input)
        {
            Width = nx = Input.GetLength(0);
            Height = ny = Input.GetLength(1);
        }

        /// <summary>
        /// Function to Read Bitmap to greyscale Array
        /// </summary>
        public void ReadImage()
        {
            int i, j;
            BImage = new int[Width, Height]; //[Row,Column]
            GImage = new int[Width, Height]; //[Row,Column]
            RImage = new int[Width, Height]; //[Row,Column]
            AlphaImage = new int[Width, Height]; //[Row,Column]
            Bitmap image = Obj;
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* imagePointer1 = (byte*) bitmapData1.Scan0;

                for (i = 0; i < bitmapData1.Height; i++)
                {
                    for (j = 0; j < bitmapData1.Width; j++)
                    {
                        BImage[j, i] = imagePointer1[0];
                        GImage[j, i] = imagePointer1[1];
                        RImage[j, i] = imagePointer1[2];
                        AlphaImage[j, i] = imagePointer1[3];                        
                        imagePointer1 += 4;
                    } //end for j

                    //4 bytes per pixel
                    imagePointer1 += bitmapData1.Stride - (bitmapData1.Width * 4);
                } //end for i
            } //end unsafe

            image.UnlockBits(bitmapData1);
            return;
        }

        public Bitmap Displayimage()
        {
            int i, j;
            Bitmap image = new Bitmap(Width, Height);
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, Width, Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* imagePointer1 = (byte*) bitmapData1.Scan0;

                for (i = 0; i < bitmapData1.Height; i++)
                {
                    for (j = 0; j < bitmapData1.Width; j++)
                    {
                        // write the logic implementation here
                        imagePointer1[0] = (byte) BImage[j, i];
                        imagePointer1[1] = (byte) GImage[j, i];
                        imagePointer1[2] = (byte) RImage[j, i];
                        imagePointer1[3] = (byte) AlphaImage[j,i];
                        //4 bytes per pixel
                        imagePointer1 += 4;
                    } //end for j

                    //4 bytes per pixel
                    imagePointer1 += (bitmapData1.Stride - (bitmapData1.Width * 4));
                } //end for i
            } //end unsafe

            image.UnlockBits(bitmapData1);
            return image; // col;
        }

        public Bitmap Displayimage(int[,] image)
        {
            int i, j;
            Bitmap output = new Bitmap(image.GetLength(0), image.GetLength(1));
            BitmapData bitmapData1 = output.LockBits(new Rectangle(0, 0, image.GetLength(0), image.GetLength(1)),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* imagePointer1 = (byte*) bitmapData1.Scan0;
                for (i = 0; i < bitmapData1.Height; i++)
                {
                    for (j = 0; j < bitmapData1.Width; j++)
                    {
                        imagePointer1[0] = (byte) image[j, i];
                        imagePointer1[1] = (byte) image[j, i];
                        imagePointer1[2] = (byte) image[j, i];
                        imagePointer1[3] = 255;
                        //4 bytes per pixel
                        imagePointer1 += 4;
                    } //end for j

                    //4 bytes per pixel
                    imagePointer1 += (bitmapData1.Stride - (bitmapData1.Width * 4));
                } //end for i
            } //end unsafe

            output.UnlockBits(bitmapData1);
            return output; // col;
        }

        /// <summary>
        /// Calculate Fast Fourier Transform of Input Image
        /// </summary>
        public void ForwardFFT()
        {
            //Initializing Fourier Transform Array
            int i, j;
            BFourier = new COMPLEX [Width, Height];
            GFourier = new COMPLEX [Width, Height];
            RFourier = new COMPLEX [Width, Height];
            AlphaFourier = new COMPLEX [Width, Height];

            ROutput = new COMPLEX[Width, Height];
            GOutput = new COMPLEX[Width, Height];
            BOutput = new COMPLEX[Width, Height];
            AlphaOutput = new COMPLEX[Width, Height];
            //Copy Image Data to the Complex Array
            for (i = 0; i <= Width - 1; i++)
            for (j = 0; j <= Height - 1; j++)
            {
                BFourier[i, j].real = (double) BImage[i, j];
                BFourier[i, j].imag = 0;

                GFourier[i, j].real = (double) GImage[i, j];
                GFourier[i, j].imag = 0;

                RFourier[i, j].real = (double) RImage[i, j];
                RFourier[i, j].imag = 0;

                AlphaFourier[i, j].real = (double)AlphaImage[i, j];
                AlphaFourier[i, j].imag = 0;
            }
            //Calling Forward Fourier Transform
            BOutput = FFT2D(BFourier, nx, ny, 1);
            GOutput = FFT2D(GFourier, nx, ny, 1);
            ROutput = FFT2D(RFourier, nx, ny, 1);
            AlphaOutput = FFT2D(AlphaFourier, nx, ny, 1);
            return;
        }

        /// <summary>
        /// Shift The FFT of the Image
        /// </summary>
        public void FFTShift()
        {
            int i, j;
            RFFTShifted = new COMPLEX[nx, ny];
            GFFTShifted = new COMPLEX[nx, ny];
            BFFTShifted = new COMPLEX[nx, ny];
            AlphaFFTShifted = new COMPLEX[nx, ny];

            for (i = 0; i <= (nx / 2) - 1; i++)
            for (j = 0; j <= (ny / 2) - 1; j++)
            {
           

                RFFTShifted[i + (nx / 2), j + (ny / 2)] = ROutput[i, j];
                RFFTShifted[i, j] = ROutput[i + (nx / 2), j + (ny / 2)];
                RFFTShifted[i + (nx / 2), j] = ROutput[i, j + (ny / 2)];
                RFFTShifted[i, j + (ny / 2)] = ROutput[i + (nx / 2), j];

                GFFTShifted[i + (nx / 2), j + (ny / 2)] = GOutput[i, j];
                GFFTShifted[i, j] = GOutput[i + (nx / 2), j + (ny / 2)];
                GFFTShifted[i + (nx / 2), j] = GOutput[i, j + (ny / 2)];
                GFFTShifted[i, j + (ny / 2)] = GOutput[i + (nx / 2), j];

                BFFTShifted[i + (nx / 2), j + (ny / 2)] = BOutput[i, j];
                BFFTShifted[i, j] = BOutput[i + (nx / 2), j + (ny / 2)];
                BFFTShifted[i + (nx / 2), j] = BOutput[i, j + (ny / 2)];
                BFFTShifted[i, j + (ny / 2)] = BOutput[i + (nx / 2), j];

                AlphaFFTShifted[i + (nx / 2), j + (ny / 2)] = AlphaOutput[i, j];
                AlphaFFTShifted[i, j] = AlphaOutput[i + (nx / 2), j + (ny / 2)];
                AlphaFFTShifted[i + (nx / 2), j] = AlphaOutput[i, j + (ny / 2)];
                AlphaFFTShifted[i, j + (ny / 2)] = AlphaOutput[i + (nx / 2), j];
            }

            return;
        }

        /// <summary>
        /// Calculate Inverse from Complex [,]  Fourier Array
        /// </summary>
        public void InverseFFT()
        {
            //Initializing Fourier Transform Array
            int i, j;

            //Calling Forward Fourier Transform
            ROutput = new COMPLEX[nx, ny];
            GOutput = new COMPLEX[nx, ny];
            BOutput = new COMPLEX[nx, ny];
            AlphaOutput = new COMPLEX[nx, ny];
            BOutput = FFT2D(BFourier, nx, ny, -1);
            GOutput = FFT2D(GFourier, nx, ny, -1);
            ROutput = FFT2D(RFourier, nx, ny, -1);
            AlphaOutput = FFT2D(AlphaFourier, nx, ny, -1);

            Obj = null; // Setting Object Image to Null
            //Copying Real Image Back to Greyscale
            //Copy Image Data to the Complex Array
            for (i = 0; i <= Width - 1; i++)
            for (j = 0; j <= Height - 1; j++)
            {
                BImage[i, j] = (int) BOutput[i, j].Magnitude();
                GImage[i, j] = (int) GOutput[i, j].Magnitude();
                RImage[i, j] = (int) ROutput[i, j].Magnitude();
                AlphaImage[i, j] = (int) AlphaOutput[i, j].Magnitude();
            }

            Obj = Displayimage();
            return;
        }

        /*-------------------------------------------------------------------------
            Perform a 2D FFT inplace given a complex 2D array
            The direction dir, 1 for forward, -1 for reverse
            The size of the array (nx,ny)
            Return false if there are memory problems or
            the dimensions are not powers of 2
        */
        public COMPLEX[,] FFT2D(COMPLEX[,] c, int nx, int ny, int dir)
        {
            int i, j;
            int m; //Power of 2 for current number of points
            double[] real;
            double[] imag;
            COMPLEX[,] output; //=new COMPLEX [nx,ny];
            output = c; // Copying Array
            // Transform the Rows 
            real = new double[nx];
            imag = new double[nx];

            for (j = 0; j < ny; j++)
            {
                for (i = 0; i < nx; i++)
                {
                    real[i] = c[i, j].real;
                    imag[i] = c[i, j].imag;
                }

                // Calling 1D FFT Function for Rows
                m = (int) Math.Log((double) nx,
                    2); //Finding power of 2 for current number of points e.g. for nx=512 m=9
                FFT1D(dir, m, ref real, ref imag);

                for (i = 0; i < nx; i++)
                {
                    //  c[i,j].real = real[i];
                    //  c[i,j].imag = imag[i];
                    output[i, j].real = real[i];
                    output[i, j].imag = imag[i];
                }
            }

            // Transform the columns  
            real = new double[ny];
            imag = new double[ny];

            for (i = 0; i < nx; i++)
            {
                for (j = 0; j < ny; j++)
                {
                    //real[j] = c[i,j].real;
                    //imag[j] = c[i,j].imag;
                    real[j] = output[i, j].real;
                    imag[j] = output[i, j].imag;
                }

                // Calling 1D FFT Function for Columns
                m = (int) Math.Log((double) ny,
                    2); //Finding power of 2 for current number of points e.g. for nx=512 m=9
                FFT1D(dir, m, ref real, ref imag);
                for (j = 0; j < ny; j++)
                {
                    //c[i,j].real = real[j];
                    //c[i,j].imag = imag[j];
                    output[i, j].real = real[j];
                    output[i, j].imag = imag[j];
                }
            }

            // return(true);
            return (output);
        }

        /*-------------------------------------------------------------------------
            This computes an in-place complex-to-complex FFT
            x and y are the real and imaginary arrays of 2^m points.
            dir = 1 gives forward transform
            dir = -1 gives reverse transform
            Formula: forward
                     N-1
                      ---
                    1 \         - j k 2 pi n / N
            X(K) = --- > x(n) e                  = Forward transform
                    N /                            n=0..N-1
                      ---
                     n=0
            Formula: reverse
                     N-1
                     ---
                     \          j k 2 pi n / N
            X(n) =    > x(k) e                  = Inverse transform
                     /                             k=0..N-1
                     ---
                     k=0
            */
        private void FFT1D(int dir, int m, ref double[] x, ref double[] y)
        {
            long nn, i, i1, j, k, i2, l, l1, l2;
            double c1, c2, tx, ty, t1, t2, u1, u2, z;
            /* Calculate the number of points */
            nn = 1;
            for (i = 0; i < m; i++)
                nn *= 2;
            /* Do the bit reversal */
            i2 = nn >> 1;
            j = 0;
            for (i = 0; i < nn - 1; i++)
            {
                if (i < j)
                {
                    tx = x[i];
                    ty = y[i];
                    x[i] = x[j];
                    y[i] = y[j];
                    x[j] = tx;
                    y[j] = ty;
                }

                k = i2;
                while (k <= j)
                {
                    j -= k;
                    k >>= 1;
                }

                j += k;
            }

            /* Compute the FFT */
            c1 = -1.0;
            c2 = 0.0;
            l2 = 1;
            for (l = 0; l < m; l++)
            {
                l1 = l2;
                l2 <<= 1;
                u1 = 1.0;
                u2 = 0.0;
                for (j = 0; j < l1; j++)
                {
                    for (i = j; i < nn; i += l2)
                    {
                        i1 = i + l1;
                        t1 = u1 * x[i1] - u2 * y[i1];
                        t2 = u1 * y[i1] + u2 * x[i1];
                        x[i1] = x[i] - t1;
                        y[i1] = y[i] - t2;
                        x[i] += t1;
                        y[i] += t2;
                    }

                    z = u1 * c1 - u2 * c2;
                    u2 = u1 * c2 + u2 * c1;
                    u1 = z;
                }

                c2 = Math.Sqrt((1.0 - c1) / 2.0);
                if (dir == 1)
                    c2 = -c2;
                c1 = Math.Sqrt((1.0 + c1) / 2.0);
            }

            /* Scaling for forward transform */
            if (dir == 1)
            {
                for (i = 0; i < nn; i++)
                {
                    x[i] /= (double) nn;
                    y[i] /= (double) nn;
                }
            }


            //  return(true) ;
            return;
        }
    }
}