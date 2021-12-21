using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataFillingSoftDeskApp.ProjectClass;
using ProjectManagementDeskApp.ProjectClass.Gateway;
using ProjectManagementDeskApp.ProjectClass.Model;

namespace ProjectManagementDeskApp.ui.controller
{
    public partial class update_user : UserControl
    {
        //Initializing variable name of class to create object
        private UserModel userModel;
        private UserGateway userGateway;
        private Function func;

        public update_user()
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
            //label text declare
            lblSearch.Text = "Search by User Id\r\n or Name:";
            //autocomplete search box data from database
            func.AutoCompleteTextBox(txtSearch, $@"select * from (
SELECT  CAST(UserId AS nvarchar) + ' | '+FirstName+' '+SurName txt FROM Users  
WHERE UserId LIKE '%%' AND AdminId={Properties.Settings.Default.UserId}
union
SELECT  FirstName+' '+SurName + ' | '+CAST(UserId AS nvarchar) txt FROM Users  
WHERE FirstName LIKE '%%' AND AdminId={Properties.Settings.Default.UserId} ) A");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                userModel = userGateway.GetUserByData(txtSearch.Text);
                if (userModel == null)
                {
                    MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtUserId.Text = userModel.UserId.ToString();
                txtFirstName.Text = userModel.FirstName;
                txtLastName.Text = userModel.SurName;
                dateDob.Text = Convert.ToDateTime(userModel.DOB).ToString("dd/MM/yyyy");
                txtAddress.Text = userModel.Address;
                txtEmail.Text = userModel.Email;
                txtPassword.Text = userModel.Password;
            }
            else
            {
                MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
                userModel.UserId = Convert.ToInt32(txtUserId.Text);
                userModel.FirstName = txtFirstName.Text;
                userModel.SurName = txtLastName.Text;
                userModel.DOB = dateDob.Text;
                userModel.Address = txtAddress.Text;
                userModel.Email = txtEmail.Text;
                userModel.Password = txtPassword.Text;
                bool ans = userGateway.UpdateUser(userModel); //calling method from gateway
                if (ans)
                {
                    MessageBox.Show("User data updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                    InitialCode();
                }
                else
                {
                    MessageBox.Show("Failed to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Refresh()
        {
            txtSearch.Text = txtFirstName.Text = txtLastName.Text =
                  txtEmail.Text = txtPassword.Text = txtAddress.Text = txtUserId.Text = "";
            dateDob.Text = "";
            func.AutoCompleteTextBox(txtSearch, $@"select * from (
SELECT  CAST(UserId AS nvarchar) + ' | '+FirstName+' '+SurName txt FROM Users  
WHERE UserId LIKE '%%' AND AdminId={Properties.Settings.Default.UserId}
union
SELECT  FirstName+' '+SurName + ' | '+CAST(UserId AS nvarchar) txt FROM Users  
WHERE FirstName LIKE '%%' AND AdminId={Properties.Settings.Default.UserId}) A");
        }
    }
}
