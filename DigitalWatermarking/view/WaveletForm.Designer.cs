﻿namespace DigitalWatermarking.view
{
    partial class WaveletForm
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
            this.tb_message_original = new System.Windows.Forms.TextBox();
            this.lbl_message_original = new System.Windows.Forms.Label();
            this.lbl_message_decoded_text = new System.Windows.Forms.Label();
            this.lbl_message_decoded = new System.Windows.Forms.Label();
            this.lbl_file_original = new System.Windows.Forms.Label();
            this.gb_input = new System.Windows.Forms.GroupBox();
            this.lbl_image_original = new System.Windows.Forms.Label();
            this.gb_output = new System.Windows.Forms.GroupBox();
            this.lbl_start_error = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.lbl_file_encoded = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pb_transform = new System.Windows.Forms.PictureBox();
            this.pb_compare = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize) (this.pb_file_original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pb_file_encoded)).BeginInit();
            this.gb_input.SuspendLayout();
            this.gb_output.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pb_transform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pb_compare)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_file_chooser
            // 
            this.btn_file_chooser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.btn_file_chooser.Location = new System.Drawing.Point(24, 83);
            this.btn_file_chooser.Name = "btn_file_chooser";
            this.btn_file_chooser.Size = new System.Drawing.Size(180, 35);
            this.btn_file_chooser.TabIndex = 0;
            this.btn_file_chooser.Text = "Choose file";
            this.btn_file_chooser.UseVisualStyleBackColor = true;
            this.btn_file_chooser.Click += new System.EventHandler(this.file_chooser_click);
            // 
            // pb_file_original
            // 
            this.pb_file_original.Location = new System.Drawing.Point(24, 180);
            this.pb_file_original.Name = "pb_file_original";
            this.pb_file_original.Size = new System.Drawing.Size(512, 512);
            this.pb_file_original.TabIndex = 2;
            this.pb_file_original.TabStop = false;
            // 
            // pb_file_encoded
            // 
            this.pb_file_encoded.Location = new System.Drawing.Point(24, 180);
            this.pb_file_encoded.Name = "pb_file_encoded";
            this.pb_file_encoded.Size = new System.Drawing.Size(512, 512);
            this.pb_file_encoded.TabIndex = 3;
            this.pb_file_encoded.TabStop = false;
            // 
            // tb_message_original
            // 
            this.tb_message_original.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.tb_message_original.Location = new System.Drawing.Point(230, 37);
            this.tb_message_original.Name = "tb_message_original";
            this.tb_message_original.Size = new System.Drawing.Size(300, 26);
            this.tb_message_original.TabIndex = 4;
            this.tb_message_original.TextChanged += new System.EventHandler(this.tb_message_original_TextChanged);
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
            // lbl_message_decoded_text
            // 
            this.lbl_message_decoded_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.lbl_message_decoded_text.Location = new System.Drawing.Point(236, 88);
            this.lbl_message_decoded_text.Name = "lbl_message_decoded_text";
            this.lbl_message_decoded_text.Size = new System.Drawing.Size(300, 25);
            this.lbl_message_decoded_text.TabIndex = 6;
            this.lbl_message_decoded_text.Text = "[decoded_message]";
            this.lbl_message_decoded_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_message_decoded
            // 
            this.lbl_message_decoded.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.lbl_message_decoded.Location = new System.Drawing.Point(24, 88);
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
            this.gb_input.Controls.Add(this.lbl_image_original);
            this.gb_input.Controls.Add(this.lbl_message_original);
            this.gb_input.Controls.Add(this.tb_message_original);
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
            // lbl_image_original
            // 
            this.lbl_image_original.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.lbl_image_original.Location = new System.Drawing.Point(24, 137);
            this.lbl_image_original.Name = "lbl_image_original";
            this.lbl_image_original.Size = new System.Drawing.Size(300, 25);
            this.lbl_image_original.TabIndex = 12;
            this.lbl_image_original.Text = "Original image:";
            this.lbl_image_original.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gb_output
            // 
            this.gb_output.Controls.Add(this.lbl_start_error);
            this.gb_output.Controls.Add(this.btn_start);
            this.gb_output.Controls.Add(this.lbl_file_encoded);
            this.gb_output.Controls.Add(this.lbl_message_decoded_text);
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
            // lbl_start_error
            // 
            this.lbl_start_error.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.lbl_start_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_start_error.Location = new System.Drawing.Point(236, 38);
            this.lbl_start_error.Name = "lbl_start_error";
            this.lbl_start_error.Size = new System.Drawing.Size(300, 25);
            this.lbl_start_error.TabIndex = 11;
            this.lbl_start_error.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.btn_start.Location = new System.Drawing.Point(24, 33);
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
            this.lbl_file_encoded.Location = new System.Drawing.Point(24, 137);
            this.lbl_file_encoded.Name = "lbl_file_encoded";
            this.lbl_file_encoded.Size = new System.Drawing.Size(300, 25);
            this.lbl_file_encoded.TabIndex = 9;
            this.lbl_file_encoded.Text = "Image with encoded message:";
            this.lbl_file_encoded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pb_transform);
            this.groupBox1.Controls.Add(this.pb_compare);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.groupBox1.Location = new System.Drawing.Point(1218, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 913);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compare";
            // 
            // pb_transform
            // 
            this.pb_transform.Location = new System.Drawing.Point(22, 471);
            this.pb_transform.Name = "pb_transform";
            this.pb_transform.Size = new System.Drawing.Size(400, 400);
            this.pb_transform.TabIndex = 4;
            this.pb_transform.TabStop = false;
            // 
            // pb_compare
            // 
            this.pb_compare.Location = new System.Drawing.Point(22, 34);
            this.pb_compare.Name = "pb_compare";
            this.pb_compare.Size = new System.Drawing.Size(400, 400);
            this.pb_compare.TabIndex = 3;
            this.pb_compare.TabStop = false;
            // 
            // WaveletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1688, 959);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_output);
            this.Controls.Add(this.gb_input);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "WaveletForm";
            this.Text = "Digital Watermarking";
            ((System.ComponentModel.ISupportInitialize) (this.pb_file_original)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pb_file_encoded)).EndInit();
            this.gb_input.ResumeLayout(false);
            this.gb_input.PerformLayout();
            this.gb_output.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pb_transform)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pb_compare)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pb_compare;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pb_transform;

        private System.Windows.Forms.Label lbl_image_original;

        private System.Windows.Forms.Label lbl_start_error;

        private System.Windows.Forms.Button btn_start;

        private System.Windows.Forms.OpenFileDialog ofd_file_chooser;

        private System.Windows.Forms.PictureBox pb_file_original;

        private System.Windows.Forms.PictureBox pb_file_encoded;

        private System.Windows.Forms.Button btn_file_chooser;

        private System.Windows.Forms.Label lbl_message_decoded_text;

        private System.Windows.Forms.Label lbl_message_original;

        private System.Windows.Forms.TextBox tb_message_original;

        private System.Windows.Forms.Label lbl_file_original;

        private System.Windows.Forms.Label lbl_file_encoded;

        private System.Windows.Forms.GroupBox gb_input;
        private System.Windows.Forms.GroupBox gb_output;

        private System.Windows.Forms.Label lbl_message_decoded;
       
        #endregion
    }
}