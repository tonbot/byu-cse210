class Catalog
{
    private List<Item> items = new List<Item>();

    public Catalog()
    {
        items.Add(new Item { Name = "Iphone", Price = 2000.0 });
        items.Add(new Item { Name = "Samsung", Price = 900.0 });
        items.Add(new Item { Name = "Nokia", Price = 500.0 });
        items.Add(new Item { Name = "Xbox", Price = 2000.0 });
        items.Add(new Item { Name = "PS5", Price = 800.0 });
        items.Add(new Item { Name = "Nitendo", Price = 700.0 });
    }

    public int Count
    {
        get { return items.Count; }
    }

    public Item GetItem(int index)
    {
        return items[index];
    }

    public void DisplayItems()
    {
        Console.WriteLine("Catalog:");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].Name} - ${items[i].Price}");
        }
    }
}