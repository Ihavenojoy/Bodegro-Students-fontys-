using Interfaces;
using DTO;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Twofactor;

namespace DAL
{
    public class LoginDal : ILogin
    {
        private readonly string connectionString = "TrustServerCertificate=True;" +
            "Server=mssqlstud.fhict.local;" +
            "Database=dbi500009_grodebo;" +
            "User Id=dbi500009_grodebo;" +
            "Password=Grodebo;";

        public DoctorDTO DoctorLogin(string Emailinput, string PassWordInput)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            DoctorDTO doctorDTO = new DoctorDTO();
            try
            {
                string insert = "Select ID, Name, Email, Regio, Admin_ID From Doctor WHERE Email = @Email AND Password = @Password";

                using (conn)
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", Emailinput);
                        cmd.Parameters.AddWithValue("@Password", PassWordInput);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                doctorDTO = new DoctorDTO
                                {
                                    ID = (int)reader["ID"],
                                    Name = (string)reader["Name"],
                                    Email = (string)reader["Email"],
                                    Admin_ID = (int)reader["Admin_ID"],
                                    Regio = (int)reader["Regio"]
                                };
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
            return doctorDTO;
        }

        public AdminDTO AdminLogin(string Emailinput, string PassWordInput)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            AdminDTO adminDTO = new AdminDTO();
            try
            {
                string insert = "Select ID, Name, Email From Admin WHERE Email = @Email AND Password = @Password";

                using (conn)
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", Emailinput);
                        cmd.Parameters.AddWithValue("@Password", PassWordInput);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                adminDTO = new AdminDTO
                                {
                                    ID = (int)reader["ID"],
                                    Name = (string)reader["Name"],
                                    Email = (string)reader["Email"]
                                };
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
        public void TwofactorActivation(string UserEmail)
        {
            int OTP = Convert.ToInt32(Generate.OTP(Code32.Encode(Generate.RandomKey(32)), 6, 30));
        }
        public bool TwofactorCheck(string Userinput)
        {
            return false;
        }
    }
}



