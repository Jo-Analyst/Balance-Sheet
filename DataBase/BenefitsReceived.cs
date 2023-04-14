using System;
using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class BenefitsReceived
    {
        public int id { get; set; }
        public string description { get; set; }
        public DateTime dateBenefits { get; set; }
        public int person_id { get; set; }

        public void Save(SqlTransaction transaction)
        {
            string sql = id == 0
            ? "INSERT INTO Benefits_Received (description, date_benefits, person_id) VALUES (@description, @date_benefits, @person_id)"
            : "UPDATE Persons SET description = @description, date_benefits = @date_benefits, person_id = @person_id WHERE id = @id";
            SqlCommand command = new SqlCommand(sql, transaction.Connection, transaction);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@date_benefits", dateBenefits);
            command.Parameters.AddWithValue("@person_id", person_id);
            command.CommandText = sql;
            try
            {
                command.Transaction = transaction;
                command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByPersonId(int person_id)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT * FROM Benefits_Received WHERE person_id = {person_id}";
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
