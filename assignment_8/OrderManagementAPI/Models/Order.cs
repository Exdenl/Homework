using System.Collections.Generic;

namespace OrderManagementAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetails> Details { get; set; }
    }
}