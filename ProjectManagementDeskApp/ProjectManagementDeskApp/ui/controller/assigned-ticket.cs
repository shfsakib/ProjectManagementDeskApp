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
    public partial class assigned_ticket : UserControl
    {
        private Function func;
        public assigned_ticket()
        {
            InitializeComponent();
            func = Function.GetInstance();
            LoadGrid();
        }
        private void LoadGrid()
        {
            //load ticket data to grid
            func.LoadGrid(dataTicketGrid, $@"SELECT     Ticket.TicketId,   AssignTicketToUser.UserId, Users.FirstName UserFirstName, Users.SurName UserSurName,AssignTicketToUser.DateIssued IssueDate
FROM            AssignTicketToUser INNER JOIN
                         Users ON AssignTicketToUser.UserId = Users.UserId INNER JOIN
                         Ticket ON AssignTicketToUser.TicketId = Ticket.Id WHERE AssignTicketToUser.UserId={Properties.Settings.Default.UserId} ORDER BY Ticket.TicketId ASC");
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
        private void btnSearchTicket_Click(object sender, EventArgs e)
        {
            if (txtSearchTicket.Text != "")
            {
                //info like search text

                func.LoadGrid(dataTicketGrid, $@"SELECT     Ticket.TicketId,   AssignTicketToUser.UserId, Users.FirstName UserFirstName, Users.SurName UserSurName,AssignTicketToUser.DateIssued IssueDate
FROM            AssignTicketToUser INNER JOIN
                         Users ON AssignTicketToUser.UserId = Users.UserId INNER JOIN
                         Ticket ON AssignTicketToUser.TicketId = Ticket.Id WHERE AssignTicketToUser.UserId={Properties.Settings.Default.UserId} AND CAST(Ticket.TicketId AS nvarchar)+' '+CAST(AssignTicketToUser.UserId AS nvarchar)+' '+ Users.FirstName+' '+Users.SurName LIKE '%{txtSearchTicket.Text}%'  ORDER BY Ticket.TicketId ASC");
            }
            else
            {
                //load ticket data to grid
                LoadGrid();
            }
        }
    }
}
