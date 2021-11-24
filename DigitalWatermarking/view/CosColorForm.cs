using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DigitalWatermarking.decoder;
using DigitalWatermarking.encoder;

namespace DigitalWatermarking
{
    public partial class CosColorForm : Form
    {
        public CosColorForm()
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
            var encoder = new CosColorEncoder(originalImage, tb_message_original.Text);
            pb_file_original.Image = encoder.OriginalImage;
            pb_file_original.SizeMode = PictureBoxSizeMode.StretchImage;

            lbl_file_original.Text = ofd_file_chooser.SafeFileName;

            UpdateEnableEncoding();
        }

        private void start_click(object sender, EventArgs e)
        {
            var message = tb_message_original.Text;
            var originalImage = new Bitmap(ofd_file_chooser.FileName);
            var encoder = new CosColorEncoder(originalImage, message);
            encoder.EncodeMessage();
            pb_file_encoded.Image = encoder.EncodedImage;
            pb_file_encoded.SizeMode = PictureBoxSizeMode.StretchImage;

            var decoder = new CosColorDecoder();
            decoder.DecodeImage(encoder.EncodedImage, encoder.OriginalImage, message);
            lbl_message_decoded_text.Text = decoder.DecodedMessage;
            accuracy_label.Text = decoder.AccuracyInfo;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}