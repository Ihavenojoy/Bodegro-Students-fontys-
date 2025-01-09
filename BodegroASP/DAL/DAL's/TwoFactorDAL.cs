using DTO;
using Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL_s
{
    public class TwoFactorDAL : ITwoFactor
    {
        private readonly string connectionString;
        public TwoFactorDAL(IConfiguration configuration)
        {
            connectionString = "Server=mssqlstud.fhict.local;Database=dbi500009_grodebo;User Id=dbi500009_grodebo;Password=Grodebo;TrustServerCertificate=True;";
            //connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool Create(int userid, string key, DateTime senttime)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "INSERT INTO [User_2FA] (ID, OTP, SentTime) VALUES (@ID, @OTP, @SentTime)";

                using (conn)
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", userid);
                        cmd.Parameters.AddWithValue("@OTP", key);
                        cmd.Parameters.AddWithValue("@SentTime", senttime);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        result = rowsAffected > 0;
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
        public bool Exist(int userid)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "SELECT * FROM [User_2FA] Where (ID = @ID)";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", userid);
                        conn.Open();
                        int count = (int)cmd.ExecuteNonQuery();
                        if (count > 0) { result = true; };
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
        public bool Remove(int userid)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "DELETE FROM [User_2FA] Where (ID = @ID)";
                using (conn)
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", userid);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0) { result = true; };
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

        public async Task<List<TwoFactorDTO>> GetAll()
        {
            List<TwoFactorDTO> list = new List<TwoFactorDTO>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "SELECT ID, OTP, SentTime FROM [User_2FA] ";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TwoFactorDTO twofactor = new()
                                {
                                    UserId = (int)reader["ID"],
                                    OTP = (string)reader["OTP"],
                                    RequestTime = (DateTime)reader["SentTime"]
                                };
                                list.Add(twofactor);
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
        public bool Check(int userid, string passwordinput)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "SELECT COUNT FROM [User_2FA] Where (ID = @ID, OTP = @OTP)";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", userid);
                        cmd.Parameters.AddWithValue("@OTP", passwordinput);
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0) { result = true; };
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
        public TwoFactorDTO GetById(int userid)
        {
            TwoFactorDTO twofactor = new();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "SELECT ID, OTP, SentTime FROM [User_2FA] Where ID = @ID";
                using (conn)
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", userid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                twofactor = new()
                                {
                                    UserId = (int)reader["ID"],
                                    OTP = (string)reader["OTP"],
                                    RequestTime = (DateTime)reader["SentTime"]
                                };
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
            return twofactor;
        }
    }
}
