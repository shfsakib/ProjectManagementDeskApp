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
    }
}
