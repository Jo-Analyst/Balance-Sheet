using System;
using System.Data.SqlClient;

namespace DataBase
{
    public class BenefitsReceived
    {
        public int id { get; set; }
        public string description { get; set; }
        public DateTime date_benefits { get; set; }
        public int person_id { get; set; }

        public void Save()
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                string sql = id == 0
                    ? "INSERT INTO Benefits_Received (description, date_benefits, person_id) VALUES (@description, @date_benefits, @person_id)"
                    : "UPDATE Persons SET description = @description, date_benefits = @date_benefits, person_id = @person_id WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@date_benefits", date_benefits);
                command.Parameters.AddWithValue("@person_id", person_id);
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

        public void DELETE()
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                string sql = "DELETE FROM Persons WHERE id = @id";
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
