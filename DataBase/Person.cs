using System;
using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string address { get; set; }
        public string numberAddress { get; set; }
        public string phone { get; set; }
        public decimal income { get; set; }
        public decimal help { get; set; }
        public int numberOfMembers { get; set; }

        public void Save(DataTable dtBenefitsReceived)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = id == 0
                        ? "INSERT INTO Persons (name, CPF, RG, address, number_address, phone, income, help, number_of_members) VALUES (@name, @CPF, @RG, @address, @number_address, @phone, @income, @help, @number_of_members); SELECT @@identity"
                        : "UPDATE Persons SET name = @name, CPF = @CPF, RG = @RG, address = @address, number_address = @number_address, phone = @phone, income = @income, help = @help, number_of_members = @number_of_members WHERE id = @id";

                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    SqlCommand command = new SqlCommand(sql, connection, transaction);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@CPF", CPF);
                    command.Parameters.AddWithValue("@RG", RG);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@number_address", numberAddress);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@income", income);
                    command.Parameters.AddWithValue("@help", help);
                    command.Parameters.AddWithValue("@number_of_members", numberOfMembers);
                    try
                    {
                        command.Transaction = transaction;

                        BenefitsReceived benefitsReceived = new BenefitsReceived();
                        foreach (DataRow rowBenefitsReceived in dtBenefitsReceived.Rows)
                        {
                            benefitsReceived.description = rowBenefitsReceived["description"].ToString();
                            benefitsReceived.dateBenefits = Convert.ToDateTime(rowBenefitsReceived["date_benefits"]);
                            benefitsReceived.person_id = Convert.ToInt32(command.ExecuteScalar());
                            benefitsReceived.Save(transaction);
                        }


                        //command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
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

        public DataTable FindById()
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT persons.name, persons.CPF, persons.RG, persons.address, persons.phone, persons.income, persons.help, persons.number_of_members, Benefits_Received.description FROM Persons INNER JOIN Benefits_Received ON Benefits_Received.person_id = Persons.id WHERE Persons.id = {id}";
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
                    string sql = "SELECT persons.name, persons.CPF, persons.RG, persons.address, persons.phone, persons.income, persons.help, persons.number_of_members, Benefits_Received.description FROM Persons INNER JOIN Benefits_Received ON Benefits_Received.person_id = Persons.id";
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