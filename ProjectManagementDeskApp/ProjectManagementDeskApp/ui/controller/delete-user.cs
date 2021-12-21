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
    public partial class delete_user : UserControl
    {
        //Initializing variable name of class to create object
        private UserModel userModel;
        private UserGateway userGateway;
        private Function func;
        public delete_user()
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
WHERE FirstName LIKE '%%' AND AdminId={Properties.Settings.Default.UserId}
EXCEPT
SELECT  FirstName+' '+SurName + ' | '+CAST(UserId AS nvarchar) txt FROM Users  
WHERE UserId='{Properties.Settings.Default.UserId}' AND AdminId={Properties.Settings.Default.UserId}
EXCEPT
SELECT  CAST(UserId AS nvarchar) + ' | '+FirstName+' '+SurName txt FROM Users  
WHERE  UserId='{Properties.Settings.Default.UserId}' AND AdminId={Properties.Settings.Default.UserId}
) A");
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
                dateDob.Text = DateTime.ParseExact(userModel.DOB, "dd/MM/yyyy", null).ToString();
                txtAddress.Text = userModel.Address;
                txtEmail.Text = userModel.Email;
                txtPassword.Text = userModel.Password;
            }
            else
            {
                MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsExist()
        {
            bool ans = false;
            string x = func.IsExist($@"SELECT USERID FROM AssignProjects WHERE UserId='{txtUserId.Text}' AND AdminId={Properties.Settings.Default.UserId}");
            if (x != "")
            {
                ans = true;
            }

            return ans;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "")
            {
                MessageBox.Show("Please choose an user first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (IsExist())
                {
                    DialogResult dialogResult = MessageBox.Show("A project already assigned to this user.You can\'t remove this user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        Refresh();
                    }
                }
                else
                {

                    DialogResult dialogResult = MessageBox.Show("Are you sure want to remove this user?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (dialogResult == DialogResult.Yes)
                    {
                        userModel.UserId = Convert.ToInt32(txtUserId.Text);
                        bool ans = userGateway.DeleteUser(userModel);
                        if (ans)
                        {
                            MessageBox.Show("User removed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Refresh();
                        }
                    }
                    else
                    {
                        Refresh();
                    }
                }
            }
        }
        private void Refresh()
        {
            txtSearch.Text = txtFirstName.Text = txtLastName.Text =
                txtEmail.Text = txtPassword.Text = txtAddress.Text = txtUserId.Text = "";
            dateDob.Text = "";
            //autocomplete
           InitialCode();
        }
    }
}
