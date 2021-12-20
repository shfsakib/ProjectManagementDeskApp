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
    class ProjectGateway
    {
        //declare class instance variable
        private static ProjectGateway _instance;
        private SqlConnection con;
        private SqlCommand cmd;
        private Function function;
        //constructor
        public ProjectGateway()
        {
            //creating class object with singletone design pattern
            function = Function.GetInstance();
            con = new SqlConnection(function.Connection);
        }
        //creating class instance
        public static ProjectGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProjectGateway();
            }

            return _instance;
        }
        //insert code for user
        internal bool Insert(ProjectModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO Projects(ProjectId,ProjectName,StartDate,EndDate,Priority,Progress) VALUES(@ProjectId,@ProjectName,@StartDate,@EndDate,@Priority,@Progress)", con);
                cmd.Parameters.AddWithValue("@ProjectId", ob.ProjectId);
                cmd.Parameters.AddWithValue("@ProjectName", ob.ProjectName);
                cmd.Parameters.AddWithValue("@StartDate", ob.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", ob.EndDate);
                cmd.Parameters.AddWithValue("@Priority", ob.Priority);
                cmd.Parameters.AddWithValue("@Progress", ob.Progress);

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
        public ProjectModel GetByData(string text)
        {
            ProjectModel projectModel = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string query = $@"SELECT * FROM Projects WHERE (CAST(ProjectId AS nvarchar) + ' | '+ProjectName='{text}') OR (ProjectName + ' | '+CAST(ProjectId AS nvarchar)='{text}')";
                cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    projectModel = new ProjectModel();
                    projectModel.ProjectId = Convert.ToInt32(reader["ProjectId"]);
                    projectModel.ProjectName = reader["ProjectName"].ToString();
                    projectModel.StartDate = reader["StartDate"].ToString();
                    projectModel.EndDate = reader["EndDate"].ToString();
                    projectModel.Priority = reader["Priority"].ToString();
                    projectModel.Progress = reader["Progress"].ToString();
                    reader.Close();
                    con.Close();

                }
                return projectModel;
            }
            catch (Exception ex)
            {
                return projectModel;
            }
        }
        //Update Project Data
        internal bool UpdateProject(ProjectModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE Projects SET ProjectName=@ProjectName,EndDate=@EndDate,Priority=@Priority,Progress=@Progress WHERE ProjectId=@ProjectId", con);
                cmd.Parameters.AddWithValue("@ProjectName", ob.ProjectName);
                cmd.Parameters.AddWithValue("@EndDate", ob.EndDate);
                cmd.Parameters.AddWithValue("@Priority", ob.Priority);
                cmd.Parameters.AddWithValue("@Progress", ob.Progress);
                cmd.Parameters.AddWithValue("@ProjectId", ob.ProjectId);
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
