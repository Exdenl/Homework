using MySql.Data.MySqlClient;
using System.Configuration;


public static class DatabaseHelper
{
    public static MySqlConnection CreateNewConnection()
    {
        var builder = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Database = "c#_orders",
            UserID = "root",
            Password = "735608",
            Pooling = true // 启用连接池
        };
        var connection = new MySqlConnection(builder.ConnectionString);
        connection.Open();
        return connection;
    }
}