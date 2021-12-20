using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementDeskApp.ProjectClass.Model.ViewModel
{
    class AssignProjectViewModel
    {
        //declare class instance variable
        private static AssignProjectViewModel _instance;
        //creating class instance
        public static AssignProjectViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AssignProjectViewModel();
            }

            return _instance;
        }
        //declare model property
        public int AssignId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Priority { get; set; }
        public string Progress { get; set; }

    }
}
