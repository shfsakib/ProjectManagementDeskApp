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
    public partial class view_data : UserControl
    {
        private Function func;
        public view_data()
        {
            InitializeComponent();
            func = Function.GetInstance();
            LoadGrid();
        }
        //Load All GridView
        private void LoadGrid()
        {
            //change grid font size
            dataUserGrid.Font = new Font("Segui UI", 10);
            dataProjectGrid.Font = new Font("Segui UI", 10);
            dataCompanyGrid.Font = new Font("Segui UI", 10);
            dataTicketGrid.Font = new Font("Segui UI", 10);
            //change height of data grid
            dataUserGrid.RowTemplate.Height = 40;
            dataProjectGrid.RowTemplate.Height = 40;
            dataCompanyGrid.RowTemplate.Height = 40;
            dataTicketGrid.RowTemplate.Height = 40;

            //load user data to grid
            func.LoadGrid(dataUserGrid, $@"SELECT        UserId, FirstName, SurName, DOB, Address, Email
FROM            Users WHERE USERTYPE='Staff' AND AdminId={Properties.Settings.Default.UserId}");
            if (dataUserGrid.Rows.Count > 0)
            {

                //change header text of user grid
                dataUserGrid.Columns[0].HeaderText = "User Id";
                dataUserGrid.Columns[1].HeaderText = "First Name";
                dataUserGrid.Columns[2].HeaderText = "Sur Name";
                dataUserGrid.Columns[3].HeaderText = "Date of Birth";
                //change user grid column width
                dataUserGrid.Columns[1].Width = 130;
                dataUserGrid.Columns[2].Width = 130;
                dataUserGrid.Columns[3].Width = 130;
                dataUserGrid.Columns[4].Width = 200;
                dataUserGrid.Columns[5].Width = 200;

            }
            //load project data to grid
            func.LoadGrid(dataProjectGrid, $@"SELECT        ProjectId, ProjectName, StartDate, EndDate
FROM            Projects WHERE AdminId={Properties.Settings.Default.UserId} ORDER BY ProjectId ASC");
            if (dataProjectGrid.Rows.Count > 0)
            {
                //change header text of user grid
                dataProjectGrid.Columns[0].HeaderText = "Project Id";
                dataProjectGrid.Columns[1].HeaderText = "Project Name";
                dataProjectGrid.Columns[2].HeaderText = "Start Date";
                dataProjectGrid.Columns[3].HeaderText = "End Date";
                //change project grid column width
                dataProjectGrid.Columns[0].Width = 120;
                dataProjectGrid.Columns[1].Width = 250;
                dataProjectGrid.Columns[2].Width = 250;
                dataProjectGrid.Columns[3].Width = 250;
            }

            //load company data to grid
            func.LoadGrid(dataCompanyGrid, $@"SELECT        CompanyId, CompanyName, CompanyLocation
FROM            Company WHERE AdminId={Properties.Settings.Default.UserId} ORDER BY CompanyId ASC");
            if (dataCompanyGrid.Rows.Count > 0)
            {
                //change header text of user grid
                dataCompanyGrid.Columns[0].HeaderText = "Company Id";
                dataCompanyGrid.Columns[1].HeaderText = "Company Name";
                dataCompanyGrid.Columns[2].HeaderText = "Company Location";
                //change company grid column width
                dataCompanyGrid.Columns[0].Width = 120;
                dataCompanyGrid.Columns[1].Width = 250;
                dataCompanyGrid.Columns[2].Width = 500;
            }

            //load ticket data to grid
            func.LoadGrid(dataTicketGrid, $@"SELECT     Ticket.TicketId,   AssignTicketToUser.UserId, Users.FirstName UserFirstName, Users.SurName UserSurName,AssignTicketToUser.DateIssued IssueDate
FROM            AssignTicketToUser INNER JOIN
                         Users ON AssignTicketToUser.UserId = Users.UserId INNER JOIN
                         Ticket ON AssignTicketToUser.TicketId = Ticket.Id WHERE AssignTicketToUser.AdminId={Properties.Settings.Default.UserId} ORDER BY Ticket.TicketId ASC");
            if (dataTicketGrid.Rows.Count > 0)
            {
                //change header text of user grid
                dataTicketGrid.Columns[0].HeaderText = "Ticket Id";
                dataTicketGrid.Columns[1].HeaderText = "User Id";
                dataTicketGrid.Columns[2].HeaderText = "User First Name";
                dataTicketGrid.Columns[3].HeaderText = "User Sur Name";
                dataTicketGrid.Columns[4].HeaderText = "Issue Date";
                //change ticket grid column width
                dataTicketGrid.Columns[0].Width = 100;
                dataTicketGrid.Columns[2].Width = 250;
                dataTicketGrid.Columns[3].Width = 250;
                dataTicketGrid.Columns[4].Width = 250;
            }
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            if (txtSearchUser.Text != "")
            {
                //info like search text
                func.LoadGrid(dataUserGrid, $@"SELECT        UserId, FirstName, SurName, DOB, Address, Email
FROM            Users WHERE USERTYPE='Staff' AND CAST(UserId AS nvarchar)+' '+FirstName+' '+SurName+' '+Email LIKE '%{txtSearchUser.Text}%' AND AdminId={Properties.Settings.Default.UserId}");
            }
            else
            {
                //load user data to grid
                func.LoadGrid(dataUserGrid, $@"SELECT        UserId, FirstName, SurName, DOB, Address, Email
FROM            Users WHERE USERTYPE='Staff' AND AdminId={Properties.Settings.Default.UserId}");
            }
        }

        private void btnSearchProject_Click(object sender, EventArgs e)
        {
            if (txtSearchProject.Text != "")
            {
                //info like search text
                func.LoadGrid(dataProjectGrid, $@"SELECT        ProjectId, ProjectName, StartDate, EndDate
FROM            Projects WHERE AdminId={Properties.Settings.Default.UserId} AND CAST(ProjectId AS nvarchar)+ ' ' +ProjectName  LIKE '%{txtSearchProject.Text}%' ORDER BY ProjectId ASC");
            }
            else
            {
                //load project data to grid
                func.LoadGrid(dataProjectGrid, $@"SELECT        ProjectId, ProjectName, StartDate, EndDate
FROM            Projects WHERE AdminId={Properties.Settings.Default.UserId} ORDER BY ProjectId ASC");
            }
        }

        private void btnSearchCompany_Click(object sender, EventArgs e)
        {
            if (txtSearchCompany.Text != "")
            {
                //info like search text
                func.LoadGrid(dataCompanyGrid, $@"SELECT        CompanyId, CompanyName, CompanyLocation
FROM            Company  WHERE AdminId={Properties.Settings.Default.UserId} AND  CAST(CompanyId AS nvarchar)+' '+CompanyName   LIKE '%{txtSearchCompany.Text}%' ORDER BY CompanyId ASC");
            }
            else
            {
                //load company data to grid
                func.LoadGrid(dataCompanyGrid, $@"SELECT        CompanyId, CompanyName, CompanyLocation
FROM            Company WHERE AdminId={Properties.Settings.Default.UserId} ORDER BY CompanyId ASC");
            }
        }

        private void btnSearchTicket_Click(object sender, EventArgs e)
        {
            if (txtSearchTicket.Text != "")
            {
                //info like search text

                func.LoadGrid(dataTicketGrid, $@"SELECT     Ticket.TicketId,   AssignTicketToUser.UserId, Users.FirstName UserFirstName, Users.SurName UserSurName,AssignTicketToUser.DateIssued IssueDate
FROM            AssignTicketToUser INNER JOIN
                         Users ON AssignTicketToUser.UserId = Users.UserId INNER JOIN
                         Ticket ON AssignTicketToUser.TicketId = Ticket.Id WHERE AssignTicketToUser.AdminId={Properties.Settings.Default.UserId} AND CAST(Ticket.TicketId AS nvarchar)+' '+CAST(AssignTicketToUser.UserId AS nvarchar)+' '+ Users.FirstName+' '+Users.SurName LIKE '%{txtSearchTicket.Text}%'  ORDER BY Ticket.TicketId ASC");
            }
            else
            {
                //load ticket data to grid
                func.LoadGrid(dataTicketGrid, $@"SELECT     Ticket.TicketId,   AssignTicketToUser.UserId, Users.FirstName UserFirstName, Users.SurName UserSurName,AssignTicketToUser.DateIssued IssueDate
FROM            AssignTicketToUser INNER JOIN
                         Users ON AssignTicketToUser.UserId = Users.UserId INNER JOIN
                         Ticket ON AssignTicketToUser.TicketId = Ticket.Id WHERE AssignTicketToUser.AdminId={Properties.Settings.Default.UserId} ORDER BY Ticket.TicketId ASC");
            }
        }
    }
}
