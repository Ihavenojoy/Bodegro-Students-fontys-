using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
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
        public int CreateStep(StepDTO stepDTO)
        {
            int insertedId = -1;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "INSERT INTO [Step] (Protocol_ID, Name, Test, Description, Steps_Number, Interval) VALUES (@Protocol_ID, @Name, @Test, @Description, @Steps_Number, @Interval); SELECT SCOPE_IDENTITY();";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@Protocol_ID", stepDTO.ProtocolID);
                        cmd.Parameters.AddWithValue("@Name", stepDTO.Name);
                        cmd.Parameters.AddWithValue("@Test", stepDTO.Test);
                        cmd.Parameters.AddWithValue("@Description", stepDTO.Description);
                        cmd.Parameters.AddWithValue("@Steps_Number", stepDTO.Order);
                        cmd.Parameters.AddWithValue("@Interval", stepDTO.Interval);

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
