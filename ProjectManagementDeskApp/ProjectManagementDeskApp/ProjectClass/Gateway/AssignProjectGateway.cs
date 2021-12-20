
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
        //Get By Data 
        public AssignProjectViewModel GetByData(string text)
        {
            AssignProjectViewModel assignProjectViewModel = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string query = $@"SELECT        AssignProjects.*, CAST(AssignProjects.ProjectId AS nvarchar)+ ' | ' +Projects.ProjectName ProjectName, Projects.Progress, CAST(Users.UserId AS nvarchar) + ' | ' +Users.FirstName +' '+Users.SurName UserNAME
FROM            AssignProjects INNER JOIN
                         Projects ON AssignProjects.ProjectId = Projects.ProjectId INNER JOIN
                         Users ON AssignProjects.UserId = Users.UserId WHERE (CAST(AssignProjects.AssignId AS nvarchar) + ' | ' +Projects.ProjectName='{text}') OR (Projects.ProjectName + ' | ' +  CAST(AssignProjects.AssignId AS nvarchar)='{text}')";
                cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    assignProjectViewModel = new AssignProjectViewModel();
                    assignProjectViewModel.AssignId = Convert.ToInt32(reader["AssignId"]);
                    assignProjectViewModel.ProjectId = Convert.ToInt32(reader["ProjectId"]);
                    assignProjectViewModel.ProjectName = reader["ProjectName"].ToString();
                    assignProjectViewModel.UserId= Convert.ToInt32(reader["UserId"].ToString());
                    assignProjectViewModel.UserName = reader["UserName"].ToString();
                    assignProjectViewModel.StartDate = reader["StartDate"].ToString();
                    assignProjectViewModel.EndDate = reader["EndDate"].ToString();
                    assignProjectViewModel.Priority = reader["Priority"].ToString();
                    assignProjectViewModel.Progress = reader["Progress"].ToString();
                    reader.Close();
                    con.Close();

                }
                return assignProjectViewModel;
            }
            catch (Exception ex)
            {
                return assignProjectViewModel;
            }
        }
        //Update assign project 
        internal bool UpdateAssignProject(AssignProjectModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE AssignProjects SET ProjectId=@ProjectId,UserId=@UserId,EndDate=@EndDate,Priority=@Priority WHERE AssignId=@AssignId", con);
                cmd.Parameters.AddWithValue("@ProjectId", ob.ProjectId);
                cmd.Parameters.AddWithValue("@UserId", ob.UserId);
                cmd.Parameters.AddWithValue("@EndDate", ob.EndDate);
                cmd.Parameters.AddWithValue("@Priority", ob.Priority);
                cmd.Parameters.AddWithValue("@AssignId", ob.AssignId);

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
