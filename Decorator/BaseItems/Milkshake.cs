class Milkshake : IMenuItem
{
    private double price = 4.0;

    public double GetPrice()
    {
        Console.WriteLine($"Milkshake price: ${this.price:F2}");
        return price;
    }
}