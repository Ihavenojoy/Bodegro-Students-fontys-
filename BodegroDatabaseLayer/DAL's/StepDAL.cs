using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodegroInterfaces;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class StepDAL : IStep
    {
        private readonly string connectionString = "TrustServerCertificate=True;" +
            "Server=mssqlstud.fhict.local;" +
            "Database=dbi500009_grodebo;" +
            "User Id=dbi500009_grodebo;" +
            "Password=Grodebo;";
        public int CreateStep(StepDTO protocol)
        {
            int insertedId = -1;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "INSERT INTO [Protocol] (ID, Name, Description, Total, Admin_ID) VALUES (@ID, @Name, @Description, @Total, @Admin_ID); SELECT SCOPE_IDENTITY();";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", 1);
                        cmd.Parameters.AddWithValue("@Name", 1);
                        cmd.Parameters.AddWithValue("@Description", 1);
                        cmd.Parameters.AddWithValue("@Total", 1);
                        cmd.Parameters.AddWithValue("@Admin_ID", 1);

                        conn.Open();
                        insertedId = Convert.ToInt32(cmd.ExecuteScalar());

                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("An SQL error occurred while creating a protocol: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return insertedId;
        }
    }
}
