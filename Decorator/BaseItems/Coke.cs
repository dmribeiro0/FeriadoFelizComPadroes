class Coke : IMenuItem
{
    private double price = 2.0;

    public double GetPrice()
    {
        Console.WriteLine($"Coke price: ${this.price:F2}");
        return price;
    }
}