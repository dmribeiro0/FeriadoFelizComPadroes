class BKOrderingSystem : IOrderingSystem
{
    private Restaurant BurgerKing;
    private List<IMenuItem> currentOrder;
    private PaymentMethod paymentMethod;

    public BKOrderingSystem()
    {
        BurgerKing = new BurgerKing();
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Burger King Menu:");
        foreach (var item in BurgerKing.GetMenu().GetMenuItems())
        {
            Console.WriteLine($"{item.Key} - ${item.Value().GetPrice():0.00}");
        }
    }

    public void AddToOrder(string itemName)
    {
        try
        {
            var item = BurgerKing.GetMenu().GetItem(itemName);
            currentOrder.Add(item);
            Console.WriteLine($"{itemName} added to order.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void RemoveFromOrder(string itemName)
    {
        var item = currentOrder.FirstOrDefault(i => i.GetType().Name == itemName);
        if (item != null)
        {
            currentOrder.Remove(item);
            Console.WriteLine($"{itemName} removed from order.");
        }
        else
        {
            Console.WriteLine($"{itemName} not found in order.");
        }
    }

    public void DisplayOrder()
    {
        Console.WriteLine("Current Order:");
        foreach (var item in currentOrder)
        {
            Console.WriteLine($"{item.GetType().Name} - ${item.GetPrice():0.00}");
        }
    }

    public void SetPaymentMethod(string method)
    {
        paymentMethod = method;
    }

    public void PlaceOrder()
    {
        Console.WriteLine("Order placed successfully.");
        // Payment processing logic goes here
    }

}