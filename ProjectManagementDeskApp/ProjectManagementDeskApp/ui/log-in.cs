using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagementDeskApp.ui;

namespace ProjectManagementDeskApp
{
    public partial class Login : Form
    {
        private Point mouse_offset;
        public Login()
        {
            InitializeComponent();
            //remove hover effect from close button
            btnLoginClose.FlatAppearance.MouseOverBackColor = btnLoginClose.BackColor;
            btnLoginClose.BackColorChanged += (s, e) =>
            {
                btnLoginClose.FlatAppearance.MouseOverBackColor = btnLoginClose.BackColor;
            };
            txtEmail.Focus();
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
            //hide login form and show dashboard form
            this.Hide();
            dashboard dashboard = new dashboard();
            dashboard.Show();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //minimize window
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
