namespace DigitalWatermarking.view
{
    partial class ImageByteForm
    {
         /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        // public System.Windows.Forms.ComboBox.ObjectCollection Items { get; }
     
        // public object[] encodingMethods = new object[] {method_byte_encoding_text, method_another};

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_file_chooser = new System.Windows.Forms.Button();
            this.ofd_file_chooser = new System.Windows.Forms.OpenFileDialog();
            this.pb_file_original = new System.Windows.Forms.PictureBox();
            this.pb_file_encoded = new System.Windows.Forms.PictureBox();
            this.lbl_message_original = new System.Windows.Forms.Label();
            this.lbl_message_decoded = new System.Windows.Forms.Label();
            this.lbl_file_original = new System.Windows.Forms.Label();
            this.gb_input = new System.Windows.Forms.GroupBox();
            this.pb_watermark = new System.Windows.Forms.PictureBox();
            this.bt_choose_watermark = new System.Windows.Forms.Button();
            this.lbl_image_original = new System.Windows.Forms.Label();
            this.gb_output = new System.Windows.Forms.GroupBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.lbl_file_encoded = new System.Windows.Forms.Label();
            this.pb_decoded_watermark = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize) (this.pb_file_original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pb_file_encoded)).BeginInit();
            this.gb_input.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pb_watermark)).BeginInit();
            this.gb_output.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pb_decoded_watermark)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_file_chooser
            // 
            this.btn_file_chooser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.btn_file_chooser.Location = new System.Drawing.Point(155, 369);
            this.btn_file_chooser.Name = "btn_file_chooser";
            this.btn_file_chooser.Size = new System.Drawing.Size(91, 25);
            this.btn_file_chooser.TabIndex = 0;
            this.btn_file_chooser.Text = "Choose file";
            this.btn_file_chooser.UseVisualStyleBackColor = true;
            this.btn_file_chooser.Click += new System.EventHandler(this.file_chooser_click);
            // 
            // pb_file_original
            // 
            this.pb_file_original.Location = new System.Drawing.Point(24, 397);
            this.pb_file_original.Name = "pb_file_original";
            this.pb_file_original.Size = new System.Drawing.Size(506, 295);
            this.pb_file_original.TabIndex = 2;
            this.pb_file_original.TabStop = false;
            // 
            // pb_file_encoded
            // 
            this.pb_file_encoded.Location = new System.Drawing.Point(0, 397);
            this.pb_file_encoded.Name = "pb_file_encoded";
            this.pb_file_encoded.Size = new System.Drawing.Size(536, 295);
            this.pb_file_encoded.TabIndex = 3;
            this.pb_file_encoded.TabStop = false;
            // 
            // lbl_message_original
            // 
            this.lbl_message_original.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.lbl_message_original.Location = new System.Drawing.Point(24, 38);
            this.lbl_message_original.Name = "lbl_message_original";
            this.lbl_message_original.Size = new System.Drawing.Size(200, 25);
            this.lbl_message_original.TabIndex = 5;
            this.lbl_message_original.Text = "Message to encode:";
            this.lbl_message_original.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_message_decoded
            // 
            this.lbl_message_decoded.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.lbl_message_decoded.Location = new System.Drawing.Point(17, 38);
            this.lbl_message_decoded.Name = "lbl_message_decoded";
            this.lbl_message_decoded.Size = new System.Drawing.Size(200, 25);
            this.lbl_message_decoded.TabIndex = 7;
            this.lbl_message_decoded.Text = "Decoded message:";
            this.lbl_message_decoded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_file_original
            // 
            this.lbl_file_original.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.lbl_file_original.Location = new System.Drawing.Point(230, 89);
            this.lbl_file_original.Name = "lbl_file_original";
            this.lbl_file_original.Size = new System.Drawing.Size(300, 25);
            this.lbl_file_original.TabIndex = 8;
            this.lbl_file_original.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gb_input
            // 
            this.gb_input.Controls.Add(this.pb_watermark);
            this.gb_input.Controls.Add(this.bt_choose_watermark);
            this.gb_input.Controls.Add(this.lbl_image_original);
            this.gb_input.Controls.Add(this.lbl_message_original);
            this.gb_input.Controls.Add(this.pb_file_original);
            this.gb_input.Controls.Add(this.lbl_file_original);
            this.gb_input.Controls.Add(this.btn_file_chooser);
            this.gb_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.gb_input.Location = new System.Drawing.Point(34, 28);
            this.gb_input.Name = "gb_input";
            this.gb_input.Size = new System.Drawing.Size(560, 715);
            this.gb_input.TabIndex = 9;
            this.gb_input.TabStop = false;
            this.gb_input.Text = "Input";
            // 
            // pb_watermark
            // 
            this.pb_watermark.Location = new System.Drawing.Point(24, 88);
            this.pb_watermark.Name = "pb_watermark";
            this.pb_watermark.Size = new System.Drawing.Size(506, 228);
            this.pb_watermark.TabIndex = 14;
            this.pb_watermark.TabStop = false;
            // 
            // bt_choose_watermark
            // 
            this.bt_choose_watermark.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.bt_choose_watermark.Location = new System.Drawing.Point(215, 38);
            this.bt_choose_watermark.Name = "bt_choose_watermark";
            this.bt_choose_watermark.Size = new System.Drawing.Size(91, 25);
            this.bt_choose_watermark.TabIndex = 13;
            this.bt_choose_watermark.Text = "Choose file";
            this.bt_choose_watermark.UseVisualStyleBackColor = true;
            this.bt_choose_watermark.Click += new System.EventHandler(this.bt_choose_watermark_Click);
            // 
            // lbl_image_original
            // 
            this.lbl_image_original.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.lbl_image_original.Location = new System.Drawing.Point(24, 369);
            this.lbl_image_original.Name = "lbl_image_original";
            this.lbl_image_original.Size = new System.Drawing.Size(125, 25);
            this.lbl_image_original.TabIndex = 12;
            this.lbl_image_original.Text = "Original image:";
            this.lbl_image_original.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gb_output
            // 
            this.gb_output.Controls.Add(this.pb_decoded_watermark);
            this.gb_output.Controls.Add(this.btn_start);
            this.gb_output.Controls.Add(this.lbl_file_encoded);
            this.gb_output.Controls.Add(this.lbl_message_decoded);
            this.gb_output.Controls.Add(this.pb_file_encoded);
            this.gb_output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.gb_output.Location = new System.Drawing.Point(638, 28);
            this.gb_output.Name = "gb_output";
            this.gb_output.Size = new System.Drawing.Size(560, 715);
            this.gb_output.TabIndex = 10;
            this.gb_output.TabStop = false;
            this.gb_output.Text = "Output";
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.btn_start.Location = new System.Drawing.Point(90, 0);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(180, 35);
            this.btn_start.TabIndex = 11;
            this.btn_start.Text = "Start encoding";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.start_click);
            // 
            // lbl_file_encoded
            // 
            this.lbl_file_encoded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.lbl_file_encoded.Location = new System.Drawing.Point(6, 369);
            this.lbl_file_encoded.Name = "lbl_file_encoded";
            this.lbl_file_encoded.Size = new System.Drawing.Size(300, 25);
            this.lbl_file_encoded.TabIndex = 9;
            this.lbl_file_encoded.Text = "Image with encoded message:";
            this.lbl_file_encoded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pb_decoded_watermark
            // 
            this.pb_decoded_watermark.Location = new System.Drawing.Point(17, 88);
            this.pb_decoded_watermark.Name = "pb_decoded_watermark";
            this.pb_decoded_watermark.Size = new System.Drawing.Size(506, 228);
            this.pb_decoded_watermark.TabIndex = 15;
            this.pb_decoded_watermark.TabStop = false;
            // 
            // ImageByteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1229, 771);
            this.Controls.Add(this.gb_output);
            this.Controls.Add(this.gb_input);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "ImageByteForm";
            this.Text = "Digital Watermarking";
            ((System.ComponentModel.ISupportInitialize) (this.pb_file_original)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pb_file_encoded)).EndInit();
            this.gb_input.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pb_watermark)).EndInit();
            this.gb_output.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pb_decoded_watermark)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pb_decoded_watermark;

        private System.Windows.Forms.Button bt_choose_watermark;
        private System.Windows.Forms.PictureBox pb_watermark;

        private System.Windows.Forms.Label lbl_image_original;

        private System.Windows.Forms.Button btn_start;

        private System.Windows.Forms.OpenFileDialog ofd_file_chooser;

        private System.Windows.Forms.PictureBox pb_file_original;

        private System.Windows.Forms.PictureBox pb_file_encoded;

        private System.Windows.Forms.Button btn_file_chooser;

        private System.Windows.Forms.Label lbl_message_original;

        private System.Windows.Forms.Label lbl_file_original;

        private System.Windows.Forms.Label lbl_file_encoded;

        private System.Windows.Forms.GroupBox gb_input;
        private System.Windows.Forms.GroupBox gb_output;

        private System.Windows.Forms.Label lbl_message_decoded;
       
        #endregion
    }
}