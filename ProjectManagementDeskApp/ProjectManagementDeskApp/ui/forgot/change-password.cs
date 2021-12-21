using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataFillingSoftDeskApp.ProjectClass;

namespace ProjectManagementDeskApp.ui.forgot
{
    public partial class change_password : Form
    {
        private Function function;
        public change_password()
        {
            InitializeComponent();
            function = Function.GetInstance();
        }

        private void btnForgotClose_Click(object sender, EventArgs e)
        {
            //hide this form
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

        private void txtConfrimPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text != txtConfrimPass.Text)
            {
                lblError.Text = "Password mismatch";
            }
            else
            {
                lblError.Text = "";
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                MessageBox.Show("Password is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtPass.Text != txtConfrimPass.Text)
            {
                MessageBox.Show("Password mismacth", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool ans = function.Execute($@"UPDATE USERS Set Password='{txtPass.Text}' WHERE Email='{Properties.Settings.Default.Email}'");
                if (ans)
                {
                    MessageBox.Show("Password changed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to update password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
