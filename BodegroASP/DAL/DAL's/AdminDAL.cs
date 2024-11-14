using DTO;
using Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;



namespace DAL
{
    public class AdminDAL : IAdmin
    {

        private readonly string connectionString;

        public AdminDAL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool CreateAdmin(AdminDTO admin, string password)
        {
            bool isdone = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "INSERT INTO [Admin] (Name, Email, Password) VALUES (@Name, @Email, @Password); SELECT SCOPE_IDENTITY();";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", admin.Name);
                        cmd.Parameters.AddWithValue("@Email", admin.Email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        conn.Open();
                        cmd.ExecuteScalar();
                        isdone = true;

                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("An SQL error occurred while creating a admin: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isdone;
        }
        public bool AdminExists(string email)
        {
            int count = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string select = "SELECT COUNT(*) FROM [Admin] WHERE Email = @Email";
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
                Debug.WriteLine("An SQL error occurred while checking if a admin exists: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return count > 0;
        }



        //// Method to update a product record
        public bool UpdateAdmin(AdminDTO admin)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string update = "UPDATE Admin SET Name = @Name, Email = @Email WHERE ID = @ID";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(update, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", admin.Name);
                        cmd.Parameters.AddWithValue("@Email", admin.Email);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An SQL error occurred while updating a admin: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool SoftDeleteAdmin(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string delete = "UPDATE [Admin] SET IsActive = 0 WHERE ID = @ID";
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
                Debug.WriteLine("An SQL error occurred while deleting a admin: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public List<AdminDTO> GetAllAdmins()
        {
            List<AdminDTO> doctors = new List<AdminDTO>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string select = "SELECT ID, Name, Email FROM [Admin] WHERE IsActive = 1";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(select, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                doctors.Add(new AdminDTO
                                {
                                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Email = reader.GetString(reader.GetOrdinal("Email"))
                                });
                            }
                        }
                    }
                }
                return doctors;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("An SQL error occurred while retrieving admins: " + ex.Message);
                return doctors;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
