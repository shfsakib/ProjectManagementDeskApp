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
    public partial class delete_ticket : UserControl
    {//Initializing variable name of class to create object
        private TicketModel ticketModel;
        private TicketGateway ticketGateway;
        private Function func;
        public delete_ticket()
        {
            InitializeComponent();
            ticketGateway = TicketGateway.GetInstance();
            ticketModel = TicketModel.GetInstance();
            func = Function.GetInstance();
            InitialCode();
        }
        private void InitialCode()
        {
            //autocomplete of ticket
            func.AutoCompleteTextBox(txtSearch, $@"select * from (
SELECT  CAST(TicketId AS nvarchar) txt FROM Ticket  
WHERE TicketId LIKE '%%') A");
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                ticketModel = ticketGateway.GetByData(txtSearch.Text);
                if (ticketModel == null)
                {
                    MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtTicketId.Text = ticketModel.TicketId.ToString();
                dateIssue.Text = ticketModel.IssueDate;
            }
            else
            {
                MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Refresh()
        {
            txtSearch.Text = dateIssue.Text = txtTicketId.Text = "";
            //autocomplete

            func.AutoCompleteTextBox(txtSearch, $@"select * from (
SELECT  CAST(TicketId AS nvarchar) txt FROM Ticket  
WHERE TicketId LIKE '%%') A");
        }
        private bool IsExist()
        {
            bool ans = false;
            string x = func.IsExist($@"SELECT Ticket.TicketId FROM AssignTicketToUser INNER JOIN Ticket ON AssignTicketToUser.TicketId=Ticket.Id WHERE Ticket.TicketId='{txtTicketId.Text}'");
            if (x != "")
            {
                ans = true;
            }

            return ans;
        }
        private void btnDeleteTicket_Click(object sender, EventArgs e)
        {
            if (txtTicketId.Text == "")
            {
                MessageBox.Show("Please choose an ticket first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (IsExist())
                {
                    DialogResult dialogResult = MessageBox.Show("This ticket already assigned to a user.You can\'t remove this ticket.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        Refresh();
                    }
                }
                else
                {

                    DialogResult dialogResult = MessageBox.Show("Are you sure want to remove this ticket?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ticketModel.TicketId = Convert.ToInt32(txtTicketId.Text);
                        bool ans = ticketGateway.DeleteTicket(ticketModel);
                        if (ans)
                        {
                            MessageBox.Show("Ticket removed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Refresh();
                        }
                    }
                    else
                    {
                        Refresh();
                    }
                }
            }
        }
    }
}
