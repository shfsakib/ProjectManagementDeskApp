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
    public partial class create_company : UserControl
    {
        //Initializing variable name of class to create object
        private CompanyModel companyModel;
        private CompanyGateway companyGateway;
        private Function func;
        public create_company()
        {
            InitializeComponent();
            companyGateway = CompanyGateway.GetInstance();
            companyModel = CompanyModel.GetInstance();
            func = Function.GetInstance();
            InitialCode();
        }
        private void InitialCode()
        {
            //get userid from company table
            txtCompanyId.Text = func.GenerateId($@"SELECT MAX(CompanyId) FROM Company WHERE AdminId={Properties.Settings.Default.UserId}");
        }
        private bool IsNameExist()
        {
            bool ans = false;
            string x = func.IsExist($@"SELECT CompanyName FROM Company WHERE CompanyName='{txtCompanyName.Text}' AND AdminId={Properties.Settings.Default.UserId}");
            if (x != "")
            {
                ans = true;
            }

            return ans;
        }
        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            //validation in backend
            if (txtCompanyName.Text == "")
            {
                MessageBox.Show("Company name is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtCompanyLocation.Text == "")
            {
                MessageBox.Show("Company location is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (IsNameExist())
            {
                MessageBox.Show("Company name already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                companyModel.CompanyId = Convert.ToInt32(func.GenerateId($@"SELECT MAX(CompanyId) FROM Company"));
                companyModel.CompanyName = txtCompanyName.Text;
                companyModel.CompanyLocation = txtCompanyLocation.Text;
                bool ans = companyGateway.Insert(companyModel);//calling insert method from gateway
                if (ans)
                {
                    MessageBox.Show("Company Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtCompanyName.Text = txtCompanyLocation.Text = "";
        }
    }
}
