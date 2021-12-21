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
    public partial class delete_assigned_project_to_company : UserControl
    {
        //initializa object

        private Function func;
        private AssignProjectCompanyGateway assignProjectCompanyGateway;
        private AssignProjectCompanyViewModel assignProjectCompanyViewModel;
        private AssignProjectCompanyModel assignProjectCompanyModel;
        public delete_assigned_project_to_company()
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
            func.BindComboBox(comboProject, "select project", $@"SELECT ProjectId ID, CAST(ProjectId AS nvarchar) + ' | ' +ProjectName NAME FROM Projects WHERE AdminId={Properties.Settings.Default.UserId} ORDER BY Name ASC");
            func.BindComboBox(comboCompany, "select project", $@"SELECT CompanyId ID, CAST(CompanyId AS nvarchar) + ' | ' +CompanyName NAME FROM Company WHERE AdminId={Properties.Settings.Default.UserId} ORDER BY Name ASC");
            //autocomplete
            func.AutoCompleteTextBox(txtSearch, $@"select * from (
SELECT        CAST(AssignProjectToCompany.AssignCompanyId AS nvarchar) + ' | ' +Company.CompanyName AS txt 
FROM            AssignProjectToCompany INNER JOIN
                         Company ON AssignProjectToCompany.CompanyId = Company.CompanyId
WHERE AssignProjectToCompany.AssignCompanyId LIKE '%%' AND AssignProjectToCompany.AdminId={Properties.Settings.Default.UserId}
union
SELECT      Company.CompanyName + ' | ' +  CAST(AssignProjectToCompany.AssignCompanyId AS nvarchar) AS txt 
FROM            AssignProjectToCompany INNER JOIN
                         Company ON AssignProjectToCompany.CompanyId = Company.CompanyId  
WHERE Company.CompanyName LIKE '%%' AND AssignProjectToCompany.AdminId={Properties.Settings.Default.UserId} )A");
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

        private void btnDeleteAssignProject_Click(object sender, EventArgs e)
        {
            if (txtAssignId.Text == "")
            {
                MessageBox.Show("Please choose an assigned project first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to remove this Assigned project?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (dialogResult == DialogResult.Yes)
                {
                    assignProjectCompanyModel.AssignCompanyId = Convert.ToInt32(txtAssignId.Text);
                    bool ans = assignProjectCompanyGateway.DeleteAssignedProject(assignProjectCompanyModel);
                    if (ans)
                    {
                        MessageBox.Show("Assigned project removed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Refresh();
                    }
                }
                else
                {
                    Refresh();
                }
            }
        }

        private void Refresh()
        {
            comboProject.SelectedIndex = comboCompany.SelectedIndex = 0;
            comboPriority.Text = "-- SELECT PRIORITY --";
            dateStartDate.Text = dateEndDate.Text = txtSearch.Text = txtAssignId.Text = "";
            InitialCode();
        }
    }
}
