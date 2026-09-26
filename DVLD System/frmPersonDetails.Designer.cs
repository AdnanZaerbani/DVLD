namespace DVLD_System
{
    partial class frmPersonDetails
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
            this.ctrlPersonCardInfo1 = new DVLD_System.ctrlPersonCard();
            this.SuspendLayout();
            // 
            // ctrlPersonCardInfo1
            // 
            this.ctrlPersonCardInfo1.Location = new System.Drawing.Point(12, 12);
            this.ctrlPersonCardInfo1.Name = "ctrlPersonCardInfo1";
            this.ctrlPersonCardInfo1.Size = new System.Drawing.Size(984, 453);
            this.ctrlPersonCardInfo1.TabIndex = 0;
            // 
            // frmPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 466);
            this.Controls.Add(this.ctrlPersonCardInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Person Details";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCardInfo1;
    }
}