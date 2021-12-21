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
    public partial class assign_project : UserControl
    {
        private Function func;
        private AssignProjectGateway assignProjectGateway;
        private AssignProjectModel assignProjectModel;
        public assign_project()
        {
            InitializeComponent();
            func = Function.GetInstance();
            assignProjectGateway = AssignProjectGateway.GetInstance();
            assignProjectModel = AssignProjectModel.GetInstance();
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
        }
        private bool IsAssignExist()
        {
            bool ans = false;
            string x = func.IsExist($@"SELECT AssignId FROM AssignProjects WHERE ProjectId='{comboProject.SelectedValue}' AND UserId='{comboUser.SelectedValue}' AND EndDate>'{DateTime.Now.ToString("dd/MM/yyyy")}' AND AdminId={Properties.Settings.Default.UserId}");
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
            else if (comboUser.SelectedIndex <= 0)
            {
                MessageBox.Show("User is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboPriority.SelectedIndex < 0)
            {
                MessageBox.Show("Priority is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (IsAssignExist())
            {
                MessageBox.Show("This project already assigned to this user", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                assignProjectModel.AssignId = Convert.ToInt32(func.GenerateId($@"SELECT MAX(AssignId) FROM AssignProjects"));
                assignProjectModel.ProjectId = Convert.ToInt32(comboProject.SelectedValue);
                assignProjectModel.UserId = Convert.ToInt32(comboUser.SelectedValue);
                assignProjectModel.StartDate = dateStartDate.Text;
                assignProjectModel.EndDate = dateEndDate.Text;
                assignProjectModel.Priority = comboPriority.Text;
                bool ans = assignProjectGateway.Insert(assignProjectModel);
                if (ans)
                {
                    MessageBox.Show("Project assigned to " + comboUser.Text + " successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboProject.SelectedIndex = comboUser.SelectedIndex = 0;
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
