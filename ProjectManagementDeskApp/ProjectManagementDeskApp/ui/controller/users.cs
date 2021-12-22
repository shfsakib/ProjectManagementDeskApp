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
    public partial class users : UserControl
    {
        private Function func;
        public users()
        {
            InitializeComponent();
            func=Function.GetInstance();
            LoadGrid();
        }

        private void LoadGrid()
        {
            string adminId =func.IsExist($@"SELECT ADMINID FROM Users WHERE UserId='{Properties.Settings.Default.UserId}'");
            //change grid font size
            dataUserGrid.Font = new Font("Segui UI", 10);
           
            //change height of data grid
            dataUserGrid.RowTemplate.Height = 40;
         

            //load user data to grid
            func.LoadGrid(dataUserGrid, $@"SELECT        UserId, FirstName, SurName, DOB, Address, Email
FROM            Users WHERE USERTYPE='Staff' AND AdminId={adminId}");
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
        }
        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            string adminId =func.IsExist($@"SELECT ADMINID FROM Users WHERE UserId='{Properties.Settings.Default.UserId}'");
            if (txtSearchUser.Text != "")
            {
                //info like search text
                func.LoadGrid(dataUserGrid, $@"SELECT        UserId, FirstName, SurName, DOB, Address, Email
FROM            Users WHERE USERTYPE='Staff' AND CAST(UserId AS nvarchar)+' '+FirstName+' '+SurName+' '+Email LIKE '%{txtSearchUser.Text}%' AND AdminId={adminId}");
            }
            else
            {
                //load user data to grid
              LoadGrid();
            }
        }
    }
}
