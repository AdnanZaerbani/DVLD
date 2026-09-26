namespace DVLD_System
{
    partial class frmDetainLicense
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
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD_System.ctrlDriverLicenseInfoWithFilter();
            this.lblTitle = new System.Windows.Forms.Label();
            this.llShowLicensesInfo = new System.Windows.Forms.LinkLabel();
            this.llShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeatin = new System.Windows.Forms.Button();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.txtbFineFees = new System.Windows.Forms.TextBox();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(12, 73);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(1035, 397);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(396, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(251, 37);
            this.lblTitle.TabIndex = 57;
            this.lblTitle.Text = "Detain License ";
            // 
            // llShowLicensesInfo
            // 
            this.llShowLicensesInfo.AutoSize = true;
            this.llShowLicensesInfo.Enabled = false;
            this.llShowLicensesInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicensesInfo.Location = new System.Drawing.Point(216, 643);
            this.llShowLicensesInfo.Name = "llShowLicensesInfo";
            this.llShowLicensesInfo.Size = new System.Drawing.Size(148, 20);
            this.llShowLicensesInfo.TabIndex = 75;
            this.llShowLicensesInfo.TabStop = true;
            this.llShowLicensesInfo.Text = "Show Licenses Info";
            this.llShowLicensesInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicensesInfo_LinkClicked);
            // 
            // llShowLicensesHistory
            // 
            this.llShowLicensesHistory.AutoSize = true;
            this.llShowLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicensesHistory.Location = new System.Drawing.Point(24, 643);
            this.llShowLicensesHistory.Name = "llShowLicensesHistory";
            this.llShowLicensesHistory.Size = new System.Drawing.Size(169, 20);
            this.llShowLicensesHistory.TabIndex = 74;
            this.llShowLicensesHistory.TabStop = true;
            this.llShowLicensesHistory.Text = "Show Licenses History";
            this.llShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicensesHistory_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbFineFees);
            this.groupBox1.Controls.Add(this.lblCreatedBy);
            this.groupBox1.Controls.Add(this.pictureBox10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblLicenseID);
            this.groupBox1.Controls.Add(this.pictureBox7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblDetainDate);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblDetainID);
            this.groupBox1.Controls.Add(this.pictureBox9);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 476);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1035, 140);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detain Info";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(748, 70);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(35, 20);
            this.lblCreatedBy.TabIndex = 108;
            this.lblCreatedBy.Text = "N/A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(481, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 20);
            this.label9.TabIndex = 106;
            this.label9.Text = "Created By :";
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.Location = new System.Drawing.Point(748, 36);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(35, 20);
            this.lblLicenseID.TabIndex = 102;
            this.lblLicenseID.Text = "N/A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(481, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 20);
            this.label8.TabIndex = 100;
            this.label8.Text = "License ID :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 88;
            this.label4.Text = "Fine Fees :";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.Location = new System.Drawing.Point(285, 70);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(35, 20);
            this.lblDetainDate.TabIndex = 84;
            this.lblDetainDate.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 82;
            this.label2.Text = "Detain Date  :";
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainID.Location = new System.Drawing.Point(285, 36);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(35, 20);
            this.lblDetainID.TabIndex = 81;
            this.lblDetainID.Text = "N/A";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 20);
            this.label11.TabIndex = 79;
            this.label11.Text = "Detain ID :";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_System.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(802, 636);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 37);
            this.btnClose.TabIndex = 73;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeatin
            // 
            this.btnDeatin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeatin.Enabled = false;
            this.btnDeatin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeatin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeatin.Image = global::DVLD_System.Properties.Resources.International_325;
            this.btnDeatin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeatin.Location = new System.Drawing.Point(922, 636);
            this.btnDeatin.Name = "btnDeatin";
            this.btnDeatin.Size = new System.Drawing.Size(125, 37);
            this.btnDeatin.TabIndex = 72;
            this.btnDeatin.Text = "Detain";
            this.btnDeatin.UseVisualStyleBackColor = true;
            this.btnDeatin.Click += new System.EventHandler(this.btnDeatin_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DVLD_System.Properties.Resources.User_32__23;
            this.pictureBox10.Location = new System.Drawing.Point(690, 70);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(24, 20);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 107;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD_System.Properties.Resources.LocalDriving_License2;
            this.pictureBox7.Location = new System.Drawing.Point(690, 36);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(24, 20);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 101;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_System.Properties.Resources.money_324;
            this.pictureBox3.Location = new System.Drawing.Point(227, 104);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 89;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.Calendar_323;
            this.pictureBox1.Location = new System.Drawing.Point(227, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 83;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::DVLD_System.Properties.Resources.Number_324;
            this.pictureBox9.Location = new System.Drawing.Point(227, 36);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(24, 20);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 80;
            this.pictureBox9.TabStop = false;
            // 
            // txtbFineFees
            // 
            this.txtbFineFees.BackColor = System.Drawing.SystemColors.Control;
            this.txtbFineFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbFineFees.Location = new System.Drawing.Point(289, 102);
            this.txtbFineFees.Name = "txtbFineFees";
            this.txtbFineFees.Size = new System.Drawing.Size(162, 26);
            this.txtbFineFees.TabIndex = 109;
            this.txtbFineFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFineFees_KeyPress);
            this.txtbFineFees.Validated += new System.EventHandler(this.txtbFineFees_Validated);
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 682);
            this.Controls.Add(this.llShowLicensesInfo);
            this.Controls.Add(this.llShowLicensesHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeatin);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detain License";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel llShowLicensesInfo;
        private System.Windows.Forms.LinkLabel llShowLicensesHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDeatin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtbFineFees;
        private System.Windows.Forms.ErrorProvider epError;
    }
}