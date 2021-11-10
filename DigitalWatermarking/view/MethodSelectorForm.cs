using System;
using System.Windows.Forms;
using DigitalWatermarking.view;

namespace DigitalWatermarking
{
    public partial class MethodSelectorForm : Form
    {
        private const string MethodByteEncodingText = "Byte encoding (text)";
        private const string MethodByteEncodingImage = "Byte encoding (Image)";
        private const string MethodAnother = "Another method";
        private readonly object[] _encodingMethods = {MethodByteEncodingText, MethodByteEncodingImage, MethodAnother};

        public MethodSelectorForm()
        {
            InitializeComponent();

            cb_method_encoding.Items.AddRange(_encodingMethods);
            cb_method_encoding.SelectedItem = _encodingMethods[0];

            UpdateEnableContinuing();
        }

        private void UpdateEnableContinuing()
        {
            btn_continue.Enabled = cb_method_encoding.SelectedItem != null;
            lbl_continue_error.Text = lbl_continue_error.Enabled ? "" : "Choose message and file to start!";
        }

        private void continue_click(object sender, EventArgs e)
        {
            Hide();

            var selectedMethod = cb_method_encoding.SelectedItem.ToString();

            switch (selectedMethod)
            {
                case MethodByteEncodingText:
                    OpenForm(new ByteForm());
                    break;
                case MethodByteEncodingImage:
                    OpenForm(new ImageByteForm());
                    break;
                case MethodAnother:
                    // OpenForm(new sthg());
                    Close();
                    break;
                default:
                    Close();
                    return;
            }
        }

        private void OpenForm(Form selectedMethodForm)
        {
            selectedMethodForm.Closed += (s, args) => Close();
            selectedMethodForm.Show();
        }
    }
}