using Week6;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System.Data.Common;




public static class Program
{
    public static OrderService orderService = new OrderService();
    static void Main()
    {
        
        orderService.AddOrder("Mike","milk");
        orderService.AddOrder("Jack","water");
        orderService.AddOrder("George","computer");
        orderService.AddOrder("Linda","candy");
        orderService.AddOrder("Tina","phone");
        Application.Run(new Form1());
        const string sql = "TRUNCATE TABLE orders";

       
    }
}