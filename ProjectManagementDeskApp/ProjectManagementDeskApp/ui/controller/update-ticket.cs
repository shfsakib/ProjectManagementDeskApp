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
    public partial class update_ticket : UserControl
    {
        //Initializing variable name of class to create object
        private TicketModel ticketModel;
        private TicketGateway ticketGateway;
        private Function func;
        public update_ticket()
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
WHERE TicketId LIKE '%%' AND AdminId={Properties.Settings.Default.UserId}) A");
        }
        private void btnUpdateTicket_Click(object sender, EventArgs e)
        {
            if (txtTicketId.Text == "")
            {
                MessageBox.Show("Ticket id is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dateIssue.Text == "")
            {
                MessageBox.Show("Issue date is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ticketModel.TicketId = Convert.ToInt32(txtTicketId.Text);
                ticketModel.IssueDate = dateIssue.Text;
                bool ans = ticketGateway.UpdateTicket(ticketModel, txtSearch.Text);//calling insert method from gateway
                if (ans)
                {
                    MessageBox.Show("Ticket Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtSearch.Text = dateIssue.Text = txtTicketId.Text = "";
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

        private void txtTicketId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
