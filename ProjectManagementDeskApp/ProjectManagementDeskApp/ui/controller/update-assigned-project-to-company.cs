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
using ProjectManagementDeskApp.ProjectClass.Model.ViewModel;

namespace ProjectManagementDeskApp.ui.controller
{
    public partial class update_assign_project_to_company : UserControl
    {
        private Function func;
        private AssignProjectCompanyGateway assignProjectCompanyGateway;
        private AssignProjectCompanyViewModel assignProjectCompanyViewModel;
        private AssignProjectCompanyModel assignProjectCompanyModel;
        public update_assign_project_to_company()
        {
            InitializeComponent();
            func = Function.GetInstance();
            assignProjectCompanyGateway = AssignProjectCompanyGateway.GetInstance();
            assignProjectCompanyViewModel = AssignProjectCompanyViewModel.GetInstance();
            assignProjectCompanyModel = AssignProjectCompanyModel.GetInstance();
            InitialCode();
        }
        private void InitialCode()
        {
            //change date format in datepicker
            dateStartDate.Format = DateTimePickerFormat.Custom;
            dateStartDate.CustomFormat = "dd/MM/yyyy";
            //change date format in datepicker
            dateEndDate.Format = DateTimePickerFormat.Custom;
            dateEndDate.CustomFormat = "dd/MM/yyyy";
            //bind combobox from database
            func.BindComboBox(comboProject, "select project", $@"SELECT ProjectId ID, CAST(ProjectId AS nvarchar) + ' | ' +ProjectName NAME FROM Projects ORDER BY Name ASC");
            func.BindComboBox(comboCompany, "select project", $@"SELECT CompanyId ID, CAST(CompanyId AS nvarchar) + ' | ' +CompanyName NAME FROM Company ORDER BY Name ASC");
            //autocomplete
            func.AutoCompleteTextBox(txtSearch, $@"select * from (
SELECT        CAST(AssignProjectToCompany.AssignCompanyId AS nvarchar) + ' | ' +Company.CompanyName AS txt 
FROM            AssignProjectToCompany INNER JOIN
                         Company ON AssignProjectToCompany.CompanyId = Company.CompanyId
WHERE AssignProjectToCompany.AssignCompanyId LIKE '%%'
union
SELECT      Company.CompanyName + ' | ' +  CAST(AssignProjectToCompany.AssignCompanyId AS nvarchar) AS txt 
FROM            AssignProjectToCompany INNER JOIN
                         Company ON AssignProjectToCompany.CompanyId = Company.CompanyId  
WHERE Company.CompanyName LIKE '%%' )A");
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                assignProjectCompanyViewModel = assignProjectCompanyGateway.GetByData(txtSearch.Text);
                if (assignProjectCompanyViewModel == null)
                {
                    MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtAssignId.Text = assignProjectCompanyViewModel.AssignCompanyId.ToString();
                comboProject.Text = assignProjectCompanyViewModel.ProjectName;
                comboCompany.Text = assignProjectCompanyViewModel.CompanyName;
                dateStartDate.Text = DateTime.ParseExact(assignProjectCompanyViewModel.StartDate, "dd/MM/yyyy", null).ToString();
                dateEndDate.Text = DateTime.ParseExact(assignProjectCompanyViewModel.EndDate, "dd/MM/yyyy", null).ToString();
                comboPriority.Text = assignProjectCompanyViewModel.Priority;
            }
            else
            {
                MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAssignProject_Click(object sender, EventArgs e)
        {
            if (comboProject.SelectedIndex <= 0)
            {
                MessageBox.Show("Project is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboCompany.SelectedIndex <= 0)
            {
                MessageBox.Show("Company is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboPriority.SelectedIndex < 0)
            {
                MessageBox.Show("Priority is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                assignProjectCompanyModel.AssignCompanyId = Convert.ToInt32(txtAssignId.Text);
                assignProjectCompanyModel.ProjectId = Convert.ToInt32(comboProject.SelectedValue);
                assignProjectCompanyModel.CompanyId = Convert.ToInt32(comboCompany.SelectedValue);
                assignProjectCompanyModel.StartDate = dateStartDate.Text;
                assignProjectCompanyModel.EndDate = dateEndDate.Text;
                assignProjectCompanyModel.Priority = comboPriority.Text;
                bool ans = assignProjectCompanyGateway.UpdateAssignedCompany(assignProjectCompanyModel);
                if (ans)
                {
                    MessageBox.Show("Project assigned to " + comboCompany.Text + " updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboProject.SelectedIndex = comboCompany.SelectedIndex = 0;
                    comboPriority.Text = "-- SELECT PRIORITY --";
                    dateStartDate.Text = dateEndDate.Text = txtSearch.Text = txtAssignId.Text = "";
                }
                else
                {
                    MessageBox.Show("Failed to update assign", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
