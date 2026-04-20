class Bacon : MenuItemDecorator
{
    private double price = 1.5;

    public Bacon(IMenuItem item) : base(item)
    {
    }

    public override double GetPrice()
    {
        return this.price + menuItem.GetPrice();
    }
}