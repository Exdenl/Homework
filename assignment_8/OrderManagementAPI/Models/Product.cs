using System.Collections.Generic;

namespace OrderManagementAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}