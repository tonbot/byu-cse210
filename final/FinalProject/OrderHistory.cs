class OrderHistory
{
    private List<Order> orders = new List<Order>();

    public void AddOrder(Order order)
    {
        orders.Add(order);
    }

    public void DisplayOrders()
    {
        Console.WriteLine("Order History:");
        foreach (Order order in orders)
        {
            Console.WriteLine($"Order for {order.User.Name} - ${order.Total}");
        }
    }
}