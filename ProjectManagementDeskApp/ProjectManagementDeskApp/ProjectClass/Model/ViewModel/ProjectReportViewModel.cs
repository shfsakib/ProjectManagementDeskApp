using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementDeskApp.ProjectClass.Model.ViewModel
{
    class ProjectReportViewModel
    {
        //declare class instance variable
        private static ProjectReportViewModel _instance;
        //creating class instance
        public static ProjectReportViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProjectReportViewModel();
            }

            return _instance;
        }
        //declare model property
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string ProjectAssignedTo { get; set; }
        public string ProgressUrl { get; set; }
        public string Progress { get; set; }
        public string Priority { get; set; }
    }
}
