using System.Collections;
using System.Drawing;
using DigitalWatermarking.domain;

namespace DigitalWatermarking.haar
{
    public class HaarEncoder
    {
        private readonly HaarTransform _haarTransform;
        private readonly string _message;
        private readonly BitArray _messageInBit;

        public HaarEncoder(Bitmap originalImage, string message)
        {
            char ones = (char) 254;

            message = "" + ones + ones + ones + ones +
                      message +
                      '\x00ff' + '\x00ff' + '\x00ff' + '\x00ff';
            var bytes = System.Text.Encoding.ASCII.GetBytes(message);


            _messageInBit = new BitArray(bytes);

            for (var i = 0; i < 32; i++)
            {
                _messageInBit[i] = true;
                _messageInBit[_messageInBit.Length - 1 - i] = true;
            }

            _message = message;
            _haarTransform = new HaarTransform
            {
                OriginalImage = originalImage
            };
        }

        public void Encode()
        {
            _haarTransform.Prepare(true);
            _haarTransform.ApplyHaarTransform(true, 8);

            var transform = _haarTransform.ImageArrays;
            EncodeMessageInTransform(transform);

            _haarTransform.ApplyHaarTransform(false, 8);
            // _haarTransform.Prepare(true);
            // _haarTransform.ApplyHaarTransform(true, 2);
            transform = _haarTransform.ImageArrays;
        }


        private void EncodeMessageInTransform(ImageArrays<double> transform)
        {
            var nx = transform.Blue.GetLength(0);
            var ny = transform.Blue.GetLength(1);

            var position = 0;
            for (var i = nx; i < nx; i++)
            {
                for (var j = ny; j < ny; j++)
                {
                    if (position >= _messageInBit.Length)
                    {
                        return;
                    }

                    var value = _messageInBit[position] ? 1 : -1;
                    transform.Red[i, j] = value;
                    transform.Green[i, j] = value;
                    transform.Blue[i, j] = value;
                    position++;
                }
            }
        }

        public Bitmap GetTransformed()
        {
            return _haarTransform.TransformedImage;
        }

        public Bitmap GetEncoded()
        {
            return _haarTransform.ReTransformedImage;
        }
    }
}