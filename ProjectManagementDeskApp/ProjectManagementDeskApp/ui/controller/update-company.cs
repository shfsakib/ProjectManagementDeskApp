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
    public partial class update_company : UserControl
    {
        //Initializing variable name of class to create object
        private CompanyModel companyModel;
        private CompanyGateway companyGateway;
        private Function func;
        public update_company()
        {
            InitializeComponent();
            companyGateway = CompanyGateway.GetInstance();
            companyModel = CompanyModel.GetInstance();
            func = Function.GetInstance();
            //autocomplete
            func.AutoCompleteTextBox(txtSearch, $@"select * from (
SELECT  CAST(CompanyId AS nvarchar) + ' | '+CompanyName txt FROM Company  
WHERE CompanyId LIKE '%%' AND AdminId={Properties.Settings.Default.UserId}
union
SELECT  CompanyName + ' | '+CAST(CompanyId AS nvarchar) txt FROM Company  
WHERE CompanyName LIKE '%%' AND AdminId={Properties.Settings.Default.UserId} ) A");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                companyModel = companyGateway.GetByData(txtSearch.Text);
                if (companyModel == null)
                {
                    MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtCompanyId.Text = companyModel.CompanyId.ToString();
                txtCompanyName.Text = companyModel.CompanyName;
                txtCompanyLocation.Text = companyModel.CompanyLocation;
            }
            else
            {
                MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Refresh()
        {
            txtSearch.Text = txtCompanyId.Text = txtCompanyName.Text = txtCompanyLocation.Text = "";
            func.AutoCompleteTextBox(txtSearch, $@"select * from (
SELECT  CAST(CompanyId AS nvarchar) + ' | '+CompanyName txt FROM Company  
WHERE CompanyId LIKE '%%' AND AdminId={Properties.Settings.Default.UserId}
union
SELECT  CompanyName + ' | '+CAST(CompanyId AS nvarchar) txt FROM Company  
WHERE CompanyName LIKE '%%' AND AdminId={Properties.Settings.Default.UserId} ) A");
        }

        private void btnUpdateCompany_Click(object sender, EventArgs e)
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
            else
            {
                companyModel.CompanyId = Convert.ToInt32(txtCompanyId.Text);
                companyModel.CompanyName = txtCompanyName.Text;
                companyModel.CompanyLocation = txtCompanyLocation.Text;
                bool ans = companyGateway.UpdateCompany(companyModel);//calling method from gateway
                if (ans)
                {
                    MessageBox.Show("Company Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                }
                else
                {
                    MessageBox.Show("Failed to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
