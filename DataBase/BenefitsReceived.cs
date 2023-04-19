﻿using System;
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

        public void Save()
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                connection.Open();
                string sql = id == 0
                ? "INSERT INTO Benefits_Received (description, date_benefit, person_id) VALUES (@description, @date_benefit, @person_id); SELECT @@identity"
                : "UPDATE Benefits_Received SET description = @description, date_benefit = @date_benefit, person_id = @person_id WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@date_benefit", dateBenefits);
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

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                string sql = "DELETE FROM Benefits_Received WHERE id = @id";
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

        static public DataTable CountBenefitsByPersonId(int person_id)
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                try
                {
                    string sql = $"SELECT COUNT(description) as count_Benefits, description, person_id  FROM Benefits_Received WHERE person_id = {person_id} GROUP BY description, person_id";
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    adapter.SelectCommand.CommandText = sql;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
