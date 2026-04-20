class CheeseBurger : IMenuItem
{
    private double price = 5.0;

    public double GetPrice()
    {
        Console.WriteLine($"Cheese Burger price: ${this.price:F2}");
        return price;
    }
}