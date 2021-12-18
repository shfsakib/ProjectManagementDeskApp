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
    public partial class homeControl : UserControl
    {
        private Function func;
        public homeControl()
        {
            InitializeComponent();
            func = Function.GetInstance();
            InitialCode();
        }

        private void InitialCode()
        {
            lblUser.Text = func.IsExist($@"SELECT COUNT(UserId) FROM Users WHERE UserType='Admin'");
        }
    }
}
