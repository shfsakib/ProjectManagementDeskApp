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
    public partial class update_project : UserControl
    {
        //Initializing variable name of class to create object
        private ProjectModel projectModel;
        private ProjectGateway projectGateway;
        private Function func;
        public update_project()
        {
            InitializeComponent();
            projectGateway = ProjectGateway.GetInstance();
            projectModel = ProjectModel.GetInstance();
            func = Function.GetInstance();
            InitialCode();
        }
        private void InitialCode()
        {
            //change date format in datepicker
            dateStartDate.Format = DateTimePickerFormat.Custom;
            dateStartDate.CustomFormat = "dd/MM/yyyy";
            dateEndDate.Format = DateTimePickerFormat.Custom;
            dateEndDate.CustomFormat = "dd/MM/yyyy";
            //autocomplete search box data from database
            func.AutoCompleteTextBox(txtSearch, $@"select * from (
SELECT  CAST(ProjectId AS nvarchar) + ' | '+ProjectName txt FROM Projects  
WHERE ProjectId LIKE '%%'
union
SELECT  ProjectName + ' | '+CAST(ProjectId AS nvarchar) txt FROM Projects  
WHERE ProjectName LIKE '%%' ) A");
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                projectModel = projectGateway.GetByData(txtSearch.Text);
                if (projectModel == null)
                {
                    MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtProjectId.Text = projectModel.ProjectId.ToString();
                txtProjectName.Text = projectModel.ProjectName;
                dateStartDate.Text = DateTime.ParseExact(projectModel.StartDate, "dd/MM/yyyy", null).ToString();
                dateEndDate.Text = DateTime.ParseExact(projectModel.EndDate, "dd/MM/yyyy", null).ToString();
                comboPriority.Text = projectModel.Priority;
                if (projectModel.Progress == "0")
                {
                    projectModel.Progress = "0%";
                }
                if (projectModel.Progress == "0" || projectModel.Progress == "0%")
                {
                    pictureProgress.Image = Properties.Resources._0;
                }
                else if (projectModel.Progress == "25%")
                {
                    pictureProgress.Image = Properties.Resources._25;
                }
                else if (projectModel.Progress == "50%")
                {
                    pictureProgress.Image = Properties.Resources._50;
                }
                else if (projectModel.Progress == "75%")
                {
                    pictureProgress.Image = Properties.Resources._75;
                }
                else if (projectModel.Progress == "100%")
                {
                    pictureProgress.Image = Properties.Resources._100;
                }
                comboProgress.Text = projectModel.Progress;
            }
            else
            {
                MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboProgress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProgress.Text == "0%")
            {
                pictureProgress.Image = Properties.Resources._0;
            }
            else if (comboProgress.Text == "25%")
            {
                pictureProgress.Image = Properties.Resources._25;
            }
            else if (comboProgress.Text == "50%")
            {
                pictureProgress.Image = Properties.Resources._50;
            }
            else if (comboProgress.Text == "75%")
            {
                pictureProgress.Image = Properties.Resources._75;
            }
            else if (comboProgress.Text == "100%")
            {
                pictureProgress.Image = Properties.Resources._100;
            }
        }

        private void btnUpdateProject_Click(object sender, EventArgs e)
        {
            if (txtProjectName.Text == "")
            {
                MessageBox.Show("Project Name is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dateStartDate.Text == "")
            {
                MessageBox.Show("Start Date is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dateEndDate.Text == "")
            {
                MessageBox.Show("End Date is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboPriority.Text.ToString() == "-- SELECT PRIORITY --")
            {
                MessageBox.Show("Priority is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboProgress.Text == "")
            {
                MessageBox.Show("Progress is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                projectModel.ProjectId = Convert.ToInt32(txtProjectId.Text);
                projectModel.ProjectName = txtProjectName.Text;
                projectModel.StartDate = dateStartDate.Text;
                projectModel.EndDate = dateEndDate.Text;
                projectModel.Priority = comboPriority.Text;
                projectModel.Progress = comboProgress.Text;
                bool ans = projectGateway.UpdateProject(projectModel);//calling method from gateway
                if (ans)
                {
                    MessageBox.Show("Project updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                    InitialCode();
                }
                else
                {
                    MessageBox.Show("Failed to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void Refresh()
        {
            txtSearch.Text = txtProjectId.Text = txtProjectName.Text = dateStartDate.Text = dateEndDate.Text = "";
            comboPriority.Text = "-- SELECT PRIORITY --";
            comboProgress.Text = "";
            pictureProgress.Image = Properties.Resources._0;
        }
    }
}
