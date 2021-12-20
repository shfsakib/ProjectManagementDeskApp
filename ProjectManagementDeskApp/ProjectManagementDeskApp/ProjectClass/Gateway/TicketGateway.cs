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
    class TicketGateway
    {
        //declare class instance variable
        private static TicketGateway _instance;
        private SqlConnection con;
        private SqlCommand cmd;
        private Function function;
        //constructor
        public TicketGateway()
        {
            //creating class object with singletone design pattern
            function = Function.GetInstance();
            con = new SqlConnection(function.Connection);
        }
        //creating class instance
        public static TicketGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TicketGateway();
            }

            return _instance;
        }
        //insert code for user
        internal bool Insert(TicketModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO Ticket(TicketId,IssueDate) VALUES(@TicketId,@IssueDate)", con);
                cmd.Parameters.AddWithValue("@TicketId", ob.TicketId);
                cmd.Parameters.AddWithValue("@IssueDate", ob.IssueDate);

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
        //Get Ticket by Data 
        public TicketModel GetByData(string text)
        {
            TicketModel ticketModel = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string query = $@"SELECT * FROM Ticket WHERE (CAST(TicketId AS nvarchar)='{text}')";
                cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    ticketModel = new TicketModel();
                    ticketModel.TicketId = Convert.ToInt32(reader["TicketId"]);
                    ticketModel.IssueDate = reader["IssueDate"].ToString(); 
                    reader.Close();
                    con.Close();

                }
                return ticketModel;

            }
            catch (Exception ex)
            {
                return ticketModel;
            }
        }
        //Update TicketId
        internal bool UpdateTicket(TicketModel ob,string id)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand($@"UPDATE Ticket SET TicketId=@TicketId WHERE TicketId='{id}' AND IssueDate=@IssueDate", con);
                cmd.Parameters.AddWithValue("@TicketId", ob.TicketId);
                cmd.Parameters.AddWithValue("@IssueDate", ob.IssueDate);

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
