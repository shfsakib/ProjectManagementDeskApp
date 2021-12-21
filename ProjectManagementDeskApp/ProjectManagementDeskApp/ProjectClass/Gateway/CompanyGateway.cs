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
                cmd = new SqlCommand($"INSERT INTO Company(CompanyId,CompanyName,CompanyLocation,AdminId) VALUES(@CompanyId,@CompanyName,@CompanyLocation,{Properties.Settings.Default.UserId})", con);
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
        //Get Company by Data 
        public CompanyModel GetByData(string text)
        {
            CompanyModel companyModel = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string query = $@"SELECT * FROM Company WHERE (CAST(CompanyId AS nvarchar) + ' | '+CompanyName='{text}') OR (CompanyName + ' | '+CAST(CompanyId AS nvarchar)='{text}') AND AdminId={Properties.Settings.Default.UserId}";
                cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    companyModel = new CompanyModel();
                    companyModel.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                    companyModel.CompanyName = reader["CompanyName"].ToString();
                    companyModel.CompanyLocation = reader["CompanyLocation"].ToString();
                    reader.Close();
                    con.Close();

                }
                return companyModel;

            }
            catch (Exception ex)
            {
                return companyModel;
            }
        }
        //Update Company Data
        internal bool UpdateCompany(CompanyModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand($"UPDATE Company SET CompanyName=@CompanyName,CompanyLocation=@CompanyLocation WHERE CompanyId=@CompanyId AND AdminId={Properties.Settings.Default.UserId}", con);
                cmd.Parameters.AddWithValue("@CompanyName", ob.CompanyName);
                cmd.Parameters.AddWithValue("@CompanyLocation", ob.CompanyLocation);
                cmd.Parameters.AddWithValue("@CompanyId", ob.CompanyId);

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
        //Delete company
        internal bool DeleteCompany(CompanyModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand($"DELETE FROM Company WHERE CompanyId=@CompanyId AND AdminId={Properties.Settings.Default.UserId}", con);
                cmd.Parameters.AddWithValue("@CompanyId", ob.CompanyId);

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
