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
    public partial class companies : UserControl
    {
        private Function func;
        public companies()
        {
            InitializeComponent();
            func=Function.GetInstance();
            LoadCompany();
        }

        private void LoadCompany()
        {
            func.LoadGrid(dataCompanyGrid,$@"SELECT     distinct	   Company.CompanyId, Company.CompanyName, Company.CompanyLocation
FROM            Users INNER JOIN
                         AssignProjects ON Users.UserId = AssignProjects.UserId INNER JOIN
                         Projects ON AssignProjects.ProjectId = Projects.ProjectId INNER JOIN
                         AssignProjectToCompany ON Projects.ProjectId = AssignProjectToCompany.ProjectId INNER JOIN
                         Company ON AssignProjectToCompany.CompanyId = Company.CompanyId WHERE AssignProjects.UserId='{Properties.Settings.Default.UserId}'");
            //change company grid column width
            dataCompanyGrid.Columns[0].Width = 120;
            dataCompanyGrid.Columns[1].Width = 250;
            dataCompanyGrid.Columns[2].Width = 500;
            //change row height
            dataCompanyGrid.RowTemplate.Height = 40;
        }

        private void btnSearchCompany_Click(object sender, EventArgs e)
        {
            if (txtSearchCompany.Text!="")
            {
                func.LoadGrid(dataCompanyGrid,
                    $@"SELECT     distinct	   Company.CompanyId, Company.CompanyName, Company.CompanyLocation
FROM            Users INNER JOIN
                         AssignProjects ON Users.UserId = AssignProjects.UserId INNER JOIN
                         Projects ON AssignProjects.ProjectId = Projects.ProjectId INNER JOIN
                         AssignProjectToCompany ON Projects.ProjectId = AssignProjectToCompany.ProjectId INNER JOIN
                         Company ON AssignProjectToCompany.CompanyId = Company.CompanyId WHERE AssignProjects.UserId='{
                        Properties.Settings.Default.UserId}' AND CompanyName LIKE '%{txtSearchCompany.Text}%'");
            }
            else
            {
                LoadCompany();
            }
        }
    }
}
