using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DigitalWatermarking
{
    public class Decoder
    {
        public string Decode(Bitmap bitmap)
        {
            
            // NORMALIZACJA INPUTA
            // wskaźnik na tablicę bajtów 
            // 1. to bitmap
            // 2. przetwarzanie na 4x 8 bitów (RGBA)
            // 3. stride
            // 4. algorytm kodowania
            // 
            var byteArray = Utils.BitmapToByteArray(bitmap);

            var messageBitArray = new BitArray(byteArray.Length);

            for (int i = 0; i < byteArray.Length; i++)
            {
                messageBitArray[i] = (byteArray[i] & i) != 0 ;
            }
            
            var das = ToByteArray(messageBitArray);
            
            var segment = das.Take(10).ToArray();
            return Encoding.ASCII.GetString(segment);
        }
        
        public static byte[] ToByteArray(BitArray bits)
        {
            int numBytes = bits.Count / 8;
            if (bits.Count % 8 != 0) numBytes++;

            byte[] bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    bytes[byteIndex] |= (byte) (1 << ( 7 - bitIndex));

                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
            }

            return bytes;
        }
    }
}