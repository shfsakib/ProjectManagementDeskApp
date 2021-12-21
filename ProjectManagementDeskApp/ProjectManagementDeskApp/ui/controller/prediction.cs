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
    public partial class prediction : UserControl
    {
        //initial object

        private Function func;

        public prediction()
        {
            InitializeComponent();
            func = Function.GetInstance();
            LoadPrediction();
        }

        private void LoadPrediction()
        {
            //load predict data
            func.LoadGrid(dataPrediction,$@"select CompanyId,CompanyName,Projects, count(*) StaffRequired,ProjectedDate from (
					select distinct  CompanyId,CompanyName,Projects,userid,ProjectedDate   from (SELECT distinct AssignProjectToCompany_1.CompanyId, Company.CompanyName,
                             (SELECT        COUNT(ProjectId) AS Expr1
                               FROM            AssignProjectToCompany
                               WHERE        (CompanyId = Company.CompanyId) AND Company.AdminId={Properties.Settings.Default.UserId}) AS Projects, AssignProjectToCompany_1.ProjectId, AssignProjects.UserId,(SELECT CONVERT(nvarchar,MAX(CONVERT(DATE,EndDate,103)),103) FROM AssignProjectToCompany WHERE AssignProjectToCompany.CompanyId=Company.CompanyId AND Company.AdminId={Properties.Settings.Default.UserId}) ProjectedDate
FROM            AssignProjectToCompany AS AssignProjectToCompany_1 INNER JOIN
                         Company ON AssignProjectToCompany_1.CompanyId = Company.CompanyId INNER JOIN
                         AssignProjects ON AssignProjectToCompany_1.ProjectId = AssignProjects.ProjectId 
						 ) B ) C group by CompanyId,CompanyName,Projects,ProjectedDate");
            //set column width
            dataPrediction.Columns[0].Width = 120;
            dataPrediction.Columns[1].Width = 220;
            dataPrediction.Columns[2].Width = 220;
            dataPrediction.Columns[3].Width = 130;
            dataPrediction.Columns[4].Width = 220;
            //column header text changed
            dataPrediction.Columns[0].HeaderText = "Company Id";
            dataPrediction.Columns[1].HeaderText = "Company Name"; 
            dataPrediction.Columns[3].HeaderText = "Staff Required";
            dataPrediction.Columns[4].HeaderText = "Projected Date";
            //increase font
            dataPrediction.Font = new Font("Segui UI", 10);
            //change height of data grid
            dataPrediction.RowTemplate.Height = 40;
        }
    }
}
