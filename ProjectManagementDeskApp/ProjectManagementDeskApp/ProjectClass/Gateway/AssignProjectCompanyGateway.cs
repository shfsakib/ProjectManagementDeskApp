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
    class AssignProjectCompanyGateway
    {
        //declare class instance variable
        private static AssignProjectCompanyGateway _instance;
        private SqlConnection con;
        private SqlCommand cmd;
        private Function function;
        //constructor
        public AssignProjectCompanyGateway()
        {
            //creating class object with singletone design pattern
            function = Function.GetInstance();
            con = new SqlConnection(function.Connection);
        }
        //creating class instance
        public static AssignProjectCompanyGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AssignProjectCompanyGateway();
            }

            return _instance;
        }
        //insert code
        internal bool Insert(AssignProjectCompanyModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO AssignProjectToCompany(AssignCompanyId,ProjectId,CompanyId,StartDate,EndDate,Priority) VALUES(@AssignCompanyId,@ProjectId,@CompanyId,@StartDate,@EndDate,@Priority)", con);
                cmd.Parameters.AddWithValue("@AssignCompanyId", ob.AssignCompanyId);
                cmd.Parameters.AddWithValue("@ProjectId", ob.ProjectId);
                cmd.Parameters.AddWithValue("@CompanyId", ob.CompanyId);
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
        //Get By Data

        public AssignProjectCompanyViewModel GetByData(string text)
        {
            AssignProjectCompanyViewModel assignProjectCompanyViewModel = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string query = $@"SELECT        AssignProjectToCompany.*, CAST(AssignProjectToCompany.ProjectId AS nvarchar)+ ' | ' +Projects.ProjectName ProjectName, Projects.Progress, CAST(Company.CompanyId AS nvarchar) + ' | ' +Company.CompanyName CompanyNAME
FROM            AssignProjectToCompany INNER JOIN
                         Projects ON AssignProjectToCompany.ProjectId = Projects.ProjectId INNER JOIN
                         Company ON AssignProjectToCompany.CompanyId = Company.CompanyId WHERE (CAST(AssignProjectToCompany.AssignCompanyId AS nvarchar) + ' | ' +Company.CompanyName='{text}') OR (Company.CompanyName + ' | ' +  CAST(AssignProjectToCompany.AssignCompanyId AS nvarchar)='{text}')";
                cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    assignProjectCompanyViewModel = new AssignProjectCompanyViewModel();
                    assignProjectCompanyViewModel.AssignCompanyId = Convert.ToInt32(reader["AssignCompanyId"]);
                    assignProjectCompanyViewModel.ProjectId = Convert.ToInt32(reader["ProjectId"]);
                    assignProjectCompanyViewModel.ProjectName = reader["ProjectName"].ToString();
                    assignProjectCompanyViewModel.CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());
                    assignProjectCompanyViewModel.CompanyName = reader["CompanyName"].ToString();
                    assignProjectCompanyViewModel.StartDate = reader["StartDate"].ToString();
                    assignProjectCompanyViewModel.EndDate = reader["EndDate"].ToString();
                    assignProjectCompanyViewModel.Priority = reader["Priority"].ToString(); 
                    reader.Close();
                    con.Close();

                }
                return assignProjectCompanyViewModel;
            }
            catch (Exception ex)
            {
                return assignProjectCompanyViewModel;
            }
        }
        //Update assigned project to company
        internal bool UpdateAssignedCompany(AssignProjectCompanyModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE AssignProjectToCompany SET ProjectId=@ProjectId,CompanyId=@CompanyId,EndDate=@EndDate,Priority=@Priority WHERE AssignCompanyId=@AssignCompanyId", con);
                cmd.Parameters.AddWithValue("@ProjectId", ob.ProjectId);
                cmd.Parameters.AddWithValue("@CompanyId", ob.CompanyId);
                cmd.Parameters.AddWithValue("@EndDate", ob.EndDate);
                cmd.Parameters.AddWithValue("@Priority", ob.Priority);
                cmd.Parameters.AddWithValue("@AssignCompanyId", ob.AssignCompanyId);

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

        //Delete Assigned Project
        internal bool DeleteAssignedProject(AssignProjectCompanyModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("DELETE FROM AssignProjectToCompany WHERE AssignCompanyId=@AssignCompanyId", con);
                cmd.Parameters.AddWithValue("@AssignCompanyId", ob.AssignCompanyId);

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
