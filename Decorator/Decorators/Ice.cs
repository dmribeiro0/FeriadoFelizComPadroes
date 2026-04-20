class Ice : MenuItemDecorator
{
    private double price = 0.0;

    public Ice(IMenuItem item) : base(item)
    {
    }

    public override double GetPrice()
    {
        return this.price + menuItem.GetPrice();
    }
}
