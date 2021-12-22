using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataFillingSoftDeskApp.ProjectClass;

namespace ProjectManagementDeskApp.ui.forgot
{
    public partial class forgot_email_verify : Form
    {
        private Random random = new Random();
        private Function func;
        public forgot_email_verify()
        {
            InitializeComponent();
            func = Function.GetInstance();

        }
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
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

        private bool IsExist()
        {
            bool ans = false;
            string x = func.IsExist($@"SELECT UserId FROM Users WHERE Email='{txtEmail.Text}'");
            if (x != "")
            {
                ans = true;
            }

            return ans;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!func.IsConnected())
            {
                func.MessageBox("Please connect the internet", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Email id is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!IsExist())
                {
                    MessageBox.Show("Email id does\'t exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnSubmit.Text = "Please wait...";
                btnSubmit.Enabled = false;
                Properties.Settings.Default.Code = RandomString(8, false);
                Properties.Settings.Default.Save();
                bool ans = func.SendEmail("shfkte@gmail.com", txtEmail.Text, "Password Reset",
                    $"<h5>Hello User,</h5><br/>Your verification code is <h3>{Properties.Settings.Default.Code}</h3>",
                    "ShfS@kib2020");
                if (ans)
                {
                    Properties.Settings.Default.Email = txtEmail.Text;
                    Properties.Settings.Default.Save();
                    this.Hide();
                    verify_code verifyCode = new verify_code();
                    verifyCode.Show();
                }
                else
                {
                    MessageBox.Show("Failed to send email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
