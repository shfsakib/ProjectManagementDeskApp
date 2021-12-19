using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementDeskApp.ProjectClass.Model
{
    class AssignProjectModel
    {
        //declare class instance variable
        private static AssignProjectModel _instance;
        //creating class instance
        public static AssignProjectModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AssignProjectModel();
            }

            return _instance;
        }
        //declare model property
        public int AssignId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Priority { get; set; }
    }
}
