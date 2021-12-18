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
    public partial class create_ticket : UserControl
    {
        //Initializing variable name of class to create object
        private TicketModel ticketModel;
        private TicketGateway ticketGateway;
        private Function func;
        public create_ticket()
        {
            InitializeComponent();
            ticketGateway = TicketGateway.GetInstance();
            ticketModel = TicketModel.GetInstance();
            func = Function.GetInstance();
            InitialCode();
        }
        private void InitialCode()
        {
            //change date format in datepicker
            dateIssue.Format = DateTimePickerFormat.Custom;
            dateIssue.CustomFormat = "dd/MM/yyyy";

            //get userid from projects table
            txtTicketId.Text = func.GenerateId($@"SELECT MAX(TicketId) FROM Ticket");
        }
        private void btnCreateTicket_Click(object sender, EventArgs e)
        {

            if (dateIssue.Text == "")
            {
                MessageBox.Show("Issue date is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ticketModel.TicketId = Convert.ToInt32(func.GenerateId($@"SELECT MAX(TicketId) FROM Ticket"));
                ticketModel.IssueDate = dateIssue.Text;
                bool ans = ticketGateway.Insert(ticketModel);//calling insert method from gateway
                if (ans)
                {
                    MessageBox.Show("Ticket Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dateIssue.Text = "";

        }
    }
}
