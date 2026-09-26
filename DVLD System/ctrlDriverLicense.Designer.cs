namespace DVLD_System
{
    partial class ctrlDriverLicense
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblCountRecordsLocal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAllLicense = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblCounterRecordsInternational = new System.Windows.Forms.Label();
            this.dgvAllIntLicense = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLicense)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllIntLicense)).BeginInit();
            this.cmsDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1200, 238);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(6, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1188, 205);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblCountRecordsLocal);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dgvAllLicense);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1180, 176);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblCountRecordsLocal
            // 
            this.lblCountRecordsLocal.AutoSize = true;
            this.lblCountRecordsLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRecordsLocal.Location = new System.Drawing.Point(129, 146);
            this.lblCountRecordsLocal.Name = "lblCountRecordsLocal";
            this.lblCountRecordsLocal.Size = new System.Drawing.Size(0, 16);
            this.lblCountRecordsLocal.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "# Records: ";
            // 
            // dgvAllLicense
            // 
            this.dgvAllLicense.AllowUserToAddRows = false;
            this.dgvAllLicense.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAllLicense.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllLicense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllLicense.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllLicense.ContextMenuStrip = this.cmsDetails;
            this.dgvAllLicense.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvAllLicense.Location = new System.Drawing.Point(6, 22);
            this.dgvAllLicense.MultiSelect = false;
            this.dgvAllLicense.Name = "dgvAllLicense";
            this.dgvAllLicense.ReadOnly = true;
            this.dgvAllLicense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllLicense.Size = new System.Drawing.Size(1168, 121);
            this.dgvAllLicense.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "Local Licenses History :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblCounterRecordsInternational);
            this.tabPage2.Controls.Add(this.dgvAllIntLicense);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1180, 176);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "International";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblCounterRecordsInternational
            // 
            this.lblCounterRecordsInternational.AutoSize = true;
            this.lblCounterRecordsInternational.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounterRecordsInternational.Location = new System.Drawing.Point(129, 146);
            this.lblCounterRecordsInternational.Name = "lblCounterRecordsInternational";
            this.lblCounterRecordsInternational.Size = new System.Drawing.Size(0, 16);
            this.lblCounterRecordsInternational.TabIndex = 41;
            // 
            // dgvAllIntLicense
            // 
            this.dgvAllIntLicense.AllowUserToAddRows = false;
            this.dgvAllIntLicense.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAllIntLicense.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllIntLicense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllIntLicense.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllIntLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllIntLicense.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvAllIntLicense.Location = new System.Drawing.Point(6, 22);
            this.dgvAllIntLicense.MultiSelect = false;
            this.dgvAllIntLicense.Name = "dgvAllIntLicense";
            this.dgvAllIntLicense.ReadOnly = true;
            this.dgvAllIntLicense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllIntLicense.Size = new System.Drawing.Size(1168, 121);
            this.dgvAllIntLicense.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 40;
            this.label5.Text = "# Records: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "International Licenses History :";
            // 
            // cmsDetails
            // 
            this.cmsDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseToolStripMenuItem});
            this.cmsDetails.Name = "contextMenuStrip1";
            this.cmsDetails.Size = new System.Drawing.Size(186, 42);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(185, 38);
            this.showLicenseToolStripMenuItem.Text = "Show License Info";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // ctrlDriverLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlDriverLicense";
            this.Size = new System.Drawing.Size(1209, 247);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLicense)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllIntLicense)).EndInit();
            this.cmsDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvAllLicense;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblCountRecordsLocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCounterRecordsInternational;
        private System.Windows.Forms.DataGridView dgvAllIntLicense;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsDetails;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
    }
}
