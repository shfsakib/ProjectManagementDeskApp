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
            func=Function.GetInstance();
        }
        //Load All GridView
        private void LoadGrid()
        {

        }
    }
}
