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
using Convert = System.Convert;

namespace ProjectManagementDeskApp.ui.controller
{
    public partial class create_project : UserControl
    {
        //Initializing variable name of class to create object
        private ProjectModel projectModel;
        private ProjectGateway projectGateway;
        private Function func;
        public create_project()
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
            //focus first name
            txtProjectName.Focus();
            //get userid from projects table
            txtProjectId.Text = func.GenerateId($@"SELECT MAX(ProjectId) FROM Projects");
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
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
            else
            {
                projectModel.ProjectId = Convert.ToInt32(func.GenerateId($@"SELECT MAX(ProjectId) FROM Projects"));
                projectModel.ProjectName = txtProjectName.Text;
                projectModel.StartDate = dateStartDate.Text;
                projectModel.EndDate = dateEndDate.Text;
                projectModel.Priority = comboPriority.Text;
                projectModel.Progress = "0";
                bool ans = projectGateway.Insert(projectModel);//calling insert method from gateway
                if (ans)
                {
                    MessageBox.Show("Project Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtProjectName.Text = dateStartDate.Text = dateEndDate.Text = "";
            comboPriority.Text = "-- SELECT PRIORITY --";
        }
    }
}
