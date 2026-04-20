class Burger : IMenuItem
{
    private double price = 5.0;

    public double GetPrice()
    {
        Console.WriteLine($"Burger price: ${this.price:F2}");
        return price;
    }
}