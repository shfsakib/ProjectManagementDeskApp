using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementDeskApp.ProjectClass.Model
{
    class CompanyModel
    {

        //declare class instance variable
        private static CompanyModel _instance;
        //creating class instance
        public static CompanyModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CompanyModel();
            }

            return _instance;
        }
        //declare model property
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }

    }
}
