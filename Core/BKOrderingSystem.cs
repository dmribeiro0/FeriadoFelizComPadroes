class BKOrderingSystem : IOrderingSystem
{
    private const string RestaurantName = "Burger King";
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
        Console.WriteLine($"[{RestaurantName}] Menu");
        foreach (var item in BurgerKing.GetMenu().GetMenuItems())
        {
            Console.WriteLine($"  - {item.Key,-28} ${item.Value().GetPrice():0.00}");
        }
    }

    public void AddToOrder(string itemName)
    {
        try
        {
            var item = BurgerKing.GetMenu().GetItem(itemName);
            currentOrder.Add(item);
            Console.WriteLine($"[{RestaurantName}] Added to order: {itemName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[{RestaurantName}] Could not add '{itemName}': {ex.Message}");
        }
    }

    public void RemoveFromOrder(string itemName)
    {
        var item = currentOrder.FirstOrDefault(i => i.GetType().Name == itemName);
        if (item != null)
        {
            currentOrder.Remove(item);
            Console.WriteLine($"[{RestaurantName}] Removed from order: {itemName}");
        }
        else
        {
            Console.WriteLine($"[{RestaurantName}] Item not found in order: {itemName}");
        }
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"[{RestaurantName}] Current order");
        if (currentOrder.Count == 0)
        {
            Console.WriteLine("  - No items selected");
            return;
        }

        foreach (var item in currentOrder)
        {
            Console.WriteLine($"  - {item.GetType().Name,-28} ${item.GetPrice():0.00}");
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
            Console.WriteLine($"[{RestaurantName}] Select a payment method before placing the order.");
            return;
        }

        if (currentOrder.Count == 0)
        {
            Console.WriteLine($"[{RestaurantName}] Your order is empty.");
            return;
        }

        var total = currentOrder.Sum(i => i.GetPrice());
        Console.WriteLine($"[{RestaurantName}] Order confirmed. Total: ${total:0.00}");
        paymentMethod.Pay(total);
    }

}