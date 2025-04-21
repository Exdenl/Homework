using System.Collections.Generic;

namespace OrderManagementAPI.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}