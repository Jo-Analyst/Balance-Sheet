using System.Data.SqlClient;

namespace DataBase
{
    public class DB
    {
        static public bool ExistsDataBase()
        {
            bool existsDataBase = false;

            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionStringMaster))
            {
                SqlCommand comando = new SqlCommand("Select * from Sys.Databases where name = 'dbCRAS'", connection);
                try
                {
                    connection.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.Read())
                    {
                        existsDataBase = true;
                    }

                }
                catch
                {
                    throw;
                }
            }

            return existsDataBase;
        }

        static public void CreateTables()
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                string sql = "CREATE TABLE [dbo].[Persons] (" +
                "    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), " +
                "    [name] VARCHAR(200) NULL, " +
                "    [CPF] VARCHAR(14) NULL, " +
                "    [RG] VARCHAR(20) NULL, " +
                "    [address] VARCHAR(200) NULL," +
                "    [number_address] VARCHAR(MAX) NULL," +
                "    [phone] VARCHAR(20) NULL, " +
                "    [income] DECIMAL(18, 2) DEFAULT ((0)) NULL," +
                "    [help] DECIMAL(18, 2)  DEFAULT ((0)) NULL," +
                "    [number_of_members] INT NULL);" +

                "CREATE TABLE [dbo].[Benefits_Received] (" +
                "    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), " +
                "    [description] VARCHAR(MAX) NULL, " +
                "    [date_benefit] Date NULL," +
                "    [person_id] INT NOT NULL," +
                "    FOREIGN KEY ([person_id]) REFERENCES [dbo].[persons](id) ON DELETE CASCADE );";
                SqlCommand command = new SqlCommand(sql, connection);
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

        static public void CreateDatabase()
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionStringMaster))
            {
                string sql = "CREATE DATABASE dbCRAS";
                SqlCommand command = new SqlCommand(sql, connection);
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