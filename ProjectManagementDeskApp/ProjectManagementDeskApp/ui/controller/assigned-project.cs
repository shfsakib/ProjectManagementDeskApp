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

namespace ProjectManagementDeskApp.ui.controller
{
    public partial class assigned_project : UserControl
    {
        private Function func;
        public assigned_project()
        {
            InitializeComponent();
            func = Function.GetInstance();
            LoadGrid();
        }

        private void LoadGrid()
        {
            //load project data to grid
            func.LoadGrid(dataProjectGrid, $@"SELECT        AssignProjects.AssignId, AssignProjects.ProjectId, Projects.ProjectName, AssignProjects.StartDate, AssignProjects.EndDate, AssignProjects.Priority
FROM            AssignProjects INNER JOIN
                         Projects ON AssignProjects.ProjectId = Projects.ProjectId WHERE AssignProjects.UserId={Properties.Settings.Default.UserId} ORDER BY  AssignProjects.AssignId ASC");
            //change header text of user grid
            if (dataProjectGrid.Rows.Count > 0)
            {
                //change header text of user grid
                dataProjectGrid.Columns[1].HeaderText = "Project Id";
                dataProjectGrid.Columns[2].HeaderText = "Project Name";
                dataProjectGrid.Columns[3].HeaderText = "Start Date";
                dataProjectGrid.Columns[4].HeaderText = "End Date";
                //change project grid column width 
                dataProjectGrid.Columns[2].Width = 250;
                dataProjectGrid.Columns[3].Width = 150;
                dataProjectGrid.Columns[4].Width = 150;
                dataProjectGrid.Columns[5].Width = 150;
            }
        }
        private void btnSearchProject_Click(object sender, EventArgs e)
        {
            if (txtSearchProject.Text != "")
            {
                //info like search text
                func.LoadGrid(dataProjectGrid, $@"SELECT        AssignProjects.AssignId, AssignProjects.ProjectId, Projects.ProjectName, AssignProjects.StartDate, AssignProjects.EndDate, AssignProjects.Priority
FROM            AssignProjects INNER JOIN
                         Projects ON AssignProjects.ProjectId = Projects.ProjectId WHERE AssignProjects.UserId={Properties.Settings.Default.UserId} AND CAST(AssignProjects.ProjectId AS nvarchar)+ ' ' +ProjectName  LIKE '%{txtSearchProject.Text}%'  ORDER BY  AssignProjects.AssignId ASC");
            }
            else
            {
                //load project data to grid
                LoadGrid();
            }
        }
    }
}
