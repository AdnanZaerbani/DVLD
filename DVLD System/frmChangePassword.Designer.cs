namespace DVLD_System
{
    partial class frmChangePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.txtbCurrentPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtbConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtbNewPassword = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlUserCard1 = new DVLD_System.ctrlUserCard();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbCurrentPassword
            // 
            this.txtbCurrentPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtbCurrentPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCurrentPassword.Location = new System.Drawing.Point(226, 406);
            this.txtbCurrentPassword.Name = "txtbCurrentPassword";
            this.txtbCurrentPassword.PasswordChar = '*';
            this.txtbCurrentPassword.Size = new System.Drawing.Size(145, 26);
            this.txtbCurrentPassword.TabIndex = 1;
            this.txtbCurrentPassword.TextChanged += new System.EventHandler(this.txtbCurrentPassword_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Current Password :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.Number_321;
            this.pictureBox1.Location = new System.Drawing.Point(196, 406);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Confirm Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 440);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "New Password :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_System.Properties.Resources.Number_321;
            this.pictureBox2.Location = new System.Drawing.Point(196, 471);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_System.Properties.Resources.Number_321;
            this.pictureBox3.Location = new System.Drawing.Point(196, 440);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // txtbConfirmPassword
            // 
            this.txtbConfirmPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtbConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbConfirmPassword.Location = new System.Drawing.Point(226, 471);
            this.txtbConfirmPassword.Name = "txtbConfirmPassword";
            this.txtbConfirmPassword.PasswordChar = '*';
            this.txtbConfirmPassword.Size = new System.Drawing.Size(145, 26);
            this.txtbConfirmPassword.TabIndex = 3;
            this.txtbConfirmPassword.TextChanged += new System.EventHandler(this.txtbConfirmPassword_TextChanged);
            // 
            // txtbNewPassword
            // 
            this.txtbNewPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtbNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbNewPassword.Location = new System.Drawing.Point(226, 440);
            this.txtbNewPassword.Name = "txtbNewPassword";
            this.txtbNewPassword.PasswordChar = '*';
            this.txtbNewPassword.Size = new System.Drawing.Size(145, 26);
            this.txtbNewPassword.TabIndex = 2;
            this.txtbNewPassword.TextChanged += new System.EventHandler(this.txtbNewPassword_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_System.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(769, 562);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 37);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_System.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(889, 562);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 37);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // ctrlUserCard1
            // 
            this.ctrlUserCard1.Location = new System.Drawing.Point(12, 12);
            this.ctrlUserCard1.Name = "ctrlUserCard1";
            this.ctrlUserCard1.Size = new System.Drawing.Size(991, 388);
            this.ctrlUserCard1.TabIndex = 0;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 611);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtbNewPassword);
            this.Controls.Add(this.txtbConfirmPassword);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtbCurrentPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlUserCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlUserCard ctrlUserCard1;
        private System.Windows.Forms.TextBox txtbCurrentPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtbConfirmPassword;
        private System.Windows.Forms.TextBox txtbNewPassword;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider epError;
    }
}