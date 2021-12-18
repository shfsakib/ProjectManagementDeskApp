using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementDeskApp.ProjectClass.Model
{
    class ProjectModel
    {
        //declare class instance variable
        private static ProjectModel _instance;
        //creating class instance
        public static ProjectModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProjectModel();
            }

            return _instance;
        }
        //declare model property
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Priority { get; set; }
        public string Progress { get; set; }

    }
}
