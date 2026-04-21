void RunOrderingFlow(string restaurantName, IOrderingSystem orderingSystem, IPaymentMethod paymentMethod, IEnumerable<string> items)
{
	Console.WriteLine();
	Console.WriteLine($"================ {restaurantName} ================");
	Console.WriteLine("[Test] Menu");
	orderingSystem.DisplayMenu();
	Console.WriteLine();

	Console.WriteLine("[Test] Adding items");
	foreach (var item in items)
	{
		Console.WriteLine($"  -> {item}");
		orderingSystem.AddToOrder(item);
	}

	Console.WriteLine("[Test] Current order");
	orderingSystem.DisplayOrder();
	Console.WriteLine();

	Console.WriteLine("[Test] Payment");
	orderingSystem.SetPaymentMethod(paymentMethod);
	orderingSystem.PlaceOrder();
	Console.WriteLine("================================================");
}

RunOrderingFlow(
	"McDonald's Smoke Test",
	new McDOrderingSystem(),
	new CreditCardPayment(),
	new[]
	{
		"Big Mac",
		"Fries",
		"Coke",
		"Big Mac Combo"
	});

RunOrderingFlow(
	"Burger King Smoke Test",
	new BKOrderingSystem(),
	new PixPayment(),
	new[]
	{
		"Whopper",
		"Fries",
		"Coke",
		"Whopper Combo"
	});
