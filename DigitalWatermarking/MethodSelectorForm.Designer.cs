using System.ComponentModel;

namespace DigitalWatermarking
{
    partial class MethodSelectorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.lbl_method_encoding = new System.Windows.Forms.Label();
            this.cb_method_encoding = new System.Windows.Forms.ComboBox();
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.btn_continue = new System.Windows.Forms.Button();
            this.lbl_continue_error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_method_encoding
            // 
            this.lbl_method_encoding.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.lbl_method_encoding.Location = new System.Drawing.Point(200, 190);
            this.lbl_method_encoding.Name = "lbl_method_encoding";
            this.lbl_method_encoding.Size = new System.Drawing.Size(450, 25);
            this.lbl_method_encoding.TabIndex = 11;
            this.lbl_method_encoding.Text = "Please select an encoding method to proceed";
            this.lbl_method_encoding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_method_encoding
            // 
            this.cb_method_encoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_method_encoding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.cb_method_encoding.FormattingEnabled = true;
            this.cb_method_encoding.Location = new System.Drawing.Point(275, 250);
            this.cb_method_encoding.Name = "cb_method_encoding";
            this.cb_method_encoding.Size = new System.Drawing.Size(300, 28);
            this.cb_method_encoding.TabIndex = 12;
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.lbl_welcome.Location = new System.Drawing.Point(200, 60);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(450, 35);
            this.lbl_welcome.TabIndex = 13;
            this.lbl_welcome.Text = "Welcome to Digital Watermarking";
            this.lbl_welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_continue
            // 
            this.btn_continue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.btn_continue.Location = new System.Drawing.Point(335, 315);
            this.btn_continue.Name = "btn_continue";
            this.btn_continue.Size = new System.Drawing.Size(180, 35);
            this.btn_continue.TabIndex = 14;
            this.btn_continue.Text = "Continue";
            this.btn_continue.UseVisualStyleBackColor = true;
            this.btn_continue.Click += new System.EventHandler(this.continue_click);
            // 
            // lbl_continue_error
            // 
            this.lbl_continue_error.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.lbl_continue_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_continue_error.Location = new System.Drawing.Point(275, 287);
            this.lbl_continue_error.Name = "lbl_continue_error";
            this.lbl_continue_error.Size = new System.Drawing.Size(300, 25);
            this.lbl_continue_error.TabIndex = 15;
            this.lbl_continue_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MethodSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 426);
            this.Controls.Add(this.lbl_continue_error);
            this.Controls.Add(this.btn_continue);
            this.Controls.Add(this.lbl_welcome);
            this.Controls.Add(this.cb_method_encoding);
            this.Controls.Add(this.lbl_method_encoding);
            this.Name = "MethodSelectorForm";
            this.Text = "Digital Watermarking";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lbl_continue_error;

        private System.Windows.Forms.Button btn_continue;

        private System.Windows.Forms.Label lbl_welcome;

        private System.Windows.Forms.ComboBox cb_method_encoding;

        private System.Windows.Forms.Label lbl_method_encoding;

        #endregion
    }
}