using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementDeskApp.ProjectClass.Model
{
    class TicketModel
    {
        //declare class instance variable
        private static TicketModel _instance;
        //creating class instance
        public static TicketModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TicketModel();
            }

            return _instance;
        }
        //declare model property
        public int TicketId { get; set; }
        public string IssueDate { get; set; }

    }
}
