class ExtraBun : MenuItemDecorator
{
    private double price = 0.50;

    public ExtraBun(IMenuItem item) : base(item)
    {
    }

    public override double GetPrice()
    {
        return this.price + base.GetPrice();
    }
}