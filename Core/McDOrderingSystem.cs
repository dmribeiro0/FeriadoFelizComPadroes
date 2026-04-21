class McDOrderingSystem : IOrderingSystem
{
    private Restaurant McDonalds;
    private List<IMenuItem> currentOrder;
    private IPaymentMethod paymentMethod;
    private IPaymentObserver paymentObserver;

    public McDOrderingSystem()
    {
        McDonalds = new McDonalds();
        paymentObserver = new PaymentObserver();
    }

    public void DisplayMenu()
    {
        Console.WriteLine("McDonald's Menu:");
        foreach (var item in McDonalds.GetMenu().GetMenuItems())
        {
            Console.WriteLine($"{item.Key} - ${item.Value().GetPrice():0.00}");
        }
    }

    public void AddToOrder(string itemName)
    {
        try
        {
            var item = McDonalds.GetMenu().GetItem(itemName);
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

    public void SetPaymentMethod(IPaymentMethod method)
    {
        paymentMethod = method;
        paymentMethod.SetObserver(paymentObserver);
    }

    public void PlaceOrder()
    {
        Console.WriteLine("Order placed successfully.");
        paymentMethod.Pay(currentOrder.Sum(i => i.GetPrice()));
    }
}