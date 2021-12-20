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
            //load user data to grid
            func.LoadGrid(dataUserGrid, $@"SELECT        UserId, FirstName, SurName, DOB, Address, Email
FROM            Users WHERE USERTYPE='Staff'");
            //change user grid column width
            dataUserGrid.Columns[1].Width = 130;
            dataUserGrid.Columns[2].Width = 130;
            dataUserGrid.Columns[4].Width = 200;
            dataUserGrid.Columns[5].Width = 200;
            //load user data to grid
            func.LoadGrid(dataProjectGrid, $@"SELECT        ProjectId, ProjectName, StartDate, EndDate
FROM            Projects ORDER BY ProjectId ASC");
            //change project grid column width
            dataProjectGrid.Columns[0].Width = 120;
            dataProjectGrid.Columns[1].Width = 250;
            dataProjectGrid.Columns[2].Width = 250;
            dataProjectGrid.Columns[3].Width = 250;

        }
    }
}
