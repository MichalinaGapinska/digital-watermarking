using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalWatermarking
{
    public partial class ByteForm : Form
    {
        private Encoder _encoder;
        private Decoder _decoder;
        
        public ByteForm()
        {
            InitializeComponent();
            _encoder = new Encoder();
            _decoder = new Decoder();

            UpdateEnableEncoding();
        }

        private void file_chooser_click(object sender, EventArgs e)
        {
            var showDialog = ofd_file_chooser.ShowDialog();

            if (showDialog == DialogResult.OK)
            {
                var originalImage = new Bitmap(ofd_file_chooser.FileName);
                pb_file_original.Image = originalImage;
                pb_file_original.SizeMode = PictureBoxSizeMode.StretchImage;

                lbl_file_original.Text = ofd_file_chooser.SafeFileName;

                UpdateEnableEncoding();
            }
        }

        private void start_click(object sender, EventArgs e)
        {
            var message = tb_message_original.Text;
            var originalImage = new Bitmap(ofd_file_chooser.FileName);
            ByteEncodeProcess(originalImage, message);
        }

        private void ByteEncodeProcess(Bitmap originalImage, String message)
        {
            var codedImage = EncodeMessage(originalImage, message);
            // var codedImage = _encoder.Encode(originalImage, message);

            pb_file_encoded.Image = codedImage;
            pb_file_encoded.SizeMode = PictureBoxSizeMode.StretchImage;
            // lbl_message_decoded_text.Text = _decoder.Decode(codedImage);
            lbl_message_decoded_text.Text = DecodeImage(codedImage);
        }

        private Bitmap EncodeMessage(Bitmap originalImage, String message)
        {
            var codedImage = (Bitmap) originalImage.Clone();

            var bytes = Encoding.ASCII.GetBytes(message);
            var messageBits = new BitArray(bytes);


            for (var row = 0; row < codedImage.Height; row++)
            {
                for (var col = 0; col < codedImage.Width; col++)
                {
                    var index = (row * col + col) * 3;
                    var pixel = codedImage.GetPixel(col, row);
                    if (index + 2 >= messageBits.Length)
                    {
                        codedImage.SetPixel(col, row, pixel);
                        continue;
                    }

                    var newR = messageBits[index] ? setOne(pixel.R) : setZero(pixel.R);
                    var newG = messageBits[index + 1] ? setOne(pixel.G) : setZero(pixel.G);
                    var newB = messageBits[index + 2] ? setOne(pixel.B) : setZero(pixel.B);
                    var fromArgb = Color.FromArgb(newR, newG, newB);
                    codedImage.SetPixel(col, row, fromArgb);
                }
            }

            return codedImage;
        }

        private String DecodeImage(Bitmap encodedBitmap)
        {
            BitArray bitArray = new BitArray(encodedBitmap.Height * encodedBitmap.Width * 3);

            for (int row = 0; row < encodedBitmap.Height; row++)
            {
                for (int col = 0; col < encodedBitmap.Width; col++)
                {
                    var index = (row * col + col) * 3;

                    var pixel = encodedBitmap.GetPixel(col, row);
                    bitArray[index] = (pixel.R & 1) != 0;
                    bitArray[index + 1] = (pixel.G & 1) != 0;
                    bitArray[index + 2] = (pixel.B & 1) != 0;
                }
            }

            var das = ToByteArray(bitArray);

            var segment = das.Take(8000).ToArray();
            return Encoding.ASCII.GetString(segment);
        }

        byte setZero(byte b)
        {
            return (byte) (b & ~(1 << 0));
        }

        byte setOne(byte b)
        {
            return (byte) (b | (1 << 0));
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

        private byte GetByte(BitArray input)
        {
            var len = input.Length;
            if (len > 8)
                len = 8;
            var output = 0;
            for (var i = 0; i < len; i++)
                if (input.Get(i))
                    output += (1 << (len - 1 - i)); //this part depends on your system (Big/Little)
            //output += (1 << i); //depends on system
            return (byte) output;
        }

        private void tb_message_original_TextChanged(object sender, EventArgs e)
        {
            UpdateEnableEncoding();
        }

        private void UpdateEnableEncoding()
        {
            btn_start.Enabled = !string.IsNullOrEmpty(tb_message_original.Text) &&
                                //cb_method_encoding.SelectedItem != null &&
                                !string.IsNullOrEmpty(ofd_file_chooser.SafeFileName);

            lbl_start_error.Text = btn_start.Enabled ? "" : "Choose message and file to start!";
        }
    }
}