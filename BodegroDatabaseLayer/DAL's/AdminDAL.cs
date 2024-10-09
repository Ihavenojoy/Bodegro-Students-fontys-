using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
using BodegroInterfaces;

namespace DAL
{
    public class AdminDAL : IAdmin
    {
        private readonly string connectionString = "TrustServerCertificate=True;" +
            "Server=mssqlstud.fhict.local;" +
            "Database=dbi500009_grodebo;" +
            "User Id=dbi500009_grodebo;" +
            "Password=Grodebo;";

        public int CreateAdmin(AdminDTO admin,string Password)
        {
            int insertedId = -1;
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
                        cmd.Parameters.AddWithValue("@Password", Password);

                        conn.Open();
                        insertedId = Convert.ToInt32(cmd.ExecuteScalar());

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
            return insertedId;
        }

        public AdminDTO AdminLogin(string Emailinput, string PassWordInput)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            AdminDTO adminDTO = new AdminDTO(null,null);
                try
            {
                string insert = "Select Name, Email From Admin WHERE Email = @Email AND Password = @Password";
                
                using (conn)
                {

                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", Emailinput);
                        cmd.Parameters.AddWithValue("@Password", PassWordInput);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                adminDTO = new AdminDTO(
                            (string)reader["Name"],
                            (string)reader["Email"]
                            );
                            }
                        }
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
            return adminDTO;
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
