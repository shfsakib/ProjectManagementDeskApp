using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataFillingSoftDeskApp.ProjectClass;
using ProjectManagementDeskApp.ProjectClass.Gateway;
using ProjectManagementDeskApp.ProjectClass.Model.ViewModel;

namespace ProjectManagementDeskApp.ui.controller
{
    public partial class report : UserControl
    {
        private Function func;
        private ProjectGateway projectGateway;
        private ProjectReportViewModel projectReportViewModel;
        public report()
        {
            InitializeComponent();
            func = Function.GetInstance();
            projectGateway = ProjectGateway.GetInstance();
            projectReportViewModel = ProjectReportViewModel.GetInstance();
            LoadData();
        }

        private void LoadData()
        {
            lblCritical.Text = func.IsExist($@"SELECT COUNT(ProjectId) FROM AssignProjects WHERE Convert(date,EndDate,103)<='{DateTime.Now.AddDays(10).ToString("dd/MM/yyyy")}' AND CONVERT(nvarchar,CONVERT(DATE,EndDate,103),103)>='{DateTime.Now.ToString("dd/MM/yyyy")}'");
            lblOngoing.Text = func.IsExist($@"SELECT COUNT(ProjectId) FROM AssignProjects WHERE CONVERT(nvarchar,CONVERT(DATE,EndDate,103),103)>='{DateTime.Now.ToString("dd/MM/yyyy")}'");
            lblComplete.Text = func.IsExist($@"SELECT COUNT(ProjectId) FROM AssignProjects WHERE CONVERT(nvarchar,CONVERT(DATE,EndDate,103),103)<'{DateTime.Now.ToString("dd/MM/yyyy")}'");
            string zero = func.IsExist($@"SELECT CAST(SUM(Progress)*1.0/SUM(Total)*100 AS DECIMAL(16,0)) Total FROM(SELECT COUNT(Progress) Progress,0 Total FROM Projects WHERE Progress='0' OR Progress='0%'
UNION
SELECT 0 Progress,COUNT(ProjectId) Total FROM Projects)A");
            string twentyFive = func.IsExist($@"SELECT CAST(SUM(Progress)*1.0/SUM(Total)*100 AS DECIMAL(16,0)) Total FROM(SELECT COUNT(Progress) Progress,0 Total FROM Projects WHERE Progress='25' OR Progress='25%'
UNION
SELECT 0 Progress,COUNT(ProjectId) Total FROM Projects)A");
            string fifty = func.IsExist($@"SELECT CAST(SUM(Progress)*1.0/SUM(Total)*100 AS DECIMAL(16,0)) Total FROM(SELECT COUNT(Progress) Progress,0 Total FROM Projects WHERE Progress='50' OR Progress='50%'
UNION
SELECT 0 Progress,COUNT(ProjectId) Total FROM Projects)A");
            string seventyFive = func.IsExist($@"SELECT CAST(SUM(Progress)*1.0/SUM(Total)*100 AS DECIMAL(16,0)) Total FROM(SELECT COUNT(Progress) Progress,0 Total FROM Projects WHERE Progress='75' OR Progress='75%'
UNION
SELECT 0 Progress,COUNT(ProjectId) Total FROM Projects)A");
            string hundred = func.IsExist($@"SELECT CAST(SUM(Progress)*1.0/SUM(Total)*100 AS DECIMAL(16,0)) Total FROM(SELECT COUNT(Progress) Progress,0 Total FROM Projects WHERE Progress='100' OR Progress='100%'
UNION
SELECT 0 Progress,COUNT(ProjectId) Total FROM Projects)A");
            //progressSeries
            progressChart.Titles.Add(" ");
            progressChart.Font = new System.Drawing.Font("Times", 16f);
            if (zero != "0")
            {
                progressChart.Series["progressSeries"].Points.AddXY("Underperforming 0-20%", zero);

            }
            if (twentyFive != "0")
            {
                progressChart.Series["progressSeries"].Points.AddXY("Performing 20-40%", twentyFive);
            }
            if (fifty != "0")
            {
                progressChart.Series["progressSeries"].Points.AddXY("Average 40-60%", fifty);
            }
            if (seventyFive != "0")
            {
                progressChart.Series["progressSeries"].Points.AddXY("Achieving 60-80%", seventyFive);
            }
            if (hundred != "0")
            {
                progressChart.Series["progressSeries"].Points.AddXY("OverAchieving 80-100%", hundred);
            }

            //project report data binding
            BindProjectReport(comboEntity.Text);
        }

        private void BindProjectReport(string entity)
        {
            dataProjectGrid.Rows.Clear();
            List<ProjectReportViewModel> projectReportViewModelList = new List<ProjectReportViewModel>();
            projectReportViewModelList = projectGateway.GetProjectReportData(entity);
            foreach (ProjectReportViewModel model in projectReportViewModelList)
            {
                string userId = model.UserId;
                string FirstName = model.FirstName;
                string SurName = model.SurName;
                string projectAssigned = model.ProjectAssignedTo;
                string progress = model.ProgressUrl;
                string priority = model.Priority;
                dataProjectGrid.Rows.Add(userId, FirstName, SurName, projectAssigned, File.ReadAllBytes(progress), priority);
            }
            dataProjectGrid.Columns[3].Width = 250;
        }
        private void comboEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProjectReport(comboEntity.Text);
        }

        private void comboPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPriority.Text != "")
            {
                dataProjectGrid.Rows.Clear();
                List<ProjectReportViewModel> projectReportViewModelList = new List<ProjectReportViewModel>();
                projectReportViewModelList = projectGateway.GetProjectReportData(comboEntity.Text);
                foreach (ProjectReportViewModel model in projectReportViewModelList)
                {
                    if (model.Priority == comboPriority.Text)
                    {

                        string userId = model.UserId;
                        string FirstName = model.FirstName;
                        string SurName = model.SurName;
                        string projectAssigned = model.ProjectAssignedTo;
                        string progress = model.ProgressUrl;
                        string priority = model.Priority;
                        dataProjectGrid.Rows.Add(userId, FirstName, SurName, projectAssigned, File.ReadAllBytes(progress), priority);

                    }
                }
                dataProjectGrid.Columns[3].Width = 250;
            }
            else
            {
                BindProjectReport(comboEntity.Text);
            }
        }
    }
}
