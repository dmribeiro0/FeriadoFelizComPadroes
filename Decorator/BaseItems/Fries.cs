class Fries : IMenuItem
{
    private double price = 3.0;

    public double GetPrice()
    {
        Console.WriteLine($"Fries price: ${this.price:F2}");
        return price;
    }
}