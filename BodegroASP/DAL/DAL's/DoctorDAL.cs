using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
using Interfaces;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DoctorDAL: IDoctor
    {
        private readonly string connectionString;

        public DoctorDAL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public int CreateDoctor(DoctorDTO doctor, string password)
        {
            int insertedId = -1;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "INSERT INTO [Doctor] (Admin_ID, Name, Email, Regio, IsActive, Password) VALUES (@Admin_ID, @Name, @Email, @Regio,@IsActive, @Password); SELECT SCOPE_IDENTITY();";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@Admin_ID", doctor.Admin_ID);
                        cmd.Parameters.AddWithValue("@Name", doctor.Name);
                        cmd.Parameters.AddWithValue("@Email", doctor.Email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Regio", doctor.Regio);
                        cmd.Parameters.AddWithValue("@IsActive", doctor.IsActive);

                        conn.Open();
                        insertedId = Convert.ToInt32(cmd.ExecuteScalar());

                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("An SQL error occurred while creating a doctor: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return insertedId;
        }
        public bool DoctorExists(string email)
        {
            int count = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string select = "SELECT COUNT(*) FROM [Doctor] WHERE Email = @Email";
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
                Debug.WriteLine("An SQL error occurred while checking if a doctor exists: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return count > 0;
        }

        // Method to read a product record by ID
        //public ProductDTO GetProductById(int id)
        //{
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    try
        //    {
        //        string select = "SELECT ID, Type, Standard_Value FROM Product WHERE ID = @ID";
        //        using (conn)
        //        {
        //            using (SqlCommand cmd = new SqlCommand(select, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@ID", id);

        //                conn.Open();
        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        return new ProductDTO
        //                        {
        //                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
        //                            Type = reader.GetString(reader.GetOrdinal("Type")),
        //                            Standard_Value = reader.GetDouble(reader.GetOrdinal("Standard_Value"))
        //                        };
        //                    }
        //                    return null;
        //                }
        //            }
        //        }
        //    }

        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("An SQL error occurred while reading a product: " + ex.Message);
        //        return null;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        //// Method to update a product record
        //public bool UpdateProduct(ProductDTO product)
        //{
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    try
        //    {
        //        string update = "UPDATE Product SET Type = @Type, Standard_Value = @Standard_Value WHERE ID = @ID";
        //        using (conn)
        //        {
        //            using (SqlCommand cmd = new SqlCommand(update, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@Type", product.Type);
        //                cmd.Parameters.AddWithValue("@Standard_Value", product.Standard_Value);
        //                cmd.Parameters.AddWithValue("@ID", product.ID);

        //                conn.Open();
        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("An SQL error occurred while updating a product: " + ex.Message);
        //        return false;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        public bool SoftDeleteDoctor(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string delete = "UPDATE [Doctor] SET IsActive = 0 WHERE ID = @ID";
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
                Debug.WriteLine("An SQL error occurred while deleting a doctor: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public List<DoctorDTO> GetAllDoctors()
        {
            List<DoctorDTO> doctors = new List<DoctorDTO>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string select = "SELECT ID, Name, Email, Regio, Admin_ID FROM [Doctor] WHERE IsActive = 1";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(select, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                doctors.Add(new DoctorDTO
                                {

                                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    Regio = reader.GetInt32(reader.GetOrdinal("Regio")),
                                    Admin_ID = reader.GetInt32(reader.GetOrdinal("Admin_ID"))
                                    

                                });
                            }
                        }
                    }
                }
                return doctors;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("An SQL error occurred while retrieving doctors: " + ex.Message);
                return doctors;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
