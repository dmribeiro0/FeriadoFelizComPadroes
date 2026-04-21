class Bun : MenuItemDecorator
{
    private double price = 0.50;

    public Bun(IMenuItem item) : base(item)
    {
    }

    public override double GetPrice()
    {
        return this.price + base.GetPrice();
    }
}