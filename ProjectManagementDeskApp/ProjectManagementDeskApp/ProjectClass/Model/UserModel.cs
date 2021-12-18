using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementDeskApp.ProjectClass.Model
{
    public class UserModel
    {
        //declare class instance variable
        private static UserModel _instance;
        //creating class instance
        public static UserModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserModel();
            }

            return _instance;
        }
        //declare model property
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
