namespace DAL;

using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;


public class DatabaseConnection
{
    private string connectionString = "TrustServerCertificate=True;Server=mssqlstud.fhict.local;Database=dbi500009_grodebo;User Id=dbi500009_grodebo;Password=Grodebo;";

    public bool ConnectionTest()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
    }
}
