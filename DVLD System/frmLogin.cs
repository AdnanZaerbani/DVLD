using DVLD_System___BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DVLD_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtbUsername.Text) && !string.IsNullOrWhiteSpace(txtbPassword.Text.ToString()))
            {
                if (clsUser.IsUserExist(txtbUsername.Text, txtbPassword.Text))
                {
                    short IsActive = 1;
                    if (clsUser.IsUserActive(txtbUsername.Text, IsActive))
                    {
                        if (chbRememberMe.Checked)
                        {
                            File.WriteAllLines("LoginInfo.txt", new string[]
                            {
                             txtbUsername.Text,
                             txtbPassword.Text
                            });
                        }
                        else
                        {
                            if (File.Exists("LoginInfo.txt"))
                                File.Delete("LoginInfo.txt");
                        }

                        frmMain frm = new frmMain();

                        frm.FormClosed += (s, args) =>
                        {
                            frmLogin login = new frmLogin();
                            login.Show();
                        };
                        GlobalSettings.CurrentUser =clsUser.Find(txtbUsername.Text);
                        frm.ShowDialog();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Your account is disactiveded.\nPlease contact your Admin.", "Access denied for User", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("The Username and Password must not be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string filePath = "LoginInfo.txt";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length >= 2)
                {
                    txtbUsername.Text = lines[0];
                    txtbPassword.Text = lines[1];

                    chbRememberMe.Checked = true;
                }
            }
        }
    }
}
