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
    public partial class update_assigned_ticket_to_user : UserControl
    {
        private Function func;
        private AssignTicketToUserGateway assignTicketToUserGateway;
        private AssignTicketToUserModel assignTicketToUserModel;
        private AssignTicketToUserViewModel assignTicketToUserViewModel;
        public update_assigned_ticket_to_user()
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
            //set default text
            comboCompany.Text = "--COMPANY--";
            comboProject.Text = "--PROJECT--";
            //bind combobox from database
            func.BindComboBox(comboTicket, "select ticket", $@"SELECT Id ID, CAST(TicketId AS nvarchar) NAME FROM Ticket ORDER BY NAME ASC");
            func.BindComboBox(comboUser, "select User", $@"SELECT UserId ID, CAST(UserId AS nvarchar) + ' | ' +FirstName +' '+SurName NAME FROM Users WHERE UserType='Staff' ORDER BY Name ASC");
            //autocomplete
            func.AutoCompleteTextBox(txtSearch, $@"select * from (
SELECT        CAST(Ticket.TicketId AS nvarchar) + ' | ' +Users.FirstName+' '+Users.SurName AS txt 
FROM            AssignTicketToUser INNER JOIN
                         Users ON AssignTicketToUser.UserId = Users.UserId INNER JOIN
						 Ticket ON AssignTicketToUser.TicketId=Ticket.Id
WHERE Ticket.TicketId LIKE '%%'
union
SELECT      Users.FirstName+' '+Users.SurName + ' | ' +CAST(Ticket.TicketId AS nvarchar) AS txt 
FROM            AssignTicketToUser INNER JOIN
                         Users ON AssignTicketToUser.UserId = Users.UserId  INNER JOIN
						 Ticket ON AssignTicketToUser.TicketId=Ticket.Id
WHERE Users.FirstName+' '+Users.SurName LIKE '%%' )A");
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

        private void btnAssignTicket_Click(object sender, EventArgs e)
        {
            if (comboTicket.SelectedIndex <= 0)
            {
                MessageBox.Show("Ticket is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboUser.SelectedIndex <= 0)
            {
                MessageBox.Show("User is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                assignTicketToUserModel.AssignTicketId = Convert.ToInt32(txtAssignId.Text);
                assignTicketToUserModel.TicketId = Convert.ToInt32(comboTicket.SelectedValue);
                assignTicketToUserModel.UserId = Convert.ToInt32(comboUser.SelectedValue);
                bool ans = assignTicketToUserGateway.UpdateAssignedTicketToUser(assignTicketToUserModel);
                if (ans)
                {
                    MessageBox.Show(comboTicket.Text + " ticket assigned to " + comboUser.Text + " updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboTicket.SelectedIndex = comboUser.SelectedIndex = comboProject.SelectedIndex = comboCompany.SelectedIndex = 0;
                    txtSearch.Text = txtAssignId.Text = "";
                }
                else
                {
                    MessageBox.Show("Failed to update assign", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboUser.SelectedIndex > 0)
            {
                func.BindComboBox(comboCompany, "Company", $@"SELECT     Company.CompanyId Id,Company.CompanyName Name   
FROM            Projects INNER JOIN
                         AssignProjects ON Projects.ProjectId = AssignProjects.ProjectId INNER JOIN
                         Users ON AssignProjects.UserId = Users.UserId INNER JOIN
                         AssignProjectToCompany ON Projects.ProjectId = AssignProjectToCompany.ProjectId INNER JOIN
                         Company ON AssignProjectToCompany.CompanyId = Company.CompanyId WHERE Users.UserId='{comboUser.SelectedValue}' ORDER BY Name ASC");

                func.BindComboBox(comboProject, "Project", $@"SELECT        Projects.ProjectId ID,Projects.ProjectName Name
FROM            Projects INNER JOIN
                         AssignProjects ON Projects.ProjectId = AssignProjects.ProjectId INNER JOIN
                         Users ON AssignProjects.UserId = Users.UserId WHERE Users.UserId='{comboUser.SelectedValue}' ORDER BY Name ASC");
            }
            else
            {
                comboCompany.Text = "--COMPANY--";
                comboProject.Text = "--PROJECT--";
            }
        }
    }
}
