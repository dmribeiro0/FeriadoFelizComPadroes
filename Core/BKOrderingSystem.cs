class BKOrderingSystem : IOrderingSystem
{
    private IRestaurant BurgerKing;
    private List<IMenuItem> currentOrder;
    private IPaymentMethod? paymentMethod;
    private IPaymentObserver paymentObserver;

    public BKOrderingSystem()
    {
        BurgerKing = new BurgerKing();
        currentOrder = new List<IMenuItem>();
        paymentObserver = new PaymentObserver();
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

    public void SetPaymentMethod(IPaymentMethod method)
    {
        paymentMethod = method;
        paymentMethod.SetObserver(paymentObserver);
    }

    public void PlaceOrder()
    {
        if (paymentMethod == null)
        {
            Console.WriteLine("Select a payment method before placing the order.");
            return;
        }

        if (currentOrder.Count == 0)
        {
            Console.WriteLine("Your order is empty.");
            return;
        }

        Console.WriteLine("Order placed successfully.");
        paymentMethod.Pay(currentOrder.Sum(i => i.GetPrice()));
    }

}