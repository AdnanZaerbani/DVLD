namespace DVLD_System
{
    partial class frmAddEditPerson
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
            this.ctrlPersonCard1 = new DVLD_System.ctrlAddEditPersonCard();
            this.SuspendLayout();
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(12, 12);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(895, 479);
            this.ctrlPersonCard1.TabIndex = 0;
            // 
            // frmAddEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 492);
            this.Controls.Add(this.ctrlPersonCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit Person Info.";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlAddEditPersonCard ctrlPersonCard1;
    }
}