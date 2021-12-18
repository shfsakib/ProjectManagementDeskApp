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
    class CompanyGateway
    {
        //declare class instance variable
        private static CompanyGateway _instance;
        private SqlConnection con;
        private SqlCommand cmd;
        private Function function;
        //constructor
        public CompanyGateway()
        {
            //creating class object with singletone design pattern
            function = Function.GetInstance();
            con = new SqlConnection(function.Connection);
        }
        //creating class instance
        public static CompanyGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CompanyGateway();
            }

            return _instance;
        }
        //insert code for user
        internal bool Insert(CompanyModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO Company(CompanyId,CompanyName,CompanyLocation) VALUES(@CompanyId,@CompanyName,@CompanyLocation)", con);
                cmd.Parameters.AddWithValue("@CompanyId", ob.CompanyId);
                cmd.Parameters.AddWithValue("@CompanyName", ob.CompanyName);
                cmd.Parameters.AddWithValue("@CompanyLocation", ob.CompanyLocation);

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
