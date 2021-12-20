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
using ProjectManagementDeskApp.ui;

namespace ProjectManagementDeskApp
{
    public partial class Login : Form
    {
        private Point mouse_offset;
        //declare class instance variable
        private Function func;
        public Login()
        {
            InitializeComponent();
            func = Function.GetInstance();
            InitialCode();
        }

        private void InitialCode()
        {
            //remove close button hover effect
            btnLoginClose.FlatAppearance.MouseOverBackColor = btnLoginClose.BackColor;
            btnLoginClose.BackColorChanged += (s, e) =>
            {
                btnLoginClose.FlatAppearance.MouseOverBackColor = btnLoginClose.BackColor;
            };
            //focus email textbox
            txtEmail.Focus();
            if (Properties.Settings.Default.Email != "")
            {
                chkRemember.Checked = true;
                txtEmail.Text = Properties.Settings.Default.Email;
                txtPass.Text = Properties.Settings.Default.Password;
                btnLogin.Focus();
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLoginClose_Click(object sender, EventArgs e)
        {
            //close application
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //hide login form and show register form
            register register = new register();
            this.Hide();
            register.Show();
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            //change form location
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                this.Location = mousePos; //move the form to the desired location
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            //set form location
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Email is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPass.Text == "")
            {
                MessageBox.Show("Password is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string password = func.IsExist($@"SELECT PASSWORD FROM Users WHERE Email='{txtEmail.Text}'");
                if (password == txtPass.Text)
                {
                    if (chkRemember.Checked)
                    {
                        Properties.Settings.Default.Email = txtEmail.Text;
                        Properties.Settings.Default.Password = txtPass.Text;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.Email = "";
                        Properties.Settings.Default.Password = "";
                        Properties.Settings.Default.Save();
                    }
                    Properties.Settings.Default.UserName = func.IsExist($@"SELECT FirstName FROM Users WHERE Email='{txtEmail.Text}'");
                    Properties.Settings.Default.UserId = func.IsExist($@"SELECT UserId FROM Users WHERE Email='{txtEmail.Text}'");
                    Properties.Settings.Default.Save();
                    //hide login form and show dashboard form
                    this.Hide();
                    dashboard dashboard = new dashboard();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Password mismatch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //minimize window
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
