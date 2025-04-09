namespace Week6;
using System.Diagnostics;
public class Order
{
    public int OrderId;
    public OrderDetails OrderDetails;
    
    public static event Action<Order> OrderCreated;

    
    
}