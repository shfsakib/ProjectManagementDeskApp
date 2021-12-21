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
            function = Function.GetInstance();
            con = new SqlConnection(function.Connection);
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
                cmd = new SqlCommand($"INSERT INTO Users(UserId,FirstName,SurName,DOB,Address,Email,Password,UserType,AdminId) VALUES(@UserId,@FirstName,@SurName,@DOB,@Address,@Email,@Password,@UserType,{Properties.Settings.Default.UserId})", con);
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

        //Get User By Data
        public UserModel GetUserByData(string text)
        {
            UserModel userModel = null;
            try
            {
                string query = $@"SELECT * FROM Users WHERE (CAST(UserId AS nvarchar) + ' | '+FirstName+' '+SurName='{text}') OR (FirstName+' '+SurName + ' | '+CAST(UserId AS nvarchar)='{text}') AND AdminId={Properties.Settings.Default.UserId}";
                cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    userModel = new UserModel();
                    userModel.UserId = Convert.ToInt32(reader["UserId"]);
                    userModel.FirstName = reader["FirstName"].ToString();
                    userModel.SurName = reader["SurName"].ToString();
                    userModel.DOB = reader["DOB"].ToString();
                    userModel.Address = reader["Address"].ToString();
                    userModel.Email = reader["Email"].ToString();
                    userModel.Password = reader["Password"].ToString();
                    userModel.UserType = reader["UserType"].ToString();
                    reader.Close();
                    con.Close();

                }
                return userModel;

            }
            catch (Exception ex)
            {
                return userModel;
            }
        }
        //update user data
        internal bool UpdateUser(UserModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand($"UPDATE Users SET FirstName=@FirstName,SurName=@SurName,DOB=@DOB,Address=@Address,Email=@Email,Password=@Password WHERE UserId=@UserId AND AdminId={Properties.Settings.Default.UserId}", con);
                cmd.Parameters.AddWithValue("@FirstName", ob.FirstName);
                cmd.Parameters.AddWithValue("@SurName", ob.SurName);
                cmd.Parameters.AddWithValue("@DOB", ob.DOB);
                cmd.Parameters.AddWithValue("@Address", ob.Address);
                cmd.Parameters.AddWithValue("@Email", ob.Email);
                cmd.Parameters.AddWithValue("@Password", ob.Password);
                cmd.Parameters.AddWithValue("@UserId", ob.UserId);

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
        //Remove user
        internal bool DeleteUser(UserModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand($"DELETE FROM Users WHERE UserId=@UserId AND AdminId={Properties.Settings.Default.UserId}", con);
                cmd.Parameters.AddWithValue("@UserId", ob.UserId);

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
