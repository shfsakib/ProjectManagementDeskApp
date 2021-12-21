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
using ProjectManagementDeskApp.ProjectClass.Model.ViewModel;

namespace ProjectManagementDeskApp.ui.controller
{
    public partial class delete_assigned_ticket_to_user : UserControl
    {
        //initial object
        private Function func;
        private AssignTicketToUserGateway assignTicketToUserGateway;
        private AssignTicketToUserModel assignTicketToUserModel;
        private AssignTicketToUserViewModel assignTicketToUserViewModel;
        public delete_assigned_ticket_to_user()
        {
            InitializeComponent();
            func = Function.GetInstance();
            assignTicketToUserGateway = AssignTicketToUserGateway.GetInstance();
            assignTicketToUserModel = AssignTicketToUserModel.GetInstance();
            assignTicketToUserViewModel = AssignTicketToUserViewModel.GetInstance();
            InitialCode();
        }
        private void InitialCode()
        {

            //bind combobox from database
            func.BindComboBox(comboTicket, "select ticket", $@"SELECT Id ID, CAST(TicketId AS nvarchar) NAME FROM Ticket WHERE AdminId={Properties.Settings.Default.UserId} ORDER BY NAME ASC");
            func.BindComboBox(comboUser, "select User", $@"SELECT UserId ID, CAST(UserId AS nvarchar) + ' | ' +FirstName +' '+SurName NAME FROM Users WHERE UserType='Staff' AND AdminId={Properties.Settings.Default.UserId} ORDER BY Name ASC");
            //autocomplete
            func.AutoCompleteTextBox(txtSearch, $@"select * from (
SELECT        CAST(Ticket.TicketId AS nvarchar) + ' | ' +Users.FirstName+' '+Users.SurName AS txt 
FROM            AssignTicketToUser INNER JOIN
                         Users ON AssignTicketToUser.UserId = Users.UserId INNER JOIN
						 Ticket ON AssignTicketToUser.TicketId=Ticket.Id
WHERE Ticket.TicketId LIKE '%%' AND AssignTicketToUser.AdminId={Properties.Settings.Default.UserId}
union
SELECT      Users.FirstName+' '+Users.SurName + ' | ' +CAST(Ticket.TicketId AS nvarchar) AS txt 
FROM            AssignTicketToUser INNER JOIN
                         Users ON AssignTicketToUser.UserId = Users.UserId  INNER JOIN
						 Ticket ON AssignTicketToUser.TicketId=Ticket.Id
WHERE Users.FirstName+' '+Users.SurName LIKE '%%' AND AssignTicketToUser.AdminId={Properties.Settings.Default.UserId})A");
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                assignTicketToUserViewModel = assignTicketToUserGateway.GetByData(txtSearch.Text);
                if (assignTicketToUserViewModel == null)
                {
                    MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtAssignId.Text = assignTicketToUserViewModel.AssignTicketId.ToString();
                comboUser.Text = assignTicketToUserViewModel.UserName;
                comboTicket.Text = assignTicketToUserViewModel.TicketId.ToString();
                dateIssue.Text = assignTicketToUserViewModel.DateIssued;

            }
            else
            {
                MessageBox.Show("No Data Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Refresh()
        {
            comboTicket.SelectedIndex = comboUser.SelectedIndex = 0;
            txtSearch.Text = txtAssignId.Text = "";
            InitialCode();
        }
        private void btnDeleteAssignTicket_Click(object sender, EventArgs e)
        {
            if (txtAssignId.Text == "")
            {
                MessageBox.Show("Please choose an assigned ticket first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to remove this Assigned ticket?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (dialogResult == DialogResult.Yes)
                {
                    assignTicketToUserModel.AssignTicketId = Convert.ToInt32(txtAssignId.Text);
                    bool ans = assignTicketToUserGateway.DeleteAssignedTicket(assignTicketToUserModel);
                    if (ans)
                    {
                        MessageBox.Show("Assigned ticket removed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
