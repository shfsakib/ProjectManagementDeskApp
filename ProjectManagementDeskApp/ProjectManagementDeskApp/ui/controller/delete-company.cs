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
    public partial class delete_company : UserControl
    { //Initializing variable name of class to create object
        private CompanyModel companyModel;
        private CompanyGateway companyGateway;
        private Function func;
        public delete_company()
        {
            InitializeComponent();
            companyGateway = CompanyGateway.GetInstance();
            companyModel = CompanyModel.GetInstance();
            func = Function.GetInstance();
            //autocomplete
            func.AutoCompleteTextBox(txtSearch, $@"select * from (
SELECT  CAST(CompanyId AS nvarchar) + ' | '+CompanyName txt FROM Company  
WHERE CompanyId LIKE '%%'
union
SELECT  CompanyName + ' | '+CAST(CompanyId AS nvarchar) txt FROM Company  
WHERE CompanyName LIKE '%%' ) A");
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
        private bool IsExist()
        {
            bool ans = false;
            string x = func.IsExist($@"SELECT CompanyId FROM AssignProjectToCompany WHERE CompanyId='{txtCompanyId.Text}'");
            if (x != "")
            {
                ans = true;
            }

            return ans;
        }
        private void btnDeleteCompany_Click(object sender, EventArgs e)
        {
            if (txtCompanyId.Text == "")
            {
                MessageBox.Show("Please choose an company first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (IsExist())
                {
                    DialogResult dialogResult = MessageBox.Show("A project already assigned to this company.You can\'t remove this company.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        Refresh();
                    }
                }
                else
                {

                    DialogResult dialogResult = MessageBox.Show("Are you sure want to remove this company?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (dialogResult == DialogResult.Yes)
                    {
                        companyModel.CompanyId = Convert.ToInt32(txtCompanyId.Text);
                        bool ans = companyGateway.DeleteCompany(companyModel);
                        if (ans)
                        {
                            MessageBox.Show("Company removed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtSearch.Text = txtCompanyId.Text = txtCompanyName.Text = txtCompanyLocation.Text = "";
            func.AutoCompleteTextBox(txtSearch, $@"select * from (
SELECT  CAST(CompanyId AS nvarchar) + ' | '+CompanyName txt FROM Company  
WHERE CompanyId LIKE '%%'
union
SELECT  CompanyName + ' | '+CAST(CompanyId AS nvarchar) txt FROM Company  
WHERE CompanyName LIKE '%%' ) A");
        }
    }
}
