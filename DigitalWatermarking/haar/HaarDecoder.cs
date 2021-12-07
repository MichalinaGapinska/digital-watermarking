using System.Collections;
using System.Drawing;
using System.Text;
using DigitalWatermarking.domain;

namespace DigitalWatermarking.haar
{
    public class HaarDecoder
    {
        private readonly HaarTransform _haarTransformOriginalImage;
        private readonly HaarTransform _haarTransformEncodedImage;
        private readonly BitArray _bitArray;

        public HaarDecoder(Bitmap originalImage, Bitmap encodedImage)
        {
            _haarTransformOriginalImage = new HaarTransform
            {
                OriginalImage = originalImage
            };

            _haarTransformEncodedImage = new HaarTransform
            {
                OriginalImage = encodedImage
            };

            _bitArray = new BitArray(encodedImage.Height * encodedImage.Width * 3);
        }

        public void Decode()
        {
            _haarTransformOriginalImage.Prepare(true);
            _haarTransformOriginalImage.ApplyHaarTransform(true, 8);

            _haarTransformEncodedImage.Prepare(true);
            _haarTransformEncodedImage.ApplyHaarTransform(true, 8);

            var transformOriginalImage = _haarTransformOriginalImage.ImageArrays;
            var transformEncodedImage = _haarTransformEncodedImage.ImageArrays;
            DecodeMessageInTransform(transformOriginalImage, transformEncodedImage);
        }


        private void DecodeMessageInTransform(ImageArrays<double> transformOriginalImage,
            ImageArrays<double> transformEncodedImage)
        {
            var result = new ImageArrays<double>();

            var rows = transformEncodedImage.Blue.GetLength(0);
            var cols = transformEncodedImage.Blue.GetLength(1);

            result.Red = new double[rows, cols];
            result.Green = new double[rows, cols];
            result.Blue = new double[rows, cols];


            var read = false;
            var readCounter = 32;
            var position = 0;

            for (var i = rows; i < rows; i++)
            {
                for (var j = cols; j < cols; j++)
                {
                    // var d = (transformEncodedImage.Red[i, j] - transformOriginalImage.Red[i, j]) / transformOriginalImage.Red[i, j] +
                    // (transformEncodedImage.Green[i, j] - transformOriginalImage.Green[i, j]) / transformOriginalImage.Green[i, j] +
                    // (transformEncodedImage.Blue[i, j] - transformOriginalImage.Blue[i, j]) / transformOriginalImage.Blue[i, j];

                    var d = transformEncodedImage.Red[i, j] + transformEncodedImage.Green[i, j] +
                            transformEncodedImage.Blue[i, j] / 3;

                    if (!read)
                    {
                        if (d > 0.8)
                        {
                            readCounter--;

                            if (readCounter == 0)
                            {
                                read = true;
                            }
                        }
                        else
                        {
                            readCounter = 32;
                        }
                    }
                    else
                    {
                        var b = d > 1 ? true : false;
                        _bitArray[position++] = d > 0.8;
                    }


                    // result.Red[i, j] = transformEncodedImage.Red[i, j] / transformOriginalImage.Red[i, j];
                    // result.Green[i, j] = transformEncodedImage.Green[i, j] / transformOriginalImage.Green[i, j];
                    // result.Blue[i, j] = transformEncodedImage.Blue[i, j] / transformOriginalImage.Blue[i, j];
                }
            }
        }
        
        public string GetMessage()
        {
            var das = ToByteArray(_bitArray);

            var s = Encoding.ASCII.GetString(das).Substring(0,20);
            return s;
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