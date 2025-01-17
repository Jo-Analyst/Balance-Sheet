using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataBase
{
    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string birth { get; set; }
        public string address { get; set; }
        public string numberAddress { get; set; }
        public string phone { get; set; }
        public decimal income { get; set; }
        public decimal help { get; set; }
        public int numberOfMembers { get; set; }

        public void Save()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = id == 0
                        ? "INSERT INTO Persons (name, CPF, RG, address, number_address, phone, income, help, number_of_members, birth) VALUES (@name, @CPF, @RG, @address, @number_address, @phone, @income, @help, @number_of_members, @birth); SELECT @@identity"
                        : "UPDATE Persons SET name = @name, CPF = @CPF, RG = @RG, address = @address, number_address = @number_address, phone = @phone, income = @income, help = @help, number_of_members = @number_of_members, birth = @birth WHERE id = @id";

                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@CPF", CPF);
                    command.Parameters.AddWithValue("@RG", RG);
                    command.Parameters.AddWithValue("@birth", birth);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@number_address", numberAddress);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@income", income);
                    command.Parameters.AddWithValue("@help", help);
                    command.Parameters.AddWithValue("@number_of_members", numberOfMembers);
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

        public void Delete()
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

        static public int CountQuantityPersons()
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    connection.Open();
                    string sql = $"SELECT COUNT(id) AS quantityPersons FROM Persons ";
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

        static public int CountQuantityPersonsByNameOrAddress(string text, string column)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    connection.Open();
                    string sql = $"SELECT COUNT(id) AS quantityPersons FROM Persons WHERE {column} LIKE '%{text}%' ";
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

        static public DataTable FindById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT * FROM Persons WHERE Persons.id = {id}";
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
                    string sql = $"SELECT * FROM Persons WHERE CPF = '{CPF}'";
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

        public DataTable FindByCpfForPerson(string CPF, int person_id)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT * FROM Persons WHERE CPF = '{CPF}' AND id <> {person_id}";
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

        public DataTable FindAll(int page = 0, double quantRows = 15)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT * FROM Persons ORDER BY name OFFSET {page} ROWS FETCH  NEXT {quantRows} ROWS ONLY";
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

        public DataTable FindByNameOrAddress(string text, string column, int page = 0, double quantRows = 15)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT * FROM Persons WHERE {column} LIKE '%{text}%' ORDER BY name OFFSET {page} ROWS FETCH  NEXT {quantRows} ROWS ONLY";
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

        static public DataTable FindByPersonJoinBenefitsId(int person_id)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT persons.name, Persons.CPF, Persons.RG, Persons.birth, Persons.address, Persons.number_address, Persons.phone, Persons.income, Persons.help, Persons.number_of_members, Benefits_Received.description, Convert(VARCHAR, Benefits_Received.date_benefit, 103) AS date_benefit , Benefits_Received.person_id FROM Benefits_Received INNER JOIN Persons ON Persons.id = Benefits_Received.person_id WHERE Benefits_Received.person_id = {person_id}";
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

        static public int CountQuantityPersonWithBenefits()
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    connection.Open();
                    string sql = $"SELECT COUNT(*) as total_rows FROM (SELECT BR.person_id FROM Persons P LEFT JOIN Benefits_Received BR ON P.Id = BR.person_id  GROUP BY BR.person_id, P.name, P.CPF, P.RG, P.birth, P.address, P.number_address, P.phone, P.income, P.help, P.number_of_members HAVING Count(BR.person_id) > 0) as Subquery;";
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

        static public int CountQuantityByNameOrAddressPersonWithBenefits(string text, string column)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    connection.Open();
                    string sql = $"SELECT COUNT(*) as total_rows FROM (SELECT BR.person_id FROM Persons P LEFT JOIN Benefits_Received BR ON P.Id = BR.person_id  WHERE {column} LIKE '%{text}%' GROUP BY BR.person_id, P.name, P.CPF, P.RG, P.birth, P.address, P.number_address, P.phone, P.income, P.help, P.number_of_members HAVING Count(BR.person_id) > 0) as Subquery;";
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

        public DataTable FindAllPersonAndBenefits(int page, double quantRows)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT Count(BR.person_id) as quantity_benefits, BR.person_id, P.name, P.CPF, P.RG, P.birth, P.address, P.number_address, P.income, P.phone, P.help, P.number_of_members FROM Persons P LEFT JOIN Benefits_Received BR ON P.Id = BR.person_id GROUP BY BR.person_id, P.name, P.CPF, P.RG, P.birth, P.address, P.number_address, P.phone, P.income, P.help, P.number_of_members HAVING Count(BR.person_id) > 0 ORDER BY   P.name OFFSET {page} ROWS FETCH NEXT {quantRows} ROWS ONLY;";
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

        public DataTable FindAllPersonAndBenefitsByNameOrAddress(string text, string column, int page, double quantRows)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {                    
                    string sql = $"SELECT Count(BR.person_id) as quantity_benefits, BR.person_id, P.name, P.CPF, P.RG, P.birth, P.address, P.number_address, P.income, P.phone, P.help, P.number_of_members FROM Persons P LEFT JOIN Benefits_Received BR ON P.Id = BR.person_id WHERE {column} LIKE '%{text}%' GROUP BY BR.person_id, P.name, P.CPF, P.RG, P.birth, P.address, P.number_address, P.phone, P.income, P.help, P.number_of_members HAVING Count(BR.person_id) > 0 ORDER BY   P.name OFFSET {page} ROWS FETCH NEXT {quantRows} ROWS ONLY;";
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

        public DataTable FindAllPersonAndBenefits()
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT persons.name, Persons.CPF, Persons.RG, Persons.birth, Persons.address, Persons.number_address, Persons.phone, Persons.income, Persons.help, Persons.number_of_members, Benefits_Received.description, Convert(VARCHAR, Benefits_Received.date_benefit, 103) AS date_benefit , Benefits_Received.person_id FROM Benefits_Received INNER JOIN Persons ON Persons.id = Benefits_Received.person_id ORDER BY Persons.name, Benefits_Received.description ASC";
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

        public DataTable FindAllPersonAndBenefitsByNameOrAddress(string data, string column)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT persons.name, Persons.CPF, Persons.RG, Persons.birth, Persons.address, Persons.number_address, Persons.phone, Persons.income, Persons.help, Persons.number_of_members, Benefits_Received.description, Convert(VARCHAR, Benefits_Received.date_benefit, 103) AS date_benefit , Benefits_Received.person_id FROM Benefits_Received INNER JOIN Persons ON Persons.id = Benefits_Received.person_id where {column} LIKE '%{data}%' ORDER BY Persons.name, Benefits_Received.description ASC";
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