namespace DVLD_System
{
    partial class frmIssueDriverLicenseForTheFirstTime
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
            this.txtbNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.pbGender = new System.Windows.Forms.PictureBox();
            this.ctrlTestAppointment1 = new DVLD_System.ctrlTestAppointment();
            ((System.ComponentModel.ISupportInitialize)(this.pbGender)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbNotes
            // 
            this.txtbNotes.BackColor = System.Drawing.SystemColors.Control;
            this.txtbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbNotes.Location = new System.Drawing.Point(131, 427);
            this.txtbNotes.Multiline = true;
            this.txtbNotes.Name = "txtbNotes";
            this.txtbNotes.Size = new System.Drawing.Size(808, 126);
            this.txtbNotes.TabIndex = 63;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 427);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 62;
            this.label4.Text = "Notes  :";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_System.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(704, 559);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 37);
            this.btnClose.TabIndex = 61;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::DVLD_System.Properties.Resources.License_Type_322;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(825, 559);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(114, 37);
            this.btnIssue.TabIndex = 60;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // pbGender
            // 
            this.pbGender.Image = global::DVLD_System.Properties.Resources.Notes_32;
            this.pbGender.Location = new System.Drawing.Point(101, 427);
            this.pbGender.Name = "pbGender";
            this.pbGender.Size = new System.Drawing.Size(24, 20);
            this.pbGender.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGender.TabIndex = 59;
            this.pbGender.TabStop = false;
            // 
            // ctrlTestAppointment1
            // 
            this.ctrlTestAppointment1.Location = new System.Drawing.Point(12, 12);
            this.ctrlTestAppointment1.Name = "ctrlTestAppointment1";
            this.ctrlTestAppointment1.Size = new System.Drawing.Size(937, 409);
            this.ctrlTestAppointment1.TabIndex = 0;
            // 
            // frmIssueDriverLicenseForTheFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 606);
            this.Controls.Add(this.txtbNotes);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbGender);
            this.Controls.Add(this.ctrlTestAppointment1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmIssueDriverLicenseForTheFirstTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Driver License For The First Time";
            ((System.ComponentModel.ISupportInitialize)(this.pbGender)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlTestAppointment ctrlTestAppointment1;
        private System.Windows.Forms.TextBox txtbNotes;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbGender;
    }
}