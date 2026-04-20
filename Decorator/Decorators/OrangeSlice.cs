class OrangeSlice : MenuItemDecorator
{
    private double price = 0.25;

    public OrangeSlice(IMenuItem item) : base(item)
    {
    }

    public override double GetPrice()
    {
        return this.price + menuItem.GetPrice();
    }
}