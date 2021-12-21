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

namespace ProjectManagementDeskApp.ui.controller
{
    public partial class homeControl : UserControl
    {
        private Function func;
        public homeControl()
        {
            InitializeComponent();
            func = Function.GetInstance();
            InitialCode();
        }

        private void InitialCode()
        {
            if (Properties.Settings.Default.UserType=="Admin")
            {
                lblUser.Text = func.IsExist($@"SELECT COUNT(UserId) FROM Users WHERE UserType='Admin' AND AdminId={Properties.Settings.Default.UserId}");
                lblCompany.Text = func.IsExist($@"SELECT COUNT(CompanyId) FROM Company WHERE AdminId={Properties.Settings.Default.UserId}");
                lblProject.Text = func.IsExist($@"SELECT COUNT(ProjectId) FROM Projects WHERE AdminId={Properties.Settings.Default.UserId}");
                lblStaff.Text = func.IsExist($@"SELECT COUNT(UserId) FROM Users WHERE  UserType='Staff' AND AdminId={Properties.Settings.Default.UserId}");
            }
            else
            {
                lblUser.Text = func.IsExist($@"SELECT COUNT(UserId) FROM Users WHERE UserType='Admin'");
                lblCompany.Text = func.IsExist($@"SELECT COUNT(CompanyId) FROM Company");
                lblProject.Text = func.IsExist($@"SELECT COUNT(ProjectId) FROM Projects");
                lblStaff.Text = func.IsExist($@"SELECT COUNT(UserId) FROM Users WHERE  UserType='Staff'");
            }
        }
    }
}
