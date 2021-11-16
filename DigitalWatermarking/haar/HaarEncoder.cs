using System.Drawing;
using DigitalWatermarking.domain;

namespace DigitalWatermarking.haar
{
    public class HaarEncoder
    {
        private readonly HaarTransform _haarTransform;
        private readonly string _message;

        public HaarEncoder(Bitmap originalImage, string message)
        {
            _message = message;
            _haarTransform = new HaarTransform
            {
                OriginalImage = originalImage
            };
        }

        public void Encode()
        {
            _haarTransform.Prepare(true, 2);
            _haarTransform.ApplyHaarTransform(true, 2);

            var transform = _haarTransform.ImageArrays;
            EncodeMessageInTransform(transform);

            _haarTransform.ApplyHaarTransform(false, 2);
        }


        private void EncodeMessageInTransform(ImageArrays<double> transform)
        {
            var x = _message;
        }
    }
}