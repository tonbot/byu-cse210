using System;
using System.Collections.Generic;
class Program
{

    static void Main(string[] args)
    {
        Catalog catalog = new Catalog();
        ShoppingCart cart = new ShoppingCart();
        OrderHistory history = new OrderHistory();
        AuthenticationService auth = new AuthenticationService();

        // Register a user
        User user = new User { Name = "Ajiboye Toyin", Email = "toyin@gmail.com", Password = "1234" };
        auth.Register(user);

        // Authenticate the user
        Console.WriteLine("Please enter your email and password to log in:");
        string email = Console.ReadLine();
        string password = Console.ReadLine();
        user = auth.Authenticate(email, password);
        if (user == null)
        {
            Console.WriteLine("Invalid email or password. Exiting program.");
            return;
           }

    // Display catalog and prompt user for input
    catalog.DisplayItems();
    Console.WriteLine("Please enter the item number you wish to add to your cart (or 0 to finish):");
    int input = int.Parse(Console.ReadLine());
    while (input != 0)
    {
        if (input < 1 || input > catalog.Count)
        {
            Console.WriteLine("Invalid input. Please enter a valid item number.");
        }
        else
        {
            Item item = catalog.GetItem(input - 1);
            cart.AddItem(item);
            Console.WriteLine($"{item.Name} added to cart.");
        }

        catalog.DisplayItems();
        Console.WriteLine("Please enter the item number you wish to add to your cart (or 0 to finish):");
        input = int.Parse(Console.ReadLine());
    }

    // Display shopping cart and total
    cart.DisplayItems();
    Console.WriteLine($"Total: ${cart.GetTotal()}");

    // Create order and add to history
    Order order = new Order { Items = cart.GetItems(), User = user, Total = cart.GetTotal() };
    history.AddOrder(order);

    // Display order history
    history.DisplayOrders();

    Console.WriteLine("Thank you for shopping!");
}
}