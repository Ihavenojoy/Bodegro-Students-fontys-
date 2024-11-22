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
    public class PatientDAL : IPatient
    {
        private readonly string connectionString;
        public PatientDAL(IConfiguration configuration)
        {
            if (configuration is null)
            {
                connectionString = "Server=mssqlstud.fhict.local;Database=dbi500009_grodebo;User Id=dbi500009_grodebo;Password=Grodebo;TrustServerCertificate=True;";
            }
            else
            {
                connectionString = configuration.GetConnectionString("DefaultConnection");
            }
            
        }
        public bool CreatePatient(PatientDTO patient)
        {
            bool isdone = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "INSERT INTO [Patient] (User_ID, Name, Email, PhoneNumber, MedicalHistory) VALUES (@User_ID, @Name, @Email, @PhoneNumber, @MedicalHistory); SELECT SCOPE_IDENTITY();";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@User_ID", patient.User_ID);
                        cmd.Parameters.AddWithValue("@Name", patient.Name);
                        cmd.Parameters.AddWithValue("@Email", patient.Email);
                        cmd.Parameters.AddWithValue("@Number", patient.PhoneNumber);
                        cmd.Parameters.AddWithValue("@MedicalHistory", patient.MedicalHistory);

                        conn.Open();
                        cmd.ExecuteScalar();
                        isdone = true;

                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("An SQL error occurred while creating a patient: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isdone;
        }

        // Method to read a product record by ID
        public List<int> GetPatientIDOfUser(int id)
        {
            List<int> list = new List<int>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string select = "SELECT Doctor_ID, Patient_ID FROM Doctor_Patient WHERE Doctor_ID = @Doctor_ID";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(select, conn))
                    {
                        cmd.Parameters.AddWithValue("@Doctor_ID", id);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(Convert.ToInt32(reader["Patient_ID"]));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An SQL error occurred while reading a product: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        public PatientDTO GetPatient(int id)
        {
            PatientDTO patient = new PatientDTO();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string select = "SELECT ID, Name, Email, PhoneNumber, MedicalHistory FROM Patient WHERE ID = @ID";
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
                                patient = new PatientDTO
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    Name = Convert.ToString(reader["Name"]),
                                    Email = Convert.ToString(reader["Email"]),
                                    PhoneNumber = Convert.ToInt32(reader["PhoneNumber"]),
                                    MedicalHistory = Convert.ToString(reader["MedicalHistory"]),
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An SQL error occurred while reading a product: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
            return patient;
        }

        // Method to update a patient record
        public bool UpdatePatient(PatientDTO patient)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string update = "UPDATE Patient SET Name = @Name, Email = @Email, PhoneNumber = @PhoneNumber, MedicalHistory = @MedicalHistory WHERE ID = @ID";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(update, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", patient.Name);
                        cmd.Parameters.AddWithValue("@Email", patient.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
                        cmd.Parameters.AddWithValue("@MedicalHistory", patient.MedicalHistory);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An SQL error occurred while updating a patient: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

            //// Method to get all products
            //public List<ProductDTO> GetAllProducts()
            //{
            //    List<ProductDTO> products = new List<ProductDTO>();
            //    SqlConnection conn = new SqlConnection(connectionString);
            //    try
            //    {
            //        string select = @"
            //                SELECT p.ID, p.Type, p.Standard_Value, IFNULL(r.Quantity, 0) AS Quantity, r.Expiredate 
            //                FROM product p
            //                LEFT JOIN receiver r ON p.ID = r.Product_ID";
            //        using (conn)
            //        {
            //            using (SqlCommand cmd = new SqlCommand(select, conn))
            //            {
            //                conn.Open();
            //                using (SqlDataReader reader = cmd.ExecuteReader())
            //                {
            //                    while (reader.Read())
            //                    {
            //                        products.Add(new ProductDTO
            //                        {
            //                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
            //                            Type = reader.GetString(reader.GetOrdinal("Type")),
            //                            Standard_Value = reader.GetDouble(reader.GetOrdinal("Standard_Value")),
            //                            Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
            //                            ExpireDate = reader.IsDBNull(reader.GetOrdinal("Expiredate"))
            //                                         ? DateTime.MinValue
            //                                         : reader.GetDateTime(reader.GetOrdinal("Expiredate"))
            //                        });
            //                    }
            //                }
            //            }
            //        }
            //        return products;
            //    }
            //    catch (SqlException ex)
            //    {
            //        Console.WriteLine("An SQL error occurred while retrieving products: " + ex.Message);
            //        return products;
            //    }
            //    finally
            //    {
            //        conn.Close();
            //    }
            //}
        }
    }
}
