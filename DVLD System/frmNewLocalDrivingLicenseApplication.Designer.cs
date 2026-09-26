namespace DVLD_System
{
    partial class frmNewLocalDrivingLicenseApplication
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
            this.tcNewLocalLicense = new System.Windows.Forms.TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.tpApplicationInfo = new System.Windows.Forms.TabPage();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter1 = new DVLD_System.ctrlPersonCardWithFilter();
            this.tcNewLocalLicense.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tcNewLocalLicense
            // 
            this.tcNewLocalLicense.Controls.Add(this.tpPersonalInfo);
            this.tcNewLocalLicense.Controls.Add(this.tpApplicationInfo);
            this.tcNewLocalLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcNewLocalLicense.Location = new System.Drawing.Point(12, 154);
            this.tcNewLocalLicense.Name = "tcNewLocalLicense";
            this.tcNewLocalLicense.SelectedIndex = 0;
            this.tcNewLocalLicense.Size = new System.Drawing.Size(1002, 459);
            this.tcNewLocalLicense.TabIndex = 0;
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.Controls.Add(this.btnNext);
            this.tpPersonalInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tpPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpPersonalInfo.Location = new System.Drawing.Point(4, 29);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonalInfo.Size = new System.Drawing.Size(994, 426);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "Personal Info";
            this.tpPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::DVLD_System.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(863, 370);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(114, 37);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpApplicationInfo
            // 
            this.tpApplicationInfo.Controls.Add(this.lblCurrentUser);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.tpApplicationInfo.Controls.Add(this.lblCurrentDate);
            this.tpApplicationInfo.Controls.Add(this.lblPersonID);
            this.tpApplicationInfo.Controls.Add(this.cbLicenseClasses);
            this.tpApplicationInfo.Controls.Add(this.pictureBox5);
            this.tpApplicationInfo.Controls.Add(this.pictureBox4);
            this.tpApplicationInfo.Controls.Add(this.pictureBox3);
            this.tpApplicationInfo.Controls.Add(this.pictureBox1);
            this.tpApplicationInfo.Controls.Add(this.label5);
            this.tpApplicationInfo.Controls.Add(this.label4);
            this.tpApplicationInfo.Controls.Add(this.label3);
            this.tpApplicationInfo.Controls.Add(this.label2);
            this.tpApplicationInfo.Controls.Add(this.pictureBox2);
            this.tpApplicationInfo.Controls.Add(this.label1);
            this.tpApplicationInfo.Location = new System.Drawing.Point(4, 29);
            this.tpApplicationInfo.Name = "tpApplicationInfo";
            this.tpApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpApplicationInfo.Size = new System.Drawing.Size(994, 426);
            this.tpApplicationInfo.TabIndex = 1;
            this.tpApplicationInfo.Text = "Application Info";
            this.tpApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.Location = new System.Drawing.Point(247, 227);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(38, 20);
            this.lblCurrentUser.TabIndex = 27;
            this.lblCurrentUser.Text = "N/A";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(247, 187);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(38, 20);
            this.lblApplicationFees.TabIndex = 26;
            this.lblApplicationFees.Text = "N/A";
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDate.Location = new System.Drawing.Point(247, 111);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(38, 20);
            this.lblCurrentDate.TabIndex = 25;
            this.lblCurrentDate.Text = "N/A";
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(247, 74);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(49, 20);
            this.lblPersonID.TabIndex = 24;
            this.lblPersonID.Text = "[???]";
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.BackColor = System.Drawing.SystemColors.Control;
            this.cbLicenseClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Location = new System.Drawing.Point(251, 146);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(283, 28);
            this.cbLicenseClasses.TabIndex = 23;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_System.Properties.Resources.User_32__2;
            this.pictureBox5.Location = new System.Drawing.Point(217, 227);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(24, 20);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_System.Properties.Resources.money_321;
            this.pictureBox4.Location = new System.Drawing.Point(217, 187);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 20);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_System.Properties.Resources.Renew_Driving_License_321;
            this.pictureBox3.Location = new System.Drawing.Point(217, 149);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.Calendar_321;
            this.pictureBox1.Location = new System.Drawing.Point(217, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Created By :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Application Fees :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "License Class :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Application Date :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_System.Properties.Resources.Number_322;
            this.pictureBox2.Location = new System.Drawing.Point(217, 74);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "D.L.Application ID :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(226, 66);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(597, 37);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "New Local Driving License Application";
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_System.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(900, 615);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 37);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_System.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(780, 615);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 37);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(7, 8);
            this.ctrlPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(984, 372);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // frmNewLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 666);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tcNewLocalLicense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Local Driving License Application";
            this.tcNewLocalLicense.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpApplicationInfo.ResumeLayout(false);
            this.tpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcNewLocalLicense;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.TabPage tpApplicationInfo;
        private ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Label lblPersonID;
    }
}