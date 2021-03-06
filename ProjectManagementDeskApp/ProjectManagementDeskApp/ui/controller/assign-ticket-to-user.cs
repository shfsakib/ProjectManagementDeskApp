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
    public partial class assign_ticket_to_user : UserControl
    {
        private Function func;
        private AssignTicketToUserGateway assignTicketToUserGateway;
        private AssignTicketToUserModel assignTicketToUserModel;
        public assign_ticket_to_user()
        {
            InitializeComponent();
            func = Function.GetInstance();
            assignTicketToUserGateway = AssignTicketToUserGateway.GetInstance();
            assignTicketToUserModel = AssignTicketToUserModel.GetInstance();
            InitialCode();
        }
        private void InitialCode()
        {
            //set default text
            comboCompany.Text = "--COMPANY--";
            comboProject.Text = "--PROJECT--";
            //bind combobox from database
            func.BindComboBox(comboTicket, "select ticket", $@"SELECT Id ID, CAST(TicketId AS nvarchar) NAME FROM Ticket WHERE AdminId={Properties.Settings.Default.UserId} ORDER BY NAME ASC");
            func.BindComboBox(comboUser, "select User", $@"SELECT UserId ID, CAST(UserId AS nvarchar) + ' | ' +FirstName +' '+SurName NAME FROM Users WHERE UserType='Staff' AND AdminId={Properties.Settings.Default.UserId} ORDER BY Name ASC");
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
                         Company ON AssignProjectToCompany.CompanyId = Company.CompanyId WHERE Users.UserId='{comboUser.SelectedValue}' AND Users.AdminId={Properties.Settings.Default.UserId} ORDER BY Name ASC");

                func.BindComboBox(comboProject, "Project", $@"SELECT        Projects.ProjectId ID,Projects.ProjectName Name
FROM            Projects INNER JOIN
                         AssignProjects ON Projects.ProjectId = AssignProjects.ProjectId INNER JOIN
                         Users ON AssignProjects.UserId = Users.UserId WHERE Users.UserId='{comboUser.SelectedValue}' AND Users.AdminId={Properties.Settings.Default.UserId} ORDER BY Name ASC");
            }
            else
            {
                comboCompany.Text = "--COMPANY--";
                comboProject.Text = "--PROJECT--";
            }
        }
        private bool IsAssignExist()
        {
            bool ans = false;
            string x = func.IsExist($@"SELECT AssignTicketId FROM AssignTicketToUser WHERE TicketId='{comboTicket.SelectedValue}' AND UserId='{comboUser.SelectedValue}' AND AdminId={Properties.Settings.Default.UserId}");
            if (x != "")
            {
                ans = true;
            }

            return ans;
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
            else if (IsAssignExist())
            {
                MessageBox.Show("This ticket already assigned to this user", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                assignTicketToUserModel.AssignTicketId = Convert.ToInt32(func.GenerateId($@"SELECT MAX(AssignTicketId) FROM AssignTicketToUser"));
                assignTicketToUserModel.TicketId = Convert.ToInt32(comboTicket.SelectedValue);
                assignTicketToUserModel.UserId = Convert.ToInt32(comboUser.SelectedValue);
                assignTicketToUserModel.DateIssued = dateIssue.Text;
                bool ans = assignTicketToUserGateway.Insert(assignTicketToUserModel);
                if (ans)
                {
                    MessageBox.Show(comboTicket.Text + " ticket assigned to " + comboUser.Text + " successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboTicket.SelectedIndex = comboUser.SelectedIndex = 0;
                    comboProject.SelectedIndex = comboCompany.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Failed to assign", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
