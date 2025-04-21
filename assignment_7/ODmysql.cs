using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;


namespace OrderManagement
{
    public class DatabaseHandler
    {
        readonly string connectionString = "server=localhost;port=3306;database=orderdb;user=root;password=123456;";
        MySqlConnection connection;

        public DatabaseHandler()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();

            var tableExistQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='orderdb' AND TABLE_NAME='orderdetail';";
            var tableExists = Convert.ToInt32(new MySqlCommand(tableExistQuery, connection).ExecuteScalar()) > 0;

            if (!tableExists)
            {
                var createTableQuery = "CREATE TABLE orderdetail(" +
                    "id VARCHAR(100) PRIMARY KEY," +
                    "obname VARCHAR(100) NOT NULL," +
                    "client VARCHAR(100) NOT NULL," +
                    "price DOUBLE NOT NULL);";
                new MySqlCommand(createTableQuery, connection).ExecuteNonQuery();
            }

            connection.Close();
        }

        public void InsertOrder(string id, string productName, string customer, double price)
        {
            ExecuteCommand("INSERT INTO orderdetail VALUES(@id, @productName, @customer, @price);",
                new Dictionary<string, object> { { "@id", id }, { "@productName", productName }, { "@customer", customer }, { "@price", price } });
        }

        public bool RemoveOrder(string id)
        {
            return ExecuteCommand("DELETE FROM orderdetail WHERE id=@id;", new Dictionary<string, object> { { "@id", id } }) > 0;
        }

        public void UpdateOrder(string id, string productName = null, string customer = null, double? price = null)
        {
            var updates = new List<string>();
            var parameters = new Dictionary<string, object> { { "@id", id } };

            if (!string.IsNullOrEmpty(productName)) { updates.Add("obname=@productName"); parameters.Add("@productName", productName); }
            if (!string.IsNullOrEmpty(customer)) { updates.Add("client=@customer"); parameters.Add("@customer", customer); }
            if (price.HasValue) { updates.Add("price=@price"); parameters.Add("@price", price); }

            if (updates.Count == 0) throw new OperationException("无任何字段更新");

            var updateQuery = $"UPDATE orderdetail SET {string.Join(",", updates)} WHERE id=@id;";

            if (ExecuteCommand(updateQuery, parameters) == 0)
                throw new OperationException("未找到对应订单");
        }

        public DataSet FetchAllOrders() => ExecuteQuery("SELECT * FROM orderdetail;");

        public DataSet SortOrders(string sortColumn) => ExecuteQuery($"SELECT * FROM orderdetail ORDER BY {sortColumn};");

        public DataSet SearchOrders(string id = null, string productName = null, string customer = null, double? price = null)
        {
            var conditions = new List<string>();

            if (!string.IsNullOrEmpty(id)) conditions.Add($"id='{id}'");
            if (!string.IsNullOrEmpty(productName)) conditions.Add($"obname='{productName}'");
            if (!string.IsNullOrEmpty(customer)) conditions.Add($"client='{customer}'");
            if (price.HasValue) conditions.Add($"price={price}");

            if (conditions.Count == 0) throw new OperationException("搜索条件不能为空");

            return ExecuteQuery($"SELECT * FROM orderdetail WHERE {string.Join(" AND ", conditions)} ORDER BY id;");
        }

        private int ExecuteCommand(string query, Dictionary<string, object> parameters)
        {
            connection.Open();
            var cmd = new MySqlCommand(query, connection);
            foreach (var param in parameters)
                cmd.Parameters.AddWithValue(param.Key, param.Value);

            var affectedRows = cmd.ExecuteNonQuery();
            connection.Close();
            cmd.Dispose();
            return affectedRows;
        }

        private DataSet ExecuteQuery(string query)
        {
            var dataSet = new DataSet();
            new MySqlDataAdapter(query, connectionString).Fill(dataSet);
            return dataSet;
        }
    }

    public class OperationException : ApplicationException
    {
        public OperationException(string message) : base(message) { }
    }
}