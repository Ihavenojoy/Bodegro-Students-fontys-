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
        private readonly string connectionString;
        public UserDAL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public UserDTO UserLogin(string Emailinput, string PassWordInput)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            UserDTO UserDTO = new UserDTO();
            try
            {
                string insert = "Select ID, Name, Email, Regio, User_ID From User WHERE Email = @Email AND Password = @Password";

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
                string insert = "INSERT INTO [User] (ID, Name, Email, Role, IsActive, Password) VALUES (@ID, @Name, @Email, @Role ,@IsActive, @Password); SELECT SCOPE_IDENTITY();";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@User_ID", User.ID);
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
                string update = "UPDATE User SET Name = @Name, Email = @Email, Password = @Password, Role = @Role, IsActive= @IsActive WHERE ID = @ID";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(update, conn))
                    {
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
                string select = "SELECT ID, Name, Email, Regio, User_ID FROM [User] WHERE IsActive = 1";
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
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    Role = (int)reader["Role"]
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

    }
}



