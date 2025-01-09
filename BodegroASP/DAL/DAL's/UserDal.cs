﻿using Interfaces;
using DTO;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Twofactor;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class UserDAL : IUser
    {
        private readonly string connectionString = "TrustServerCertificate=True;" +
                    "Server=mssqlstud.fhict.local;" +
                    "Database=dbi500009_grodebo;" +
                    "User Id=dbi500009_grodebo;" +
                    "Password=Grodebo;";
        public UserDAL(IConfiguration configuration)
        {
            // connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public UserDTO UserLogin(string Emailinput, string PassWordInput)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            UserDTO UserDTO = new UserDTO();
            try
            {
                string insert = "Select ID, Name, Email, Role From [User] WHERE Email = @Email AND Password = @Password";

                using (conn)
                {
                    //conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", Emailinput);
                        cmd.Parameters.AddWithValue("@Password", PassWordInput);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserDTO = new UserDTO
                                {
                                    ID = (int)reader["ID"],
                                    Name = (string)reader["Name"],
                                    Email = (string)reader["Email"],
                                    Role = (int)reader["Role"],
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("An SQL error occurred while creating a User: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return UserDTO;
        }


        public void TwofactorActivation(string UserEmail)
        {
            int OTP = Convert.ToInt32(Generate.OTP(Code32.Encode(Generate.RandomKey(32)), 6, 30));
        }
        public bool TwofactorCheck(string Userinput)
        {
            return false;
        }
        public bool CreateUser(UserDTO User, string password)
        {
            bool isdone = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "INSERT INTO [User] (Name, Email, Role, IsActive, Password) VALUES (@Name, @Email, @Role ,@IsActive, @Password);";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", User.Name);
                        cmd.Parameters.AddWithValue("@Email", User.Email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Role", User.Role);
                        cmd.Parameters.AddWithValue("@IsActive", User.IsActive);

                        conn.Open();
                        cmd.ExecuteScalar();
                        isdone = true;

                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("An SQL error occurred while creating a User: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isdone;
        }
        public bool UserExists(string email)
        {
            int count = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string select = "SELECT COUNT(*) FROM [User] WHERE Email = @Email";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(select, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        conn.Open();
                        count = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("An SQL error occurred while checking if a User exists: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return count > 0;
        }


        // Method to update a user record
        public bool UpdateUser(UserDTO user, string password)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string update = "UPDATE [User] SET Name = @Name, Email = @Email, Password = @Password, Role = @Role, IsActive= @IsActive WHERE ID = @ID";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(update, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", user.ID);
                        cmd.Parameters.AddWithValue("@Name", user.Name);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Role", user.Role);
                        cmd.Parameters.AddWithValue("@IsActive", user.IsActive);

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
        public bool SoftDeleteUser(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string delete = "UPDATE [User] SET IsActive = 0 WHERE ID = @ID";
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
        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> Users = new List<UserDTO>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string select = "SELECT ID, Name, Email FROM [User] WHERE IsActive = 1 AND Role = 2";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(select, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Users.Add(new UserDTO
                                {
                                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Email = reader.GetString(reader.GetOrdinal("Email"))
                                });
                            }
                        }
                    }
                }
                return Users;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("An SQL error occurred while retrieving Users: " + ex.Message);
                return Users;
            }
            finally
            {
                conn.Close();
            }

        }
        public UserDTO GetUserByID(int id)
        {
            UserDTO user = new UserDTO();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string select = "SELECT ID, Name, Email, Role FROM [User] WHERE ID = @ID";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(select, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new UserDTO
                                {
                                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    Role = (int)reader["Role"]
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An SQL error occurred while reading a user: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
            return user;
        }

        public bool LinkDoctorToPatient(int patientID, int doctorID)
        {
            bool isDone = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if the record already exists
                    string checkQuery = "SELECT COUNT(*) FROM Doctor_Patient WHERE Doctor_ID = @doctor_ID AND Patient_ID = @patient_ID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@doctor_ID", doctorID);
                        checkCmd.Parameters.AddWithValue("@patient_ID", patientID);

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            // Record already exists, return false
                            return false;
                        }
                    }

                    // Insert the new record
                    string insertQuery = "INSERT INTO Doctor_Patient (Doctor_ID, Patient_ID) VALUES (@doctor_ID, @patient_ID)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@doctor_ID", doctorID);
                        insertCmd.Parameters.AddWithValue("@patient_ID", patientID);

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            isDone = true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return isDone;
        }


    }
}



