namespace DVLD_System
{
    partial class frmStreetTestAppointments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCountRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAllTestAppointments = new System.Windows.Forms.DataGridView();
            this.cmsDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlTestAppointment1 = new DVLD_System.ctrlTestAppointment();
            this.btnAddNewAppointment = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTestAppointments)).BeginInit();
            this.cmsDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 653);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 24);
            this.label3.TabIndex = 35;
            this.label3.Text = "Appointments :";
            // 
            // lblCountRecords
            // 
            this.lblCountRecords.AutoSize = true;
            this.lblCountRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRecords.Location = new System.Drawing.Point(133, 943);
            this.lblCountRecords.Name = "lblCountRecords";
            this.lblCountRecords.Size = new System.Drawing.Size(0, 24);
            this.lblCountRecords.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 943);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 24);
            this.label2.TabIndex = 33;
            this.label2.Text = "# Records: ";
            // 
            // dgvAllTestAppointments
            // 
            this.dgvAllTestAppointments.AllowUserToAddRows = false;
            this.dgvAllTestAppointments.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAllTestAppointments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllTestAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllTestAppointments.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllTestAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllTestAppointments.ContextMenuStrip = this.cmsDetails;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllTestAppointments.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAllTestAppointments.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvAllTestAppointments.Location = new System.Drawing.Point(14, 683);
            this.dgvAllTestAppointments.MultiSelect = false;
            this.dgvAllTestAppointments.Name = "dgvAllTestAppointments";
            this.dgvAllTestAppointments.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllTestAppointments.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAllTestAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllTestAppointments.Size = new System.Drawing.Size(928, 256);
            this.dgvAllTestAppointments.TabIndex = 30;
            this.dgvAllTestAppointments.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAllTestAppointments_CellMouseDown);
            // 
            // cmsDetails
            // 
            this.cmsDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsDetails.Name = "contextMenuStrip1";
            this.cmsDetails.Size = new System.Drawing.Size(139, 80);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.edit_32;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(138, 38);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.Test_32;
            this.takeTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(138, 38);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(281, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 37);
            this.label1.TabIndex = 29;
            this.label1.Text = "Street Test Appointments";
            // 
            // ctrlTestAppointment1
            // 
            this.ctrlTestAppointment1.Location = new System.Drawing.Point(14, 250);
            this.ctrlTestAppointment1.Name = "ctrlTestAppointment1";
            this.ctrlTestAppointment1.Size = new System.Drawing.Size(939, 409);
            this.ctrlTestAppointment1.TabIndex = 27;
            // 
            // btnAddNewAppointment
            // 
            this.btnAddNewAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewAppointment.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddNewAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewAppointment.Image = global::DVLD_System.Properties.Resources.AddAppointment_32;
            this.btnAddNewAppointment.Location = new System.Drawing.Point(891, 640);
            this.btnAddNewAppointment.Name = "btnAddNewAppointment";
            this.btnAddNewAppointment.Size = new System.Drawing.Size(51, 37);
            this.btnAddNewAppointment.TabIndex = 31;
            this.btnAddNewAppointment.UseVisualStyleBackColor = true;
            this.btnAddNewAppointment.Click += new System.EventHandler(this.btnAddNewAppointment_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_System.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(828, 945);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 37);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.driving_test_512;
            this.pictureBox1.Location = new System.Drawing.Point(365, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 197);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // frmStreetTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 993);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddNewAppointment);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblCountRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAllTestAppointments);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctrlTestAppointment1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmStreetTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Street Test Appointments";
            this.Load += new System.EventHandler(this.frmStreetTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTestAppointments)).EndInit();
            this.cmsDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddNewAppointment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCountRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAllTestAppointments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ctrlTestAppointment ctrlTestAppointment1;
        private System.Windows.Forms.ContextMenuStrip cmsDetails;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}