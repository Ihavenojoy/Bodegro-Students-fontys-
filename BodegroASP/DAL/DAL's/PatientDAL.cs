using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
using Interfaces;

namespace DAL
{
    public class PatientDAL : IPatient
    {
        private readonly string connectionString = "TrustServerCertificate=True;" +
            "Server=mssqlstud.fhict.local;" +
            "Database=dbi500009_grodebo;" +
            "User Id=dbi500009_grodebo;" +
            "Password=Grodebo;";
        public int CreatePatient(PatientDTO patient)
        {
            int insertedId = -1;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string insert = "INSERT INTO [Patient] (Doctor_ID, Name, Email, PhoneNumber, MedicalHistory) VALUES (@Doctor_ID, @Name, @Email, @PhoneNumber, @MedicalHistory); SELECT SCOPE_IDENTITY();";
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@Doctor_ID", patient.Doctor_ID);
                        cmd.Parameters.AddWithValue("@Name", patient.Name);
                        cmd.Parameters.AddWithValue("@Email", patient.Email);
                        cmd.Parameters.AddWithValue("@Number", patient.PhoneNumber);
                        cmd.Parameters.AddWithValue("@MedicalHistory", patient.MedicalHistory);

                        conn.Open();
                        insertedId = Convert.ToInt32(cmd.ExecuteScalar());

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
            return insertedId;
        }

        // Method to read a product record by ID
        public List<int> GetPatientIDOfDoctor(int id)
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
                return null;
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        public PatientDTO GetPatient(int id, int DoctorID)
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
                                    Doctor_ID = DoctorID
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

        //// Method to delete a product record by ID
        //public bool DeleteProduct(int id)
        //{
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    try
        //    {
        //        string delete = "DELETE FROM Product WHERE ID = @ID";
        //        using (conn)
        //        {
        //            using (SqlCommand cmd = new SqlCommand(delete, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@ID", id);

        //                conn.Open();
        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("An SQL error occurred while deleting a product: " + ex.Message);
        //        return false;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

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
