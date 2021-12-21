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
using ProjectManagementDeskApp.ProjectClass.Gateway;
using ProjectManagementDeskApp.ProjectClass.Model;

namespace ProjectManagementDeskApp.ui
{
    public partial class register : Form
    {
        private Point mouse_offset;
        //Initializing variable name of class to create object
        private UserModel userModel;
        private UserGateway userGateway;
        private Function func;
        public register()
        {
            InitializeComponent();
            //creating object of class
            userGateway = UserGateway.GetInstance();
            userModel = UserModel.GetInstance();
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
            //change date format in datepicker
            dateDob.Format = DateTimePickerFormat.Custom;
            dateDob.CustomFormat = "dd/MM/yyyy";
            //get userid from user table
            txtUserId.Text = func.GenerateId($@"SELECT MAX(UserId) FROM Users");
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //validation in backend
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("First Name is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtLastName.Text == "")
            {
                MessageBox.Show("Sur Name is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dateDob.Text == "")
            {
                MessageBox.Show("Date of Birth is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Address is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Email is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Password is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Properties.Settings.Default.UserId =func.GenerateId($@"SELECT MAX(UserId) FROM Users");
                Properties.Settings.Default.Save();
                //adding value to model property
                userModel.UserId = Convert.ToInt32(func.GenerateId($@"SELECT MAX(UserId) FROM Users"));
                userModel.FirstName = txtFirstName.Text;
                userModel.SurName = txtLastName.Text;
                userModel.DOB = dateDob.Text;
                userModel.Address = txtAddress.Text;
                userModel.Email = txtEmail.Text;
                userModel.Password = txtPassword.Text;
                userModel.UserType = "Admin";
                bool ans = userGateway.Insert(userModel);//calling insert method from user gateway
                if (ans)
                {
                    MessageBox.Show("Successfully Registered", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Login login = new Login();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("Failed to register", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void txtConfirmEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmEmail.Text != txtEmail.Text)
            {
                lblMessage.Text = "Email address doesn't match";
            }
            else
            {
                lblMessage.Text = "";
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblMessage.Text = "Password doesn't match";
            }
            else
            {
                lblMessage.Text = "";
            }
        }
    }
}
