using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataFillingSoftDeskApp.ProjectClass;
using ProjectManagementDeskApp.ui.controller;

namespace ProjectManagementDeskApp.ui
{
    public partial class dashboard : Form
    {
        //variable declare
        private Point mouse_offset;
        private bool createCollapse = true;
        private bool assignCollapse = true;
        private bool updateCollapse = true;
        private bool deleteCollapse = true;
        //declare class instance variable
        private Function func;
        public dashboard()
        {
            InitializeComponent();
            func = Function.GetInstance();
            InitialCode();
        }

        private void InitialCode()
        {
            lblUserName.Text = Properties.Settings.Default.UserName;
            homeControl homeControl = new homeControl();
            panelChildContainer.Controls.Add(homeControl);
            //making panel scroll customizable
            flowLayoutPanel1.AutoScroll = false;
            flowLayoutPanel1.VerticalScroll.Maximum = 0;
            flowLayoutPanel1.VerticalScroll.Visible = false;
            flowLayoutPanel1.HorizontalScroll.Maximum = 0;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.AutoScroll = true;
            //set user name from database in label
            lblUserName.Text = "";
            lblUserName.Text = "Hello, " + Properties.Settings.Default.UserName;
            //disable close button hover
            btnDashClose.FlatAppearance.MouseOverBackColor = btnDashClose.BackColor;
            btnDashClose.BackColorChanged += (s, e) =>
            {
                btnDashClose.FlatAppearance.MouseOverBackColor = btnDashClose.BackColor;
            };
        }

        private void btnLoginClose_MouseMove(object sender, MouseEventArgs e)
        {
            //move form in desired location
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                this.Location = mousePos; //move the form to the desired location
            }
        }

        private void btnLoginClose_MouseDown(object sender, MouseEventArgs e)
        {
            //set form location in moved location
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void createTime_Tick(object sender, EventArgs e)
        {
            //create button collapse panel show hide
            if (createCollapse)
            {
                panelCreate.Height += 30;
                btnCreate.Image = Properties.Resources.down1;
                if (panelCreate.Height == panelCreate.MaximumSize.Height)
                {
                    createTime.Stop();
                    createCollapse = false;
                }
            }
            else
            {
                panelCreate.Height -= 30;
                btnCreate.Image = Properties.Resources.up3;
                if (panelCreate.Height == panelCreate.MinimumSize.Height)
                {
                    createTime.Stop();
                    createCollapse = true;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //enable create button collapse timer
            createTime.Enabled = true;
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            //enable create button collapse timer
            assignTimer.Enabled = true;
        }

        private void assignTimer_Tick(object sender, EventArgs e)
        {
            //assign button collapse panel show hide
            if (assignCollapse)
            {
                panelAssign.Height += 30;
                btnAssign.Image = Properties.Resources.down1;
                if (panelAssign.Height == panelAssign.MaximumSize.Height)
                {
                    assignTimer.Stop();
                    assignCollapse = false;
                }
            }
            else
            {
                panelAssign.Height -= 30;
                btnAssign.Image = Properties.Resources.up3;
                if (panelAssign.Height == panelAssign.MinimumSize.Height)
                {
                    assignTimer.Stop();
                    assignCollapse = true;
                }
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //minimize window
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateTimer.Enabled = true;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            //update button collapse panel show hide
            if (updateCollapse)
            {
                panelUpdate.Height += 30;
                btnUpdate.Image = Properties.Resources.down1;
                if (panelUpdate.Height == panelUpdate.MaximumSize.Height)
                {
                    updateTimer.Stop();
                    updateCollapse = false;
                }
            }
            else
            {
                panelUpdate.Height -= 30;
                btnUpdate.Image = Properties.Resources.up3;
                if (panelUpdate.Height == panelUpdate.MinimumSize.Height)
                {
                    updateTimer.Stop();
                    updateCollapse = true;
                }
            }
        }

        private void deleteTimer_Tick(object sender, EventArgs e)
        {
            //Delete button collapse panel show hide
            if (deleteCollapse)
            {
                panelDelete.Height += 30;
                btnDelete.Image = Properties.Resources.down1;
                if (panelDelete.Height == panelDelete.MaximumSize.Height)
                {
                    deleteTimer.Stop();
                    deleteCollapse = false;
                }
            }
            else
            {
                panelDelete.Height -= 30;
                btnDelete.Image = Properties.Resources.up3;
                if (panelDelete.Height == panelDelete.MinimumSize.Height)
                {
                    deleteTimer.Stop();
                    deleteCollapse = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteTimer.Enabled = true;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            homeControl homeControl = new homeControl();
            panelChildContainer.Controls.Clear();
            panelChildContainer.Controls.Add(homeControl);
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            create_user_control createUserControl = new create_user_control();
            panelChildContainer.Controls.Clear();
            panelChildContainer.Controls.Add(createUserControl);
        }

        private void btnDashClose_Click(object sender, EventArgs e)
        {
            //close application
            DialogResult dialogResult = MessageBox.Show("Are you sure want to log out?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }

        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            create_project createProject = new create_project();
            panelChildContainer.Controls.Clear();
            panelChildContainer.Controls.Add(createProject);
        }

        private void btnCreateCom_Click(object sender, EventArgs e)
        {
            create_company createCompany = new create_company();
            panelChildContainer.Controls.Clear();
            panelChildContainer.Controls.Add(createCompany);
        }

        private void btnCreateTicket_Click(object sender, EventArgs e)
        {
            create_ticket createTicket = new create_ticket();
            panelChildContainer.Controls.Clear();
            panelChildContainer.Controls.Add(createTicket);
        }
    }
}
