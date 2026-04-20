class ExtraCheese : MenuItemDecorator
{
    private double price = 0.5;

    public ExtraCheese(IMenuItem item) : base(item)
    {
    }

    public override double GetPrice()
    {
        return this.price + menuItem.GetPrice();
    }
}