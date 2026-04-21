class Salad : MenuItemDecorator
{
    private double price = 0.5;

    public Salad(IMenuItem item) : base(item)
    {
    }

    public override double GetPrice()
    {
        return this.price + base.GetPrice();
    }
}