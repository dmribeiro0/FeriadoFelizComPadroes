class ExtraPatty : MenuItemDecorator
{
    private double price = 1.0;

    public ExtraPatty(IMenuItem item) : base(item)
    {
    }

    public override double GetPrice()
    {
        return this.price + menuItem.GetPrice();
    }
}