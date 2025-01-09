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
    public class SubscriptionDAL : ISubscription
    {
        private readonly string connectionString = "TrustServerCertificate=True;" +
                    "Server=mssqlstud.fhict.local;" +
                    "Database=dbi500009_grodebo;" +
                    "User Id=dbi500009_grodebo;" +
                    "Password=Grodebo;";
        public SubscriptionDAL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public int CreateSubscription(SubscriptionDTO subscriptionDTO)
        {
            int insertedId = -1;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "INSERT INTO [Subscription] (Protocol_ID, Patient_ID, Start_Date, Current_Step, Status) VALUES (@Protocol_ID, @Patient_ID, @Start_Date, @Current_Step, @Status); SELECT SCOPE_IDENTITY();";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@Protocol_ID", subscriptionDTO.Protocol.ID);
                        cmd.Parameters.AddWithValue("@Patient_ID", subscriptionDTO.Patient);
                        cmd.Parameters.AddWithValue("@Start_Date", subscriptionDTO.StartDate);
                        cmd.Parameters.AddWithValue("@Current_Step", 0);
                        cmd.Parameters.AddWithValue("@Status", 1);
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
