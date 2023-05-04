using System.Data.SqlClient;

namespace DataBase
{
    public class Backup
    {
        public void GenerateBackup(string path)
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionStringMaster))
            {
                string sql = $"BACKUP DATABASE dbCras TO DISK = '{path}'";
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

        public void RestoreDataBase(string path)
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionStringMaster))
            {
                string sql = $"RESTORE DATABASE dbCras FROM DISK = '{path}'";
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
