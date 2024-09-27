namespace BodegroDatabaseLayer;

using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;

public class DatabaseConnection
{
    private string connectionString = "TrustServerCertificate=True;Server=mssqlstud.fhict.local;Database=dbi500009_grodebo;User Id=dbi500009_grodebo;Password=Grodebo;";

    public string OpenConnection()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                return "Connection succecsfull";
            }
            catch (SqlException ex)
            {
                return $"Connection failure {Convert.ToString(ex)}";
            }
        }
    }
}
