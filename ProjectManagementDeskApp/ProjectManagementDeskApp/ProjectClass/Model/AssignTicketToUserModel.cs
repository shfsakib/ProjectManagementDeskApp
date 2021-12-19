using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementDeskApp.ProjectClass.Model
{
    class AssignTicketToUserModel
    {
        //declare class instance variable
        private static AssignTicketToUserModel _instance;
        //creating class instance
        public static AssignTicketToUserModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AssignTicketToUserModel();
            }

            return _instance;
        }
        //declare model property
        public int AssignTicketId { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public string DateIssued { get; set; }
    }
}
