class GuaranaAntarctica : IMenuItem
{
    private double price = 2.5;

    public double GetPrice()
    {
        Console.WriteLine($"Guarana Antarctica price: ${this.price:F2}");
        return price;
    }
}