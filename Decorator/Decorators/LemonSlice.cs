class LemonSlice : MenuItemDecorator
{
    private double price = 0.25;

    public LemonSlice(IMenuItem item) : base(item)
    {
    }

    public override double GetPrice()
    {
        return this.price + menuItem.GetPrice();
    }
}