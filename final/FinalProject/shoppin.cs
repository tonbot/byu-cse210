// using System;
// using System.Collections.Generic;

// class Item
// {
//     public string Name { get; set; }
//     public double Price { get; set; }
// }

// class Catalog
// {
//     private List<Item> items = new List<Item>();

//     public Catalog()
//     {
//         items.Add(new Item { Name = "Item 1", Price = 10.0 });
//         items.Add(new Item { Name = "Item 2", Price = 20.0 });
//         items.Add(new Item { Name = "Item 3", Price = 30.0 });
//     }

//     public int Count
//     {
//         get { return items.Count; }
//     }

//     public Item GetItem(int index)
//     {
//         return items[index];
//     }

//     public void DisplayItems()
//     {
//         Console.WriteLine("Catalog:");
//         for (int i = 0; i < items.Count; i++)
//         {
//             Console.WriteLine($"{i + 1}. {items[i].Name} - ${items[i].Price}");
//         }
//     }
// }

// class User
// {
//     public string Name { get; set; }
//     public string Email { get; set; }
//     public string Password { get; set; }
// }

// class ShoppingCart
// {
//     private List<Item> items = new List<Item>();

//     public void AddItem(Item item)
//     {
//         items.Add(item);
//     }

//     public void DisplayItems()
//     {
//         Console.WriteLine("Shopping Cart:");
//         for (int i = 0; i < items.Count; i++)
//         {
//             Console.WriteLine($"{i + 1}. {items[i].Name} - ${items[i].Price}");
//         }
//     }

//     public List<Item> GetItems()
//     {
//         return items;
//     }

//     public double GetTotal()
//     {
//         double total = 0.0;
//         foreach (Item item in items)
//         {
//             total += item.Price;
//         }
//         return total;
//     }
// }

// class Order
// {
//     public List<Item> Items { get; set; }
//     public User User { get; set; }
//     public double Total { get; set; }
// }

// class OrderHistory
// {
//     private List<Order> orders = new List<Order>();

//     public void AddOrder(Order order)
//     {
//         orders.Add(order);
//     }

//     public void DisplayOrders()
//     {
//         Console.WriteLine("Order History:");
//         foreach (Order order in orders)
//         {
//             Console.WriteLine($"Order for {order.User.Name} - ${order.Total}");
//         }
//     }
// }

// class AuthenticationService
// {
//     private List<User> users = new List<User>();

//     public void Register(User user)
//     {
//         users.Add(user);
//     }

//     public User Authenticate(string email, string password)
//     {
//         foreach (User user in users)
//         {
//             if (user.Email == email && user.Password == password)
//             {
//                 return user;
//             }
//         }
//         return null;
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         Catalog catalog = new Catalog();
//         ShoppingCart cart = new ShoppingCart();
//         OrderHistory history = new OrderHistory();
//         AuthenticationService auth = new AuthenticationService();

//         // Register a user
//         User user = new User { Name = "John Smith", Email = "john.smith@example.com", Password = "password123" };
//         auth.Register(user);

//         // Authenticate the user
//         Console.WriteLine("Please enter your email and password to log in:");
//         string email = Console.ReadLine();
//         string password = Console.ReadLine();
//         user = auth.Authenticate(email, password);
//         if (user == null)
//         {
//             Console.WriteLine("Invalid email or password. Exiting program.");
//             return;
//            }

//     // Display catalog and prompt user for input
//     catalog.DisplayItems();
//     Console.WriteLine("Please enter the item number you wish to add to your cart (or 0 to finish):");
//     int input = int.Parse(Console.ReadLine());
//     while (input != 0)
//     {
//         if (input < 1 || input > catalog.Count)
//         {
//             Console.WriteLine("Invalid input. Please enter a valid item number.");
//         }
//         else
//         {
//             Item item = catalog.GetItem(input - 1);
//             cart.AddItem(item);
//             Console.WriteLine($"{item.Name} added to cart.");
//         }

//         catalog.DisplayItems();
//         Console.WriteLine("Please enter the item number you wish to add to your cart (or 0 to finish):");
//         input = int.Parse(Console.ReadLine());
//     }

//     // Display shopping cart and total
//     cart.DisplayItems();
//     Console.WriteLine($"Total: ${cart.GetTotal()}");

//     // Create order and add to history
//     Order order = new Order { Items = cart.GetItems(), User = user, Total = cart.GetTotal() };
//     history.AddOrder(order);

//     // Display order history
//     history.DisplayOrders();

//     Console.WriteLine("Thank you for shopping!");
// }
// }
