using System;
using System.Drawing;
using System.Windows.Forms;
using DigitalWatermarking.decoder;
using DigitalWatermarking.encoder;

namespace DigitalWatermarking.view
{
    public partial class ImageByteForm : Form
    {
        public ImageByteForm()
        {
            InitializeComponent();
        }

        private void file_chooser_click(object sender, EventArgs e)
        {
            var showDialog = ofd_file_chooser.ShowDialog();

            if (showDialog != DialogResult.OK)
            {
                return;
            }

            var originalImage = new Bitmap(ofd_file_chooser.FileName);
            pb_file_original.Image = originalImage;
            pb_file_original.SizeMode = PictureBoxSizeMode.StretchImage;

            lbl_file_original.Text = ofd_file_chooser.SafeFileName;

            UpdateEnableEncoding();
        }

        private void start_click(object sender, EventArgs e)
        {
            var image = new Bitmap(pb_file_original.Image);
            var watermark = new Bitmap(pb_watermark.Image);

            var encoder = new LsbImageEncoder(image, watermark);
            pb_watermark.Image = encoder.PreparedImage;

            encoder.Encode();
            var encodedImage = encoder.GetEncoded();
            pb_file_encoded.Image = encodedImage;
            pb_file_encoded.SizeMode = PictureBoxSizeMode.StretchImage;
            
            var decoder = new LsbImageDecoder(encodedImage);
            decoder.Decode();
            pb_decoded_watermark.Image = decoder.Message;
        }


        private void UpdateEnableEncoding()
        {
            btn_start.Enabled =
                //cb_method_encoding.SelectedItem != null &&
                !string.IsNullOrEmpty(ofd_file_chooser.SafeFileName);

            // lbl_start_error.Text = btn_start.Enabled ? "" : "Choose message and file to start!";
        }


        private void bt_choose_watermark_Click(object sender, EventArgs e)
        {
            var showDialog = ofd_file_chooser.ShowDialog();

            if (showDialog != DialogResult.OK)
            {
                return;
            }

            var image = new Bitmap(ofd_file_chooser.FileName);
            pb_watermark.Image = image;
            // PB_watermark.SizeMode = PictureBoxSizeMode.StretchImage;

            // lbl_file_original.Text = ofd_file_chooser.SafeFileName;

            UpdateEnableEncoding();
        }
    }
}