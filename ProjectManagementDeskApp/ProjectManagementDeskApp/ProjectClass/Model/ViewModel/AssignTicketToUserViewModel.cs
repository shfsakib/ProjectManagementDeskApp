using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementDeskApp.ProjectClass.Model.ViewModel
{
    class AssignTicketToUserViewModel
    {
        //declare class instance variable
        private static AssignTicketToUserViewModel _instance;
        //creating class instance
        public static AssignTicketToUserViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AssignTicketToUserViewModel();
            }

            return _instance;
        }
        //declare model property
        public int AssignTicketId { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string DateIssued { get; set; }
    }
}
