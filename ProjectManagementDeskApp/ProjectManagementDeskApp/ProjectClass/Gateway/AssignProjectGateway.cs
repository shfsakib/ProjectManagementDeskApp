
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
    class AssignProjectGateway
    {
        //declare class instance variable
        private static AssignProjectGateway _instance;
        private SqlConnection con;
        private SqlCommand cmd;
        private Function function;
        //constructor
        public AssignProjectGateway()
        {
            //creating class object with singletone design pattern
            function = Function.GetInstance();
            con = new SqlConnection(function.Connection);
        }
        //creating class instance
        public static AssignProjectGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AssignProjectGateway();
            }

            return _instance;
        }
        //insert code
        internal bool Insert(AssignProjectModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO AssignProjects(AssignId,ProjectId,UserId,StartDate,EndDate,Priority) VALUES(@AssignId,@ProjectId,@UserId,@StartDate,@EndDate,@Priority)", con);
                cmd.Parameters.AddWithValue("@AssignId", ob.AssignId);
                cmd.Parameters.AddWithValue("@ProjectId", ob.ProjectId);
                cmd.Parameters.AddWithValue("@UserId", ob.UserId);
                cmd.Parameters.AddWithValue("@StartDate", ob.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", ob.EndDate);
                cmd.Parameters.AddWithValue("@Priority", ob.Priority);

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
