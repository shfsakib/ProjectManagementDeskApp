using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementDeskApp.ui
{
    public partial class register : Form
    {
        private Point mouse_offset;
        public register()
        {
            InitializeComponent();
            //remove close button hover effect
            btnLoginClose.FlatAppearance.MouseOverBackColor = btnLoginClose.BackColor;
            btnLoginClose.BackColorChanged += (s, e) =>
            {
                btnLoginClose.FlatAppearance.MouseOverBackColor = btnLoginClose.BackColor;
            };
            //change date format in datepicker
            dateDob.Format = DateTimePickerFormat.Custom;
            dateDob.CustomFormat = "dd/MM/yyyy";
        }

        private void btnLoginClose_Click(object sender, EventArgs e)
        {
            //close application
            Application.Exit();
        }


        private void register_MouseDown(object sender, MouseEventArgs e)
        {
            //set form location
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void register_MouseMove(object sender, MouseEventArgs e)
        {
            //change form location
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                this.Location = mousePos; //move the form to the desired location
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //hide register form and show login form
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //minimize window
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
