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
    public partial class assign_project_to_company : UserControl
    {
        private Function func;
        private AssignProjectCompanyGateway assignProjectCompanyGateway;
        private AssignProjectCompanyModel assignProjectCompanyModel;
        public assign_project_to_company()
        {
            InitializeComponent();
            func = Function.GetInstance();
            assignProjectCompanyGateway = AssignProjectCompanyGateway.GetInstance();
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
            func.BindComboBox(comboProject, "select project", $@"SELECT ProjectId ID, CAST(ProjectId AS nvarchar) + ' | ' +ProjectName NAME FROM Projects WHERE AdminId={Properties.Settings.Default.UserId} ORDER BY Name ASC");
            func.BindComboBox(comboCompany, "select project", $@"SELECT CompanyId ID, CAST(CompanyId AS nvarchar) + ' | ' +CompanyName NAME FROM Company WHERE AdminId={Properties.Settings.Default.UserId} ORDER BY Name ASC");
        }
        private bool IsAssignExist()
        {
            bool ans = false;
            string x = func.IsExist($@"SELECT AssignCompanyId FROM AssignProjectToCompany WHERE ProjectId='{comboProject.SelectedValue}' AND CompanyId='{comboCompany.SelectedValue}' AND EndDate>'{DateTime.Now.ToString("dd/MM/yyyy")}' AND AdminId={Properties.Settings.Default.UserId}");
            if (x != "")
            {
                ans = true;
            }
            return ans;
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
            else if (IsAssignExist())
            {
                MessageBox.Show("This project already assigned to this company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                assignProjectCompanyModel.AssignCompanyId = Convert.ToInt32(func.GenerateId($@"SELECT MAX(AssignCompanyId) FROM AssignProjectToCompany"));
                assignProjectCompanyModel.ProjectId = Convert.ToInt32(comboProject.SelectedValue);
                assignProjectCompanyModel.CompanyId = Convert.ToInt32(comboCompany.SelectedValue);
                assignProjectCompanyModel.StartDate = dateStartDate.Text;
                assignProjectCompanyModel.EndDate = dateEndDate.Text;
                assignProjectCompanyModel.Priority = comboPriority.Text;
                bool ans = assignProjectCompanyGateway.Insert(assignProjectCompanyModel);
                if (ans)
                {
                    MessageBox.Show("Project assigned to " + comboCompany.Text + " successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboProject.SelectedIndex = comboCompany.SelectedIndex = 0;
                    comboPriority.Text = "-- SELECT PRIORITY --";
                    dateStartDate.Text = dateEndDate.Text = "";
                }
                else
                {
                    MessageBox.Show("Failed to assign", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
