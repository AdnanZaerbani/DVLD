namespace DVLD_System
{
    partial class frmInternationalLicenseApplications
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtbFilter = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddNewIntLicenseApplication = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCountRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvAllIntLicense = new System.Windows.Forms.DataGridView();
            this.cmsDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllIntLicense)).BeginInit();
            this.cmsDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbFilter
            // 
            this.txtbFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbFilter.Location = new System.Drawing.Point(269, 353);
            this.txtbFilter.Name = "txtbFilter";
            this.txtbFilter.Size = new System.Drawing.Size(255, 26);
            this.txtbFilter.TabIndex = 20;
            this.txtbFilter.Visible = false;
            this.txtbFilter.TextChanged += new System.EventHandler(this.txtbFilter_TextChanged);
            this.txtbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFilter_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Int.License ID",
            "Application ID",
            "Driver ID",
            "L.License ID"});
            this.cbFilterBy.Location = new System.Drawing.Point(112, 353);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(151, 28);
            this.cbFilterBy.TabIndex = 18;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 24);
            this.label3.TabIndex = 27;
            this.label3.Text = "Filter By:";
            // 
            // btnAddNewIntLicenseApplication
            // 
            this.btnAddNewIntLicenseApplication.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewIntLicenseApplication.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddNewIntLicenseApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewIntLicenseApplication.Image = global::DVLD_System.Properties.Resources.New_Application_64;
            this.btnAddNewIntLicenseApplication.Location = new System.Drawing.Point(1279, 314);
            this.btnAddNewIntLicenseApplication.Name = "btnAddNewIntLicenseApplication";
            this.btnAddNewIntLicenseApplication.Size = new System.Drawing.Size(80, 71);
            this.btnAddNewIntLicenseApplication.TabIndex = 22;
            this.btnAddNewIntLicenseApplication.UseVisualStyleBackColor = true;
            this.btnAddNewIntLicenseApplication.Click += new System.EventHandler(this.btnAddNewIntLicenseApplication_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_System.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1245, 787);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 37);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCountRecords
            // 
            this.lblCountRecords.AutoSize = true;
            this.lblCountRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRecords.Location = new System.Drawing.Point(137, 806);
            this.lblCountRecords.Name = "lblCountRecords";
            this.lblCountRecords.Size = new System.Drawing.Size(0, 24);
            this.lblCountRecords.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 806);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 24);
            this.label2.TabIndex = 25;
            this.label2.Text = "# Records: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(412, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 37);
            this.label1.TabIndex = 23;
            this.label1.Text = "International License Applications";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(523, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(317, 253);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // dgvAllIntLicense
            // 
            this.dgvAllIntLicense.AllowUserToAddRows = false;
            this.dgvAllIntLicense.AllowUserToDeleteRows = false;
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAllIntLicense.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle49;
            this.dgvAllIntLicense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllIntLicense.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle50.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle50.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllIntLicense.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle50;
            this.dgvAllIntLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle51.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle51.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle51.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle51.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllIntLicense.DefaultCellStyle = dataGridViewCellStyle51;
            this.dgvAllIntLicense.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvAllIntLicense.Location = new System.Drawing.Point(14, 391);
            this.dgvAllIntLicense.MultiSelect = false;
            this.dgvAllIntLicense.Name = "dgvAllIntLicense";
            this.dgvAllIntLicense.ReadOnly = true;
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle52.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle52.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle52.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle52.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle52.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllIntLicense.RowHeadersDefaultCellStyle = dataGridViewCellStyle52;
            this.dgvAllIntLicense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllIntLicense.Size = new System.Drawing.Size(1345, 390);
            this.dgvAllIntLicense.TabIndex = 19;
            // 
            // cmsDetails
            // 
            this.cmsDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsDetails.Name = "contextMenuStrip1";
            this.cmsDetails.Size = new System.Drawing.Size(242, 140);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.PersonDetails_32;
            this.showDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(241, 38);
            this.showDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(241, 38);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(241, 38);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // frmInternationalLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 845);
            this.ContextMenuStrip = this.cmsDetails;
            this.Controls.Add(this.txtbFilter);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddNewIntLicenseApplication);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblCountRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvAllIntLicense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInternationalLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List International License Applications";
            this.Load += new System.EventHandler(this.frmInternationalLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllIntLicense)).EndInit();
            this.cmsDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbFilter;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddNewIntLicenseApplication;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCountRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvAllIntLicense;
        private System.Windows.Forms.ContextMenuStrip cmsDetails;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}