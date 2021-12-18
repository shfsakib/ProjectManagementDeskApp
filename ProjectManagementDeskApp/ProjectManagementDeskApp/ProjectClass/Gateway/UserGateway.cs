using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFillingSoftDeskApp.ProjectClass;
using ProjectManagementDeskApp.ProjectClass.Model;

namespace ProjectManagementDeskApp.ProjectClass.Gateway
{
    public class UserGateway
    {
        //declare class instance variable
        private static UserGateway _instance;
        private SqlConnection con;
        private SqlCommand cmd;
        private Function function;
        //constructor
        public UserGateway()
        {
            //creating class object with singletone design pattern
            function=Function.GetInstance();
            con=new SqlConnection(function.Connection);
        }
        //creating class instance
        public static UserGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserGateway();
            }

            return _instance;
        }
        //insert code for user
        internal bool Insert(UserModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO Users(UserId,FirstName,SurName,DOB,Address,Email,Password,UserType) VALUES(@UserId,@FirstName,@SurName,@DOB,@Address,@Email,@Password,@UserType)", con);
                cmd.Parameters.AddWithValue("@UserId", ob.UserId);
                cmd.Parameters.AddWithValue("@FirstName", ob.FirstName);
                cmd.Parameters.AddWithValue("@SurName", ob.SurName);
                cmd.Parameters.AddWithValue("@DOB", ob.DOB);
                cmd.Parameters.AddWithValue("@Address", ob.Address);
                cmd.Parameters.AddWithValue("@Email", ob.Email);
                cmd.Parameters.AddWithValue("@Password", ob.Password);
                cmd.Parameters.AddWithValue("@UserType", ob.UserType);

                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                result = true;
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            return result;
        }
    }
}
