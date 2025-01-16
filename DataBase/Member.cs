using System;
using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class Member
    {
        public int id { get; set; }
        public string name { get; set; }
        public string CPF { get; set; }
        public string birth { get; set; }
        public string address { get; set; }
        public string numberAddress { get; set; }
        public string phone { get; set; }
        public int personId { get; set; }

        public void Save()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = id == 0
                        ? "INSERT INTO Members (name, CPF,  address, number_address, phone, birth, person_id) VALUES (@name, @CPF, @address, @number_address, @phone, @birth, @person_id); SELECT @@identity"
                        : "UPDATE Members SET name = @name, CPF = @CPF, address = @address, number_address = @number_address, phone = @phone, birth = @birth WHERE id = @id";

                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@CPF", CPF);
                    command.Parameters.AddWithValue("@birth", birth);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@number_address", numberAddress);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@person_id", personId);
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
            catch
            {
                throw;
            }
        }

        static public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                string sql = "DELETE FROM Members WHERE id = @id";
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

        static public DataTable FindByPersonId(int personId, int page, double quantRows)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT * FROM Members WHERE Members.person_id = {personId} ORDER BY name OFFSET {page} ROWS FETCH  NEXT {quantRows} ROWS ONLY";
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

        public DataTable FindByCPF(string CPF)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT * FROM Members WHERE CPF = '{CPF}'";
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

        static public int CountQuantityMember()
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    connection.Open();
                    string sql = $"SELECT COUNT(id) AS quantity FROM Members";
                    var command = new SqlCommand(sql, connection);
                    command.CommandText = sql;

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByCpfForMember(string CPF, int person_id)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT * FROM Members WHERE CPF = '{CPF}' AND id <> {person_id}";
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

        public DataTable FindAll()
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = "SELECT * FROM Members ORDER BY name";
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

        public DataTable FindByNameOrAddress(string data, string column)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT * FROM Members WHERE {column} LIKE '%{data}%'  ORDER BY name";
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
    }
}