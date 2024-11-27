using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DTO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class StepDAL : IStep
    {
        private readonly string connectionString;
        public StepDAL(IConfiguration configuration)
        {
            connectionString = "Server=mssqlstud.fhict.local;Database=dbi500009_backup;User Id=dbi500009_backup;Password=backupWW;TrustServerCertificate=True;";
            //connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool CreateStep(StepDTO stepDTO)
        {
            bool isdone = false;
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
                        cmd.ExecuteScalar();
                        isdone = true;

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
            return isdone;
        }
        public List<StepDTO> GetStepsOfProtocol(int protocolID)
        {
            List<StepDTO> list = new List<StepDTO>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "SELECT ID, Protocol_ID, Name, Test, Description, Steps_Number, Interval  FROM Step WHERE Protocol_ID = @Protocol_ID";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@Protocol_ID", protocolID);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StepDTO step = new StepDTO 
                                { 
                                    ID = (int)(reader["ID"]),
                                    ProtocolID = Convert.ToInt32(reader["Protocol_ID"]),
                                    Name = Convert.ToString(reader["Name"]),
                                    Test = Convert.ToString(reader["Test"]),
                                    Description = Convert.ToString(reader["Description"]),
                                    Order = Convert.ToInt32(reader["Steps_Number"]),
                                    Interval = Convert.ToInt32(reader["Interval"])
                                };
                                list.Add(step);
                            }
                        }
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
            return list;
        }
    }
}
