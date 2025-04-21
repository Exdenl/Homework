using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace OrderWeb.Repositories
{
    // ���� ʵ�嶨��
    public class OrderDetail
    {
        public string Id { get; set; }
        public string ObName { get; set; }
        public string Client { get; set; }
        public double Price { get; set; }
    }

    // ���� �ִ��ӿ�
    public interface IOrderRepository
    {
        Task EnsureTableAsync();
        Task AddAsync(OrderDetail order);
        Task<bool> DeleteAsync(string id);
        Task UpdateAsync(OrderDetail order);
        Task<IEnumerable<OrderDetail>> GetAllAsync();
        Task<IEnumerable<OrderDetail>> GetAllSortedAsync(string sortBy);
        Task<IEnumerable<OrderDetail>> QueryAsync(OrderDetail criteria);
    }

    // ���� �ִ�ʵ��
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connStr;

        public OrderRepository(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("OrderDb");
        }

        private IDbConnection Connection => new MySqlConnection(_connStr);

        public async Task EnsureTableAsync()
        {
            const string existsSql = @"
                SELECT COUNT(*) 
                  FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = DATABASE() 
                   AND TABLE_NAME = 'orderdetail';";
            const string createSql = @"
                CREATE TABLE orderdetail (
                    id VARCHAR(100) PRIMARY KEY,
                    obname VARCHAR(100) NOT NULL,
                    client VARCHAR(100) NOT NULL,
                    price DOUBLE NOT NULL
                );";

            using var db = Connection;
            var cnt = await db.ExecuteScalarAsync<int>(existsSql);
            if (cnt == 0)
                await db.ExecuteAsync(createSql);
        }

        public async Task AddAsync(OrderDetail order)
        {
            const string sql = @"
                INSERT INTO orderdetail (id, obname, client, price)
                VALUES (@Id, @ObName, @Client, @Price);";

            using var db = Connection;
            try
            {
                await db.ExecuteAsync(sql, order);
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new InvalidOperationException("�������Ѵ��ڣ�����ʧ�ܣ�");
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            const string sql = "DELETE FROM orderdetail WHERE id = @Id;";
            using var db = Connection;
            var affected = await db.ExecuteAsync(sql, new { Id = id });
            return affected > 0;
        }

        public async Task UpdateAsync(OrderDetail order)
        {
            var setters = new List<string>();
            var param = new DynamicParameters();
            param.Add("Id", order.Id);

            if (!string.IsNullOrWhiteSpace(order.ObName))
            {
                setters.Add("obname = @ObName");
                param.Add("ObName", order.ObName);
            }
            if (!string.IsNullOrWhiteSpace(order.Client))
            {
                setters.Add("client = @Client");
                param.Add("Client", order.Client);
            }
            if (order.Price >= 0)
            {
                setters.Add("price = @Price");
                param.Add("Price", order.Price);
            }
            if (!setters.Any())
                throw new ArgumentException("��Ҫ�޸ĵ���Ϣ����Ϊ�գ�");

            var sql = $"UPDATE orderdetail SET {string.Join(", ", setters)} WHERE id = @Id;";
            using var db = Connection;
            var affected = await db.ExecuteAsync(sql, param);
            if (affected == 0)
                throw new KeyNotFoundException("�Ҳ�����Ӧ���ݣ�");
        }

        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            const string sql = "SELECT * FROM orderdetail;";
            using var db = Connection;
            return await db.QueryAsync<OrderDetail>(sql);
        }

        public async Task<IEnumerable<OrderDetail>> GetAllSortedAsync(string sortBy)
        {
            var valid = new[] { "id", "obname", "client", "price" };
            if (!valid.Contains(sortBy.ToLower()))
                throw new ArgumentException("��֧�ֵ������ֶΣ�");
            var sql = $"SELECT * FROM orderdetail ORDER BY {sortBy};";
            using var db = Connection;
            return await db.QueryAsync<OrderDetail>(sql);
        }

        public async Task<IEnumerable<OrderDetail>> QueryAsync(OrderDetail c)
        {
            var conds = new List<string>();
            var param = new DynamicParameters();

            if (!string.IsNullOrWhiteSpace(c.Id))
            {
                conds.Add("id = @Id");
                param.Add("Id", c.Id);
            }
            if (!string.IsNullOrWhiteSpace(c.ObName))
            {
                conds.Add("obname = @ObName");
                param.Add("ObName", c.ObName);
            }
            if (!string.IsNullOrWhiteSpace(c.Client))
            {
                conds.Add("client = @Client");
                param.Add("Client", c.Client);
            }
            if (c.Price >= 0)
            {
                conds.Add("price = @Price");
                param.Add("Price", c.Price);
            }
            if (!conds.Any())
                throw new ArgumentException("������дһ���ѯ������");

            var sql = $"SELECT * FROM orderdetail WHERE {string.Join(" AND ", conds)} ORDER BY id;";
            using var db = Connection;
            return await db.QueryAsync<OrderDetail>(sql, param);
        }
    }
}