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
    public partial class delete_project : UserControl
    {
        //Initializing variable name of class to create object
        private ProjectModel projectModel;
        private ProjectGateway projectGateway;
        private Function func;
        public delete_project()
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
WHERE ProjectId LIKE '%%' AND AdminId={Properties.Settings.Default.UserId}
union
SELECT  ProjectName + ' | '+CAST(ProjectId AS nvarchar) txt FROM Projects  
WHERE ProjectName LIKE '%%' AND AdminId={Properties.Settings.Default.UserId} ) A");
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
        private bool IsExist()
        {
            bool ans = false;
            string x = func.IsExist($@"SELECT ProjectId FROM AssignProjects WHERE ProjectId='{txtProjectId.Text}' AND AdminId={Properties.Settings.Default.UserId}");
            if (x != "")
            {
                ans = true;
            }

            return ans;
        }
        private bool IsProjectExist()
        {
            bool ans = false;
            string x = func.IsExist($@"SELECT ProjectId FROM AssignProjectToCompany WHERE ProjectId='{txtProjectId.Text}' AND AdminId={Properties.Settings.Default.UserId}");
            if (x != "")
            {
                ans = true;
            }

            return ans;
        }
        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            if (txtProjectId.Text == "")
            {
                MessageBox.Show("Please choose an project first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (IsExist())
                {
                    DialogResult dialogResult = MessageBox.Show("This project already assigned to a user.You can\'t remove this project.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        Refresh();
                    }
                }
                else if (IsProjectExist())
                {
                    DialogResult dialogResult = MessageBox.Show("This project already assigned to a company.You can\'t remove this project.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        Refresh();
                    }
                }
                else
                {

                    DialogResult dialogResult = MessageBox.Show("Are you sure want to remove this project?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (dialogResult == DialogResult.Yes)
                    {
                        projectModel.ProjectId = Convert.ToInt32(txtProjectId.Text);
                        bool ans = projectGateway.DeleteProject(projectModel);
                        if (ans)
                        {
                            MessageBox.Show("Project removed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Refresh();
                            InitialCode();
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
            txtSearch.Text = txtProjectId.Text = txtProjectName.Text = dateStartDate.Text = dateEndDate.Text = "";
            comboPriority.Text = "-- SELECT PRIORITY --";
            comboProgress.Text = "";
            pictureProgress.Image = Properties.Resources._0;
        }
    }
}
