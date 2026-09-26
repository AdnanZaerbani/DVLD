namespace DVLD_System
{
    partial class frmUpdateTestType
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
            this.txtbFees = new System.Windows.Forms.TextBox();
            this.txtbTitle = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIDNum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbDescription = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbFees
            // 
            this.txtbFees.BackColor = System.Drawing.SystemColors.Control;
            this.txtbFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbFees.Location = new System.Drawing.Point(186, 345);
            this.txtbFees.Name = "txtbFees";
            this.txtbFees.Size = new System.Drawing.Size(272, 29);
            this.txtbFees.TabIndex = 3;
            this.txtbFees.Validated += new System.EventHandler(this.txtbFees_Validated);
            // 
            // txtbTitle
            // 
            this.txtbTitle.BackColor = System.Drawing.SystemColors.Control;
            this.txtbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbTitle.Location = new System.Drawing.Point(186, 140);
            this.txtbTitle.Name = "txtbTitle";
            this.txtbTitle.Size = new System.Drawing.Size(270, 29);
            this.txtbTitle.TabIndex = 1;
            this.txtbTitle.Validated += new System.EventHandler(this.txtbTitle_Validated);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.money_32;
            this.pictureBox1.Location = new System.Drawing.Point(139, 345);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_System.Properties.Resources.ApplicationTitle;
            this.pictureBox2.Location = new System.Drawing.Point(139, 140);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_System.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(221, 397);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 37);
            this.btnClose.TabIndex = 5;
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
            this.btnSave.Location = new System.Drawing.Point(341, 397);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 37);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 24);
            this.label4.TabIndex = 33;
            this.label4.Text = "Fees :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 24);
            this.label3.TabIndex = 32;
            this.label3.Text = "Title :";
            // 
            // lblIDNum
            // 
            this.lblIDNum.AutoSize = true;
            this.lblIDNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDNum.Location = new System.Drawing.Point(182, 92);
            this.lblIDNum.Name = "lblIDNum";
            this.lblIDNum.Size = new System.Drawing.Size(0, 24);
            this.lblIDNum.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 24);
            this.label2.TabIndex = 30;
            this.label2.Text = "ID :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(100, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 37);
            this.label1.TabIndex = 29;
            this.label1.Text = "Update Test Type";
            // 
            // txtbDescription
            // 
            this.txtbDescription.BackColor = System.Drawing.SystemColors.Control;
            this.txtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbDescription.Location = new System.Drawing.Point(186, 185);
            this.txtbDescription.Multiline = true;
            this.txtbDescription.Name = "txtbDescription";
            this.txtbDescription.Size = new System.Drawing.Size(270, 144);
            this.txtbDescription.TabIndex = 2;
            this.txtbDescription.Validated += new System.EventHandler(this.txtbDescription_Validated);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_System.Properties.Resources.ApplicationTitle;
            this.pictureBox3.Location = new System.Drawing.Point(139, 185);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(41, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 24);
            this.label5.TabIndex = 37;
            this.label5.Text = "Description :";
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // frmUpdateTestType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 450);
            this.Controls.Add(this.txtbDescription);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtbFees);
            this.Controls.Add(this.txtbTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblIDNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdateTestType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Test Type";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbFees;
        private System.Windows.Forms.TextBox txtbTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIDNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbDescription;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider epError;
    }
}