using System.Collections;
using System.Windows.Forms;

namespace DigitalWatermarking
{
    partial class FFTFormMagnitude
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
            this.lbl_file_original = new System.Windows.Forms.Label();
            this.gb_input = new System.Windows.Forms.GroupBox();
            this.lbl_image_original = new System.Windows.Forms.Label();
            this.gb_output = new System.Windows.Forms.GroupBox();
            this.lbl_start_error = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.lbl_file_encoded = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_file_original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_file_encoded)).BeginInit();
            this.gb_input.SuspendLayout();
            this.gb_output.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_file_chooser
            // 
            this.btn_file_chooser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
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
            // lbl_file_original
            // 
            this.lbl_file_original.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_file_original.Location = new System.Drawing.Point(230, 89);
            this.lbl_file_original.Name = "lbl_file_original";
            this.lbl_file_original.Size = new System.Drawing.Size(300, 25);
            this.lbl_file_original.TabIndex = 8;
            this.lbl_file_original.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gb_input
            // 
            this.gb_input.Controls.Add(this.lbl_image_original);
            this.gb_input.Controls.Add(this.pb_file_original);
            this.gb_input.Controls.Add(this.lbl_file_original);
            this.gb_input.Controls.Add(this.btn_file_chooser);
            this.gb_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gb_input.Location = new System.Drawing.Point(34, 28);
            this.gb_input.Name = "gb_input";
            this.gb_input.Size = new System.Drawing.Size(560, 715);
            this.gb_input.TabIndex = 9;
            this.gb_input.TabStop = false;
            this.gb_input.Text = "Input";
            // 
            // lbl_image_original
            // 
            this.lbl_image_original.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
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
            this.gb_output.Controls.Add(this.pb_file_encoded);
            this.gb_output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gb_output.Location = new System.Drawing.Point(638, 28);
            this.gb_output.Name = "gb_output";
            this.gb_output.Size = new System.Drawing.Size(560, 715);
            this.gb_output.TabIndex = 10;
            this.gb_output.TabStop = false;
            this.gb_output.Text = "Output";
            // 
            // lbl_start_error
            // 
            this.lbl_start_error.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_start_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_start_error.Location = new System.Drawing.Point(236, 38);
            this.lbl_start_error.Name = "lbl_start_error";
            this.lbl_start_error.Size = new System.Drawing.Size(300, 25);
            this.lbl_start_error.TabIndex = 11;
            this.lbl_start_error.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_start.Location = new System.Drawing.Point(24, 33);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(180, 35);
            this.btn_start.TabIndex = 11;
            this.btn_start.Text = "Get graph";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.start_click);
            // 
            // lbl_file_encoded
            // 
            this.lbl_file_encoded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_file_encoded.Location = new System.Drawing.Point(24, 137);
            this.lbl_file_encoded.Name = "lbl_file_encoded";
            this.lbl_file_encoded.Size = new System.Drawing.Size(300, 25);
            this.lbl_file_encoded.TabIndex = 9;
            this.lbl_file_encoded.Text = "Image magnitude:";
            this.lbl_file_encoded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_file_encoded.Click += new System.EventHandler(this.lbl_file_encoded_Click);
            // 
            // FFTFormMagnitude
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1506, 771);
            this.Controls.Add(this.gb_output);
            this.Controls.Add(this.gb_input);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "FFTFormMagnitude";
            this.Text = "Digital Watermarking";
            ((System.ComponentModel.ISupportInitialize)(this.pb_file_original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_file_encoded)).EndInit();
            this.gb_input.ResumeLayout(false);
            this.gb_output.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lbl_image_original;

        private System.Windows.Forms.Label lbl_start_error;

        private System.Windows.Forms.Button btn_start;

        private System.Windows.Forms.OpenFileDialog ofd_file_chooser;

        private System.Windows.Forms.PictureBox pb_file_original;

        private System.Windows.Forms.PictureBox pb_file_encoded;

        private System.Windows.Forms.Button btn_file_chooser;

        private System.Windows.Forms.Label lbl_file_original;

        private System.Windows.Forms.Label lbl_file_encoded;

        private System.Windows.Forms.GroupBox gb_input;
        private System.Windows.Forms.GroupBox gb_output;

        #endregion
    }
}