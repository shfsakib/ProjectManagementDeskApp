using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementDeskApp.ProjectClass.Model.ViewModel
{
    class AssignProjectCompanyViewModel
    {
        //declare class instance variable
        private static AssignProjectCompanyViewModel _instance;
        //creating class instance
        public static AssignProjectCompanyViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AssignProjectCompanyViewModel();
            }

            return _instance;
        }
        //declare model property
        public int AssignCompanyId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Priority { get; set; }
    }
}
