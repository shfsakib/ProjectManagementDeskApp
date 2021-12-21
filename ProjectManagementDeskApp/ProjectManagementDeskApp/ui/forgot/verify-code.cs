using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementDeskApp.ui.forgot
{
    public partial class verify_code : Form
    {
        public verify_code()
        {
            InitializeComponent();
        }

        private void btnForgotClose_Click(object sender, EventArgs e)
        {
            //hide this form
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //minimize window
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == Properties.Settings.Default.Code)
            {
                Properties.Settings.Default.Code = "";
                Properties.Settings.Default.Save();
                this.Hide();
                change_password changePassword = new change_password();
                changePassword.Show();
            }
            else
            {
                MessageBox.Show("Invalid Verification Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            forgot_email_verify forgotEmailVerify = new forgot_email_verify();
            forgotEmailVerify.Show();
        }
    }
}
