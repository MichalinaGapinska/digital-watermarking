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
    public partial class FFTFormMagnitude : Form
    {
        public FFTFormMagnitude()
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
            var encoder = new FFTEncoder(originalImage, "");
            pb_file_original.Image = encoder.GreyOriginalImage;
            pb_file_original.SizeMode = PictureBoxSizeMode.StretchImage;

            lbl_file_original.Text = ofd_file_chooser.SafeFileName;

            UpdateEnableEncoding();
        }

        private void start_click(object sender, EventArgs e)
        {
            var message = "";
            var originalImage = new Bitmap(ofd_file_chooser.FileName);
            var encoder = new FFTEncoder(originalImage, message);
            encoder.EncodeMessage();
            pb_file_encoded.Image = encoder.MagnitudePlotImage;
            pb_file_encoded.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void tb_message_original_TextChanged(object sender, EventArgs e)
        {
            UpdateEnableEncoding();
        }

        private void UpdateEnableEncoding()
        {
            btn_start.Enabled = !string.IsNullOrEmpty(ofd_file_chooser.SafeFileName);

            lbl_start_error.Text = btn_start.Enabled ? "" : "Choose file to start!";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_file_encoded_Click(object sender, EventArgs e)
        {

        }
    }
}