using DTO;
using Interfaces;
using Microsoft.Data.SqlClient;

namespace DAL;

public class RequestDAL : IRequest
{
    private readonly string connectionString = "Server=mssqlstud.fhict.local;Database=dbi500009_grodebo;User Id=dbi500009_grodebo;Password=Grodebo;TrustServerCertificate=True;";
    public bool CreateRequest(RequestDTO requestDTO)
    {
        using SqlConnection connection = new(connectionString);
        try
        {
            connection.Open();
            string queryString =
                @"INSERT INTO Request (Description, Explanation, Important, Finished) OUTPUT INSERTED.ID VALUES (@Description, @Explanation, @Important,@Finished);";

            using SqlCommand command = new(queryString, connection);
            command.Parameters.AddWithValue("@Description", requestDTO.description);
            command.Parameters.AddWithValue("@Explanation", requestDTO.explanation);
            command.Parameters.AddWithValue("@Important", requestDTO.important);
            command.Parameters.AddWithValue("@Finished", false);

            int newRequestID = (int)command.ExecuteScalar();

            requestDTO.id = newRequestID;
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        finally
        {
            connection.Close();
        }
    }

    public List<RequestDTO> GetRequests()
    {
        List<RequestDTO > requests = new List<RequestDTO>();
        using SqlConnection conn = new(connectionString);
        try
        {
            conn.Open();
            string query = "SELECT ID, Description, Explanation, Important FROM [Request]";

            using SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["ID"];
                string description = (string)reader["Description"];
                string explanation = (string)reader["Explanation"];
                bool important = (bool)reader["Important"];
                RequestDTO request = new RequestDTO()
                {
                    id = id,
                    description = description,
                    explanation = explanation,
                    important = important
                };
                requests.Add(request);
            }
            return requests;
        }
        catch
        {
            return requests;
        }
        finally
        {
            conn.Close();
        }
    }

    public bool Update(RequestDTO requestDTO)
    {
        using SqlConnection connection = new(connectionString);
        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();

        try
        {

            string query =
                "Update request SET Description = @Description, Explanation = @Explanation, Important = @Important, Finished = @Finished where id = @Id;";
            using SqlCommand command = new(query, connection);
            command.Transaction = transaction;

            command.Parameters.AddWithValue("@Description", requestDTO.description);
            command.Parameters.AddWithValue("@Explanation", requestDTO.explanation);
            command.Parameters.AddWithValue("@Important", requestDTO.important);
            command.Parameters.AddWithValue("@Finished", requestDTO.finished);
            command.Parameters.AddWithValue("@Id", requestDTO.id);

            int rowsAffected = command.ExecuteNonQuery();
            transaction.Commit();

            return rowsAffected > 0;

        }
        catch (Exception e)
        {
            transaction.Rollback();
            throw new Exception("Failed to update user.");
        }
        finally
        {
            connection.Close();
        }
    }

    public RequestDTO GetRequestById(int id)
    {
        RequestDTO request = new RequestDTO();
        using SqlConnection conn = new(connectionString);
        try
        {
            conn.Open();
            string query = "Select Description, Explanation, Important, Finished from Request where id = @Id;";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                request.id = id;
                request.description = (string)reader["Description"];
                request.explanation = (string)reader["Explanation"];
                request.important = (bool)reader["Important"];
                request.finished = reader["Finished"] is DBNull ? (int?)null : (int?)reader["Finished"];
            }

            return request;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("Failed to get request.");
        }
        finally
        {
            conn.Close();
        }
    }
}