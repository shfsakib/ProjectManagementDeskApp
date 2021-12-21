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
    public partial class update_assigned_project_to_user : UserControl
    {
        //initialize classes object
        private Function func;
        private AssignProjectGateway assignProjectGateway;
        private AssignProjectModel assignProjectModel;
        private AssignProjectViewModel assignProjectViewModel;
        public update_assigned_project_to_user()
        {
            InitializeComponent();
            func = Function.GetInstance();
            assignProjectGateway = AssignProjectGateway.GetInstance();
            assignProjectModel = AssignProjectModel.GetInstance();
            assignProjectViewModel = AssignProjectViewModel.GetInstance();
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
            func.BindComboBox(comboUser, "select project", $@"SELECT UserId ID, CAST(UserId AS nvarchar) + ' | ' +FirstName +' '+SurName NAME FROM Users WHERE UserType='Staff' AND AdminId={Properties.Settings.Default.UserId} ORDER BY Name ASC");
            //autocomplete
            func.AutoCompleteTextBox(txtSearch, $@"select * from (
SELECT        CAST(AssignProjects.AssignId AS nvarchar) + ' | ' +Projects.ProjectName AS txt 
FROM            AssignProjects INNER JOIN
                         Projects ON AssignProjects.ProjectId = Projects.ProjectId
WHERE AssignProjects.AssignId LIKE '%%' AND AssignProjects.AdminId={Properties.Settings.Default.UserId}
union
SELECT      Projects.ProjectName + ' | ' +  CAST(AssignProjects.AssignId AS nvarchar) AS txt 
FROM            AssignProjects INNER JOIN
                         Projects ON AssignProjects.ProjectId = Projects.ProjectId  
WHERE Projects.ProjectName LIKE '%%' AND AssignProjects.AdminId={Properties.Settings.Default.UserId})A");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                assignProjectViewModel = assignProjectGateway.GetByData(txtSearch.Text);
                if (assignProjectViewModel == null)
                {
                    MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtAssignId.Text = assignProjectViewModel.AssignId.ToString();
                comboProject.Text = assignProjectViewModel.ProjectName;
                comboUser.Text = assignProjectViewModel.UserName;
                dateStartDate.Text = DateTime.ParseExact(assignProjectViewModel.StartDate, "dd/MM/yyyy", null).ToString();
                dateEndDate.Text = DateTime.ParseExact(assignProjectViewModel.EndDate, "dd/MM/yyyy", null).ToString();
                comboPriority.Text = assignProjectViewModel.Priority;
            }
            else
            {
                MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateAssignProject_Click(object sender, EventArgs e)
        {
            if (comboProject.SelectedIndex <= 0)
            {
                MessageBox.Show("Project is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboUser.SelectedIndex <= 0)
            {
                MessageBox.Show("User is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboPriority.SelectedIndex < 0)
            {
                MessageBox.Show("Priority is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                assignProjectModel.AssignId = Convert.ToInt32(txtAssignId.Text);
                assignProjectModel.ProjectId = Convert.ToInt32(comboProject.SelectedValue);
                assignProjectModel.UserId = Convert.ToInt32(comboUser.SelectedValue);
                assignProjectModel.StartDate = dateStartDate.Text;
                assignProjectModel.EndDate = dateEndDate.Text;
                assignProjectModel.Priority = comboPriority.Text;
                bool ans = assignProjectGateway.UpdateAssignProject(assignProjectModel);
                if (ans)
                {
                    MessageBox.Show("Project assigned to " + comboUser.Text + " updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboProject.SelectedIndex = comboUser.SelectedIndex = 0;
                    comboPriority.Text = "-- SELECT PRIORITY --";
                    txtSearch.Text = txtAssignId.Text = dateStartDate.Text = dateEndDate.Text = "";
                }
                else
                {
                    MessageBox.Show("Failed to update assign", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
