﻿using System;
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
        private readonly string connectionString;
        public SubscriptionDAL(IConfiguration configuration)
        {
            connectionString = "Server=mssqlstud.fhict.local;Database=dbi500009_grodebo;User Id=dbi500009_grodebo;Password=Grodebo;TrustServerCertificate=True;";
            //connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool CreateSubscription(SubscriptionDTO subscriptionDTO)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "INSERT INTO [Subscription] (Protocol_ID, Patient_ID, Start_Date, Current_Step, Status) VALUES (@Protocol_ID, @Patient_ID, @Start_Date, @Current_Step, @Status); SELECT SCOPE_IDENTITY();";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@Protocol_ID", subscriptionDTO.ProtocolID);
                        cmd.Parameters.AddWithValue("@Patient_ID", subscriptionDTO.PatientID);
                        cmd.Parameters.AddWithValue("@Start_Date", subscriptionDTO.StartDate);
                        cmd.Parameters.AddWithValue("@Current_Step", 0);
                        cmd.Parameters.AddWithValue("@Status", 1);
                        conn.Open();
                        Convert.ToInt32(cmd.ExecuteScalar());
                        result = true;
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
            return result;
        }

        public List<SubscriptionDTO> GetSubscriptionsOfPatiënt(int PatiëntID)
        {
            List<SubscriptionDTO> list = [];
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string select = "SELECT ID, Protocol_ID, Patient_ID, Start_Date, Current_Step, Status FROM Subscription WHERE Patient_ID = @Patient_ID AND Status = 1";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(select, conn))
                    {
                        cmd.Parameters.AddWithValue("@Patient_ID", PatiëntID);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SubscriptionDTO subscription = new SubscriptionDTO
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    StartDate = Convert.ToDateTime(reader["Start_Date"]),
                                    ProtocolID = Convert.ToInt32(reader["Protocol_ID"]),
                                    PatientID = Convert.ToInt32(reader["Patient_ID"]),
                                    StepsTaken = Convert.ToInt32(reader["Current_Step"])
                                };
                                list.Add(subscription);
                            }
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("An SQL error occurred while reading a Protocol: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        public bool SoftDeleteSubscription(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string delete = "UPDATE [Subscription] SET Status = 0 WHERE ID = @ID";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(delete, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("An SQL error occurred while deleting a User: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public async Task<List<SubscriptionDTO>> AsyncGetAll()
        {
            List<SubscriptionDTO> list = new();
            using SqlConnection conn = new(connectionString);

            try
            {
                string select = "SELECT ID, Protocol_ID, Patient_ID, Start_Date, Current_Step, Status FROM Subscription WHERE Status = 1";

                using SqlCommand cmd = new(select, conn);
                await conn.OpenAsync();

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    SubscriptionDTO subscription = new()
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("ID")),
                        StartDate = reader.GetDateTime(reader.GetOrdinal("Start_Date")),
                        ProtocolID = reader.GetInt32(reader.GetOrdinal("Protocol_ID")),
                        PatientID = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
                        StepsTaken = reader.GetInt32(reader.GetOrdinal("Current_Step"))
                    };
                    list.Add(subscription);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An SQL error occurred while reading a Protocol: " + ex.Message);
                // Consider logging this error instead of writing to the console in production
            }

            return list;
        }
        public List<SubscriptionDTO> GetAll()
        {
            List<SubscriptionDTO> list = [];
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string select = "SELECT ID, Protocol_ID, Patient_ID, Start_Date, Current_Step, Status FROM Subscription WHERE Status = 1";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(select, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SubscriptionDTO subscription = new SubscriptionDTO
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    StartDate = Convert.ToDateTime(reader["Start_Date"]),
                                    ProtocolID = Convert.ToInt32(reader["Protocol_ID"]),
                                    PatientID = Convert.ToInt32(reader["Patient_ID"]),
                                    StepsTaken = Convert.ToInt32(reader["Current_Step"])
                                };
                                list.Add(subscription);
                            }
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("An SQL error occurred while reading a Protocol: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        public List<SubscriptionDTO> GetInactive()
        {
            List<SubscriptionDTO> list = [];
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string select = "SELECT ID, Protocol_ID, Patient_ID, Start_Date, Current_Step, Status FROM Subscription WHERE Status = 0";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(select, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SubscriptionDTO subscription = new SubscriptionDTO
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    StartDate = Convert.ToDateTime(reader["Start_Date"]),
                                    ProtocolID = Convert.ToInt32(reader["Protocol_ID"]),
                                    PatientID = Convert.ToInt32(reader["Patient_ID"]),
                                    StepsTaken = Convert.ToInt32(reader["Current_Step"])
                                };
                                list.Add(subscription);
                            }
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("An SQL error occurred while reading a Protocol: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        public bool SetActive(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string update = "UPDATE [Subscription] SET IsActive= @IsActive WHERE ID = @ID";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(update, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@IsActive", 1);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An SQL error occurred while updating a user: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
