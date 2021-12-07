using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DigitalWatermarking.view
{
    public abstract class BaseForm : Form
    {
        public unsafe Bitmap GetComparison(Bitmap a, Bitmap b)
        {
            var max1 = 0;
            var max2 = 0;
            var max3 = 0;
            var result = new Bitmap(a.Width, a.Height);

            var bmDataA = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format32bppRgb);
            var bmDataB = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format32bppRgb);
            var bmDataResult = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format32bppRgb);


            var pointerA = (byte*) bmDataA.Scan0;
            var pointerB = (byte*) bmDataB.Scan0;
            var pointerResult = (byte*) bmDataResult.Scan0;

            for (var i = 0; i < a.Height; i++)
            {
                for (var j = 0; j < a.Width; j++)
                {
                    pointerResult[0] = (byte) (pointerA[0] - pointerB[0]);
                    max1 = Math.Max(max1, pointerResult[0]);

                    pointerResult[1] = (byte) (pointerA[1] - pointerB[1]);
                    max2 = Math.Max(max2, pointerResult[1]);
                    
                    pointerResult[2] = (byte) (pointerA[2] - pointerB[2]);
                    max3 = Math.Max(max3, pointerResult[2]);
                    
                    pointerResult[3] = (byte) (pointerA[3] - pointerB[3]);
                    
                    pointerA += 4; //4 bytes per pixel
                    pointerB += 4; //4 bytes per pixel
                    pointerResult += 4;
                }

                pointerA += bmDataA.Stride - (a.Width * 4); //4 bytes per pixel
                pointerB += bmDataB.Stride - (b.Width * 4); //4 bytes per pixel
                pointerResult += bmDataResult.Stride - (b.Width * 4); //4 bytes per pixel
            }
            
            pointerResult = (byte*) bmDataResult.Scan0;

            for (var i = 0; i < a.Height; i++)
            {
                for (var j = 0; j < a.Width; j++)
                {
                    pointerResult[0] = (byte) (pointerResult[0] * (255 / max1));
                    pointerResult[1] = (byte) (pointerResult[1] * (255 / max2));
                    pointerResult[2] = (byte) (pointerResult[2] * (255 / max3));
                    pointerResult += 4;
                }
                pointerResult += bmDataResult.Stride - (b.Width * 4); //4 bytes per pixel
            }

            a.UnlockBits(bmDataA);
            b.UnlockBits(bmDataB);
            result.UnlockBits(bmDataResult);

            return result;
        }
    }
}