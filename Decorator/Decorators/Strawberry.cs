class Strawberry : MenuItemDecorator
{
    private double price = 1.0;

    public Strawberry(IMenuItem item) : base(item)
    {
    }

    public override double GetPrice()
    {
        return this.price + base.GetPrice();
    }
}