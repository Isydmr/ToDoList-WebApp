using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ToDoList_WebApplication.Models
{
    public class TaskDAL
    {
        readonly string connectionString = @"Data Source=DESKTOP-VF2D482;Initial Catalog=MyTaskDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //To View all tasks details    
        public IEnumerable<Task> GetAllTasks()
        {
            List<Task> lsttask = new List<Task>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllTasks", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Task task = new Task();

                    task.ID = Convert.ToInt32(rdr["TaskID"]);
                    task.Name = rdr["Name"].ToString();
                    task.BeginDate = DateTime.Parse(rdr["BeginDate"].ToString());
                    task.EndDate = DateTime.Parse(rdr["EndDate"].ToString());
                    task.EndDate = DateTime.Parse(rdr["EndDate"].ToString());
                    task.Finished = rdr["Finished"] as bool? ?? false;

                    lsttask.Add(task);
                }
                con.Close();
            }
            return lsttask;
        }

        //To Add new task record    
        public void AddTask(Task task)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddTask", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", task.Name);
                cmd.Parameters.AddWithValue("@BeginDate", task.BeginDate);
                cmd.Parameters.AddWithValue("@EndDate", task.EndDate);
                cmd.Parameters.AddWithValue("@Finished", task.Finished);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a given task  
        public void UpdateTask(Task task)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateTask", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TaskId", task.ID);
                cmd.Parameters.AddWithValue("@Name", task.Name);
                cmd.Parameters.AddWithValue("@BeginDate", task.BeginDate);
                cmd.Parameters.AddWithValue("@EndDate", task.EndDate);
                cmd.Parameters.AddWithValue("@Finished", task.Finished);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get the details of a particular task  
        public Task GetTaskData(int? id)
        {
            Task task = new Task();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tblTask WHERE TaskID= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    task.ID = Convert.ToInt32(rdr["TaskID"]);
                    task.Name = rdr["Name"].ToString();
                    task.BeginDate = DateTime.Parse(rdr["BeginDate"].ToString());
                    task.EndDate = DateTime.Parse(rdr["EndDate"].ToString());
                    task.Finished = rdr["Finished"] as bool? ?? false;

                }
            }
            return task;
        }

        //To Delete the record on a particular task  
        public void DeleteTask(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteTask", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TaskId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
