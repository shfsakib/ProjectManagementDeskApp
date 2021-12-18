using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataFillingSoftDeskApp.ProjectClass;
using ProjectManagementDeskApp.ProjectClass.Gateway;
using ProjectManagementDeskApp.ProjectClass.Model;

namespace ProjectManagementDeskApp.ui.controller
{
    public partial class create_user_control : UserControl
    {
        //Initializing variable name of class to create object
        private UserModel userModel;
        private UserGateway userGateway;
        private Function func;
        public create_user_control()
        {
            InitializeComponent();
            userGateway = UserGateway.GetInstance();
            userModel = UserModel.GetInstance();
            func = Function.GetInstance();
            InitialCode();
        }
        private void InitialCode()
        {
            //change date format in datepicker
            dateDob.Format = DateTimePickerFormat.Custom;
            dateDob.CustomFormat = "dd/MM/yyyy";
            //focus first name
            txtFirstName.Focus();
            //get userid from users table
            txtUserId.Text = func.GenerateId($@"SELECT MAX(UserId) FROM Users");
        }
        private void btnCreate_Click(object sender, EventArgs e)
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
                //adding value to model property
                userModel.UserId = Convert.ToInt32(func.GenerateId($@"SELECT MAX(UserId) FROM Users"));
                userModel.FirstName = txtFirstName.Text;
                userModel.SurName = txtLastName.Text;
                userModel.DOB = dateDob.Text;
                userModel.Address = txtAddress.Text;
                userModel.Email = txtEmail.Text;
                userModel.Password = txtPassword.Text;
                userModel.UserType = "Staff";
                bool ans = userGateway.Insert(userModel);//calling insert method from gateway
                if (ans)
                {
                    MessageBox.Show("User Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                    InitialCode();
                }
                else
                {
                    MessageBox.Show("Failed to create", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Refresh()
        {
            txtFirstName.Text = txtLastName.Text =
                txtEmail.Text = txtConfirmEmail.Text = txtPassword.Text = txtConfirmPassword.Text = txtAddress.Text = "";
            dateDob.Text = "";
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
