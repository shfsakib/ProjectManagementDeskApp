using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFillingSoftDeskApp.ProjectClass;
using ProjectManagementDeskApp.ProjectClass.Model;
using ProjectManagementDeskApp.ProjectClass.Model.ViewModel;

namespace ProjectManagementDeskApp.ProjectClass.Gateway
{
    class AssignTicketToUserGateway
    {
        //declare class instance variable
        private static AssignTicketToUserGateway _instance;
        private SqlConnection con;
        private SqlCommand cmd;
        private Function function;
        //constructor
        public AssignTicketToUserGateway()
        {
            //creating class object with singletone design pattern
            function = Function.GetInstance();
            con = new SqlConnection(function.Connection);
        }
        //creating class instance
        public static AssignTicketToUserGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AssignTicketToUserGateway();
            }

            return _instance;
        }
        //insert code
        internal bool Insert(AssignTicketToUserModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO AssignTicketToUser(AssignTicketId,TicketId,UserId,DateIssued) VALUES(@AssignTicketId,@TicketId,@UserId,@DateIssued)", con);
                cmd.Parameters.AddWithValue("@AssignTicketId", ob.AssignTicketId);
                cmd.Parameters.AddWithValue("@TicketId", ob.TicketId);
                cmd.Parameters.AddWithValue("@UserId", ob.UserId);
                cmd.Parameters.AddWithValue("@DateIssued", ob.DateIssued);

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
        
        //Get By Data

        public AssignTicketToUserViewModel GetByData(string text)
        {
            AssignTicketToUserViewModel assignTicketToUserViewModel = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string query = $@"SELECT        AssignTicketToUser.AssignTicketId,AssignTicketToUser.UserId,AssignTicketToUser.DateIssued, CAST(Ticket.TicketId AS nvarchar) TicketId, CAST(Users.UserId AS nvarchar) + ' | ' +Users.FirstName+' '+Users.SurName UserName
FROM            AssignTicketToUser INNER JOIN
                         Ticket ON AssignTicketToUser.TicketId = Ticket.Id INNER JOIN
                         Users ON AssignTicketToUser.UserId = Users.UserId WHERE (CAST(Ticket.TicketId AS nvarchar) + ' | ' +Users.FirstName+' '+Users.SurName='{text}') OR (Users.FirstName+' '+Users.SurName + ' | ' +CAST(Ticket.TicketId AS nvarchar)='{text}')";
                cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    assignTicketToUserViewModel = new AssignTicketToUserViewModel();
                    assignTicketToUserViewModel.AssignTicketId = Convert.ToInt32(reader["AssignTicketId"]);
                    assignTicketToUserViewModel.UserId = Convert.ToInt32(reader["UserId"]);
                    assignTicketToUserViewModel.UserName = reader["UserName"].ToString();
                    assignTicketToUserViewModel.TicketId = Convert.ToInt32(reader["TicketId"].ToString());
                    assignTicketToUserViewModel.DateIssued = reader["DateIssued"].ToString(); 
                    reader.Close();
                    con.Close();

                }
                return assignTicketToUserViewModel;
            }
            catch (Exception ex)
            {
                return assignTicketToUserViewModel;
            }
        }
        //update assigned ticket to user

        internal bool UpdateAssignedTicketToUser(AssignTicketToUserModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE AssignTicketToUser SET TicketId=@TicketId,UserId=@UserId WHERE AssignTicketId=@AssignTicketId", con);
                cmd.Parameters.AddWithValue("@TicketId", ob.TicketId);
                cmd.Parameters.AddWithValue("@UserId", ob.UserId);
                cmd.Parameters.AddWithValue("@AssignTicketId", ob.AssignTicketId);

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
