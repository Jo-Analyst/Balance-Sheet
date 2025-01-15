using System;
using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class Service
    {
        public int id { get; set; }
        public string description { get; set; }
        public DateTime dateService { get; set; }
        public int person_id { get; set; }

        public void Save()
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                connection.Open();
                string sql = id == 0
                ? "INSERT INTO Services (description, date_service, person_id) VALUES (@description, @date_service, @person_id); SELECT @@identity"
                : "UPDATE Services SET description = @description, date_service = @date_service, person_id = @person_id WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@date_service", dateService);
                command.Parameters.AddWithValue("@person_id", person_id);
                command.CommandText = sql;
                try
                {
                    if (id == 0)
                        id = Convert.ToInt32(command.ExecuteScalar());
                    else
                        command.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }

        static public DataTable FindByPersonId(int person_id, int page = 0, double quantRows = 15)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT id, description, CONVERT(VARCHAR, date_service, 103) AS date_service, person_id FROM Services WHERE person_id = {person_id} ORDER BY id DESC OFFSET {page} ROWS FETCH  NEXT {quantRows} ROWS ONLY";
                    var adapter = new SqlDataAdapter(sql, connection);
                    adapter.SelectCommand.CommandText = sql;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        }

       static public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                string sql = "DELETE FROM Services WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                command.CommandText = sql;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
