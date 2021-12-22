using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFillingSoftDeskApp.ProjectClass;
using ProjectManagementDeskApp.ProjectClass.Model;
using ProjectManagementDeskApp.ProjectClass.Model.ViewModel;

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
                cmd = new SqlCommand($"INSERT INTO Projects(ProjectId,ProjectName,StartDate,EndDate,Priority,Progress,AdminId) VALUES(@ProjectId,@ProjectName,@StartDate,@EndDate,@Priority,@Progress,{Properties.Settings.Default.UserId})", con);
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
                string query = $@"SELECT * FROM Projects WHERE (CAST(ProjectId AS nvarchar) + ' | '+ProjectName='{text}') OR (ProjectName + ' | '+CAST(ProjectId AS nvarchar)='{text}') AND AdminId={Properties.Settings.Default.UserId}";
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
                cmd = new SqlCommand($"UPDATE Projects SET ProjectName=@ProjectName,EndDate=@EndDate,Priority=@Priority,Progress=@Progress WHERE ProjectId=@ProjectId AND AdminId={Properties.Settings.Default.UserId}", con);
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
        //Delete project
        internal bool DeleteProject(ProjectModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand($"DELETE FROM Projects WHERE ProjectId=@ProjectId AND AdminId={Properties.Settings.Default.UserId}", con);
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
        //Get List Data for project report
        public List<ProjectReportViewModel> GetProjectReportData(string entity)
        {
            List<ProjectReportViewModel> projectReportViewModelList = new List<ProjectReportViewModel>();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string query = "";
                if (entity == "All")
                {
                    query = $@"SELECT   DISTINCT   Users.UserId, Users.FirstName, Users.SurName,Company.CompanyName ProjectAssignedTo, Projects.Progress, AssignProjects.Priority
FROM            AssignProjects INNER JOIN
                         Projects ON AssignProjects.ProjectId = Projects.ProjectId INNER JOIN
                         Users ON AssignProjects.UserId = Users.UserId INNER JOIN
                         AssignProjectToCompany ON Projects.ProjectId = AssignProjectToCompany.ProjectId INNER JOIN
                         Company ON AssignProjectToCompany.CompanyId = Company.CompanyId WHERE AssignProjects.AdminId='{Properties.Settings.Default.UserId}'";
                }
                else
                    query = $@"SELECT   DISTINCT  TOP " + entity + $@"   Users.UserId, Users.FirstName, Users.SurName,Company.CompanyName ProjectAssignedTo, Projects.Progress, AssignProjects.Priority
FROM            AssignProjects INNER JOIN
                         Projects ON AssignProjects.ProjectId = Projects.ProjectId INNER JOIN
                         Users ON AssignProjects.UserId = Users.UserId INNER JOIN
                         AssignProjectToCompany ON Projects.ProjectId = AssignProjectToCompany.ProjectId INNER JOIN
                         Company ON AssignProjectToCompany.CompanyId = Company.CompanyId WHERE AssignProjects.AdminId='{Properties.Settings.Default.UserId}'";
                cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                while (reader.Read())
                {
                    ProjectReportViewModel projectReportViewModel = new ProjectReportViewModel();
                    projectReportViewModel.UserId = reader["UserId"].ToString();
                    projectReportViewModel.FirstName = reader["FirstName"].ToString();
                    projectReportViewModel.SurName = reader["SurName"].ToString();
                    projectReportViewModel.ProjectAssignedTo = reader["ProjectAssignedTo"].ToString();
                    projectReportViewModel.Priority = reader["Priority"].ToString();
                    projectReportViewModel.Progress = reader["Progress"].ToString();
                    if (projectReportViewModel.Progress == "0" || projectReportViewModel.Progress == "0%")
                    {
                        projectReportViewModel.ProgressUrl = Properties.Resources._0;
                    }
                    else if (projectReportViewModel.Progress == "25" || projectReportViewModel.Progress == "25%")
                    {
                        projectReportViewModel.ProgressUrl = Properties.Resources._25;
                    }
                    else if (projectReportViewModel.Progress == "50" || projectReportViewModel.Progress == "50%")
                    {
                        projectReportViewModel.ProgressUrl = Properties.Resources._50;

                    }
                    else if (projectReportViewModel.Progress == "75" || projectReportViewModel.Progress == "75%")
                    {
                        projectReportViewModel.ProgressUrl = Properties.Resources._75;

                    }
                    else if (projectReportViewModel.Progress == "100" || projectReportViewModel.Progress == "100%")
                    {
                        projectReportViewModel.ProgressUrl = Properties.Resources._100;
                    }
                    projectReportViewModelList.Add(projectReportViewModel);
                }
                reader.Close();
                con.Close();
                return projectReportViewModelList;
            }
            catch (Exception ex)
            {
                return projectReportViewModelList;
            }
        }
    }
}
