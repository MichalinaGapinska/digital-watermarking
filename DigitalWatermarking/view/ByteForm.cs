using System;
using System.Drawing;
using System.Windows.Forms;
using DigitalWatermarking.decoder;
using DigitalWatermarking.encoder;

namespace DigitalWatermarking.view
{
    public partial class ByteForm : Form
    {
        public ByteForm()
        {
            InitializeComponent();
            UpdateEnableEncoding();
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
            var message = tb_message_original.Text;
            var originalImage = new Bitmap(ofd_file_chooser.FileName);
            var encoder = new LsbTextBitBaseEncoder(originalImage, message);
            encoder.Encode();
            pb_file_encoded.Image = encoder.GetEncoded();


            var decoder = new LsbTextDecoder(encoder.GetEncoded());
            decoder.Decode();
            lbl_message_decoded_text.Text = decoder.GetMessage().Substring(0, 18);
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