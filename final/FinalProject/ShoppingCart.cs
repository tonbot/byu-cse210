class ShoppingCart
{
    private List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void DisplayItems()
    {
        Console.WriteLine("Shopping Cart:");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].Name} - ${items[i].Price}");
        }
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public double GetTotal()
    {
        double total = 0.0;
        foreach (Item item in items)
        {
            total += item.Price;
        }
        return total;
    }
}